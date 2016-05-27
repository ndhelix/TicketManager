using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TicketMan.Backoffice.Desktop.Decorators;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using TicketMan.Platform.Protocol.ObjectModel.Reservations;
using System.Windows.Forms;
using TicketMan.Platform.Api.Shared.Exceptions;
using TicketMan.Backoffice.Desktop.Core;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmOrder : DevExpress.XtraEditors.XtraForm
	{

		OrderDecorator _order;
		string _orderUniqueNumber;

		public FrmOrder(string orderUniqueNumber)
		{
			_orderUniqueNumber = orderUniqueNumber;
			InitializeComponent();
			MakeGridViewsReadOnly();
		}

		private void MakeGridViewsReadOnly()
		{
			gridViewClients.OptionsBehavior.ReadOnly = true;
			gridViewComments.OptionsBehavior.ReadOnly = true;
			gridViewDeals.OptionsBehavior.ReadOnly = true;
			gridViewDocuments.OptionsBehavior.ReadOnly = true;
			gridViewOrderExtensions.OptionsBehavior.ReadOnly = true;
			gridViewPaymentDetailsExtensions.OptionsBehavior.ReadOnly = true;
			gridViewPriceDetails.OptionsBehavior.ReadOnly = true;
			gridViewServices.OptionsBehavior.ReadOnly = true;
		}

		private void frmOrder_Load(object sender, EventArgs e)
		{
			RefreshData();
		}


		void RefreshData()
		{
			splashScreenManager1.ShowWaitForm();
			try
			{
				if (_orderUniqueNumber != "")
				{
					GetOrder();
				}
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}
		}


		void GetOrder()
		{
			try
			{
				var restClient = (OrdersRestClient)DataProcessor.GetRestClient("OrdersRestClient");
				var ordersPayload = restClient.GetOrder(_orderUniqueNumber).Payload as OrdersPayloadElement;
				_order = new OrderDecorator(ordersPayload.Orders[0]);
				RefreshOrder();
			}
			catch (LogicalApiException e)
			{
				//MessageBox.Show(String.Format("Ошибка. Код: {0}. Сообщение: {1}", e.Code, e.Message));
			}
		}

		void RefreshOrder()
		{
			RefreshCommon();
			RefreshPaymentDetails();
			RefreshClients();
			txtPriceDetails_Total.Text = _order.PriceDetails.Total.ToString();
			gridPriceDetails.DataSource = _order.PriceDetails.UnclassifiedDetails;
			gridDeals.DataSource = _order.Deals;
			gridServices.DataSource = _order.Services;
			gridComments.DataSource = _order.Comments;
			gridDocuments.DataSource = _order.Documents;
            
            RepositoryItemButtonEdit editor = new RepositoryItemButtonEdit();
            editor.ButtonClick += EditorOnButtonClick;
            editor.Buttons[0].Caption = "Скачать";
            editor.Buttons[0].ToolTip = "Скачать и открыть";
		    editor.Buttons[0].Image = Properties.Resources.down_arrow_download;
            editor.Buttons[0].Kind = ButtonPredefines.Glyph;
		    gridViewDocuments.Columns[4].ColumnEdit = editor;

#if DEBUG
            if (_order.Documents.Count > 0)
            {
                //MessageBox.Show("There are documents here!");
            }
#endif
			gridOrderExtensions.DataSource = Utils.ParseExtensions(_order.Extensions);
		}

	    private void EditorOnButtonClick(object sender, ButtonPressedEventArgs buttonPressedEventArgs)
	    {
            try
            {
                var restClient = (OrdersDocumentsRestClient)DataProcessor.GetRestClient("OrdersDocumentsRestClient");
                var o = gridViewDocuments.GetRow(gridViewDocuments.FocusedRowHandle);
                var od = o as OrderDocumentInfoDecorator;

                OrderDocument orderDocument = restClient.GetOrderDocument(_orderUniqueNumber, od.Code);

                string filePath = Path.Combine(Path.GetTempPath(), orderDocument.Name);
                File.WriteAllBytes(filePath, orderDocument.Content);
                Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
            }
            catch (LogicalApiException e)
            {
                MessageBox.Show(String.Format("Ошибка. Код: {0}. Сообщение: {1}", e.Code, e.Message));
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("Ошибка. {0}", e.Message));
            }
        }

	    private void RefreshClients()
		{
			gridClients.DataSource = _order.Clients;//.ConvertAll<ClientDecorator>(x => 
				//new ClientDecorator(x, _order.Arrangements.Find(y => y.ClientID == x.ID),  _order.ServiceType)
				//);
			//var r = _order.Clients[0].Extensions;
		}

		private void RefreshPaymentDetails()
		{
			txtCurrencyID.Text = _order.PaymentDetails.CurrencyID.ToString();
			txtDiscount.Text = _order.PaymentDetails.Discount.ToString();
			txtPaymentDeadline.Text = _order.PaymentDetails.PaymentDeadline.ToString();
			txtRemainingAmount.Text = _order.PaymentDetails.RemainingAmount.ToString();
			txtTotalAmount.Text = _order.PaymentDetails.TotalAmount.ToString();
			txtPaidAmount.Text = _order.PaymentDetails.PaidAmount.ToString();
			txtTotalPaymentSystemCommission.Text = _order.PaymentDetails.TotalPaymentSystemCommission.ToString();

			gridPaymentDetailsExtensions.DataSource = Utils.ParseExtensions(_order.PaymentDetails.Extensions);
		}

		private void RefreshCommon()
		{
			txtBaseDate.Text = _order.BaseDate.ToString();
			//txtBuyerId.Text = _order.BuyerID.ToString();
			txtCreatedAt.Text = _order.CreatedAt.ToString();
			//txtPackageID.Text = _order.PackageID;
			//txtSellerId.Text = _order.SellerID.ToString();
			txtServiceType.Text = _order.ServiceType.ToString();
			txtStatus.Text = EnumTranslator.Translate("OrderStatus", _order.Status.ToString());
			txtUniqueNumber.Text = _order.UniqueNumber;
			this.Text = "Заявка " + _order.UniqueNumber;
			//txtVendorID.Text = _order.VendorID.ToString();
			txtVendorStatus.Text = EnumTranslator.Translate("OrderStatus",_order.VendorStatus.ToString());
			txtVendorUniqueNumber.Text = _order.VendorUniqueNumber;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}



	}
}
