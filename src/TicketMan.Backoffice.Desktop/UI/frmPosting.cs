using System;
using System.Windows.Forms;
using TicketMan.Backoffice.Desktop.Decorators;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Exceptions;
using TicketMan.Platform.Protocol.ObjectModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace TicketMan.Backoffice.Desktop.UI
{
	public partial class FrmPosting : XtraForm
	{
		OrderDecorator _order;
		string _paymentUniqueNumber;

		public FrmPosting(string paymentUniqueNumber)
		{
			_paymentUniqueNumber = paymentUniqueNumber;
			InitializeComponent();
			//gridViewDeals.OptionsBehavior.ReadOnly = true;
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			GetOrder();
		}

		private void GetOrder()
		{
			string orderUniqueNumber = txtOrderNumber.Text;
			if (orderUniqueNumber == "") return;
			try
			{
				var restClient = (OrdersRestClient)DataProcessor.GetRestClient("OrdersRestClient");
				var ordersPayload = restClient.GetOrder(orderUniqueNumber).Payload as OrdersPayloadElement;
				_order = new OrderDecorator(ordersPayload.Orders[0]);
				RefreshOrder();
			}
			catch (LogicalApiException e)
			{
				MessageBox.Show(String.Format("Ошибка. Код: {0}. Сообщение: {1}", e.Code, e.Message));
			}
			catch(Exception ex)
			{
				MessageBox.Show(String.Format("Ошибка: {0}", ex.Message));
			}
		}

		void RefreshOrder()
		{
			gridDeals.DataSource = _order.Deals;
			gridViewDeals.Columns.Add(
			new DevExpress.XtraGrid.Columns.GridColumn()
			{
				Caption = "Разнести",
				ColumnEdit = new RepositoryItemCheckEdit() { },
				VisibleIndex = 0,
				UnboundType = DevExpress.Data.UnboundColumnType.Boolean
			}
		);

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}