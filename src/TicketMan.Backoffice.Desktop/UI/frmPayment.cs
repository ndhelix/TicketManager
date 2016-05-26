using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TicketMan.Backoffice.Desktop.Core;
using TicketMan.Backoffice.Desktop.Decorators;
using TicketMan.Backoffice.Desktop.UI;
using TicketMan.Backoffice.Desktop.UI.Service;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Exceptions;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments;
using TicketMan.Platform.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using DevExpress.XtraEditors.Repository;
using PartyInfo = TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments.PartyInfo;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmPayment : EditableForm
	{
		Payment _payment;
		string _paymentUniqueNumber;
		bool _isnew;
		List<PaymentPosting> _Postings;
		long _SenderPartyId;
		string _SenderPartyName;
		long _RecipientOrganizationId;
		OrderDecorator _order; //заявка, на которую разносится платеж

		public FrmPayment(string paymentUniqueNumber, long senderPartyId, string senderPartyName)
		{
			_paymentUniqueNumber = paymentUniqueNumber;
			_isnew = paymentUniqueNumber == "";
			_SenderPartyId = senderPartyId;
			_SenderPartyName = senderPartyName;
			_RecipientOrganizationId = Persistence.LoggedOrganization().Id;
			InitializeComponent();
		}

		public FrmPayment(string paymentUniqueNumber)
		{
			_paymentUniqueNumber = paymentUniqueNumber;
			_isnew = paymentUniqueNumber == "";
			InitializeComponent();
		}

		private void frmPayment_Load(object sender, EventArgs e)
		{
			RefreshData();
			RefreshStaticData();
		}

		void RefreshStaticData()
		{
			cbPaymentType.Properties.DataSource = new EnumDecorator<PaymentType>().list;
			cbPaymentType.Properties.ValueMember = "Value";
			cbPaymentType.Properties.DisplayMember = "Caption";

			cbBankAccountCode.Properties.DataSource = Persistence.LoggedOrganization().Essentials.BankAccounts;
			cbBankAccountCode.Properties.ValueMember = "Code";
			cbBankAccountCode.Properties.DisplayMember = "AccountNumber";
		}

		void SetDesign()
		{
			btnCreate.Visible = _isnew;
			groupPosting.Enabled = !_isnew;
			//btnCreatePosting.Enabled = !_isnew;
			btnSavePayment.Visible = !btnCreate.Visible;
			Text = _isnew ? "Создание платежа" : "Редактирование платежа";
			//txtBuyerPartyId.Properties.ReadOnly = !isnew;
			//txtPaymentType.Text = _paymentType.ToString();
			if (_payment != null)
				btnCancelPost.Enabled = _payment.Postings.Count > 0;
			if (_isnew)
			{
				txtCurrencyCode.Text = "Rub";
				btnPost.Enabled = btnCancelPost.Enabled = false;
			}
			cbPaymentType.Properties.ShowHeader = false;
		}



		private void SetСontractors()
		{
			txtRecipient.Text = Persistence.LoggedOrganization().FullName;
			txtSender.Text = _SenderPartyName;
		}

		void RefreshData()
		{
			try
			{
				splashScreenManager1.ShowWaitForm();
				if (!_isnew)
				{
					GetPayment();
					RefreshPayment();
					RefreshPostings();
				}
				SetDesign();
				SetСontractors();
				Dirty = false;
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}
		}

		private void RefreshPostings()
		{
			if (_payment.Postings.Count <1) return;
			txtOrderNumberSearch.Text = _payment.Postings[0].OrderUniqueNumber;
			GetOrder();
		}


		void GetPayment()
		{
			var restClient = (PaymentsRestClient)DataProcessor.GetRestClient("PaymentsRestClient");
			_payment = restClient.GetPayment(_paymentUniqueNumber);
			if (_payment.Postings == null)
				_payment.Postings = new List<PaymentPosting>();
			_SenderPartyId = _payment.Sender.PartyId;
			_SenderPartyName = _payment.Sender.Name;
			_RecipientOrganizationId = _payment.RecipientOrganizationId;
		}

		void RefreshPayment()
		{
			cbPaymentType.EditValue = _payment.PaymentType.ToString();
			txtSender.Text = _SenderPartyName;
			txtCurrencyCode.Text = _payment.CurrencyCode;
			txtComment.Text = _payment.Comment;
			txtDescription.Text = _payment.Description;
			txtExternalNumber.Text = _payment.ExternalNumber;
			chIsManual.Checked = _payment.IsManual;
			chIsPosted.Checked = _payment.IsPosted;
			calPaymentDate.DateTime = _payment.PaymentDate;
			txtAmount.Text = _payment.Amount.ToString();
			cbPaymentType.EditValue = _payment.PaymentType;

			_Postings = _payment.Postings;

			cbBankAccountCode.EditValue = _payment.BankAccountCode;
		}

		Payment GetUpdatedPayment()
		{
			Payment newpayment = _payment ?? new Payment();

			decimal amount;
			decimal.TryParse(txtAmount.Text, out amount);
			newpayment.Amount = amount;

			newpayment.PaymentType = (PaymentType)Enum.Parse(typeof(PaymentType), cbPaymentType.EditValue.ToString(), true);
			newpayment.RecipientOrganizationId = _RecipientOrganizationId;
			newpayment.CurrencyCode = txtCurrencyCode.Text;
			newpayment.Comment = txtComment.Text;
			newpayment.Description = txtDescription.Text;
			newpayment.ExternalNumber = txtExternalNumber.Text;
			newpayment.IsManual = chIsManual.Checked;
			newpayment.PaymentDate = calPaymentDate.DateTime;
			newpayment.RecipientOrganizationId = _RecipientOrganizationId;
			newpayment.Sender = new PartyInfo {PartyId = _SenderPartyId};

			//UpdatePostings();
			newpayment.Postings = _Postings;

			if (cbBankAccountCode.EditValue != null)
				newpayment.BankAccountCode = cbBankAccountCode.EditValue.ToString();
			return newpayment;
		}

		private void btnSavePayment_Click(object sender, EventArgs e)
		{
			UpdatePayment(false);
		}


		private void btnCreate_Click(object sender, EventArgs e)
		{
			UpdatePayment(true);
		}

		void UpdatePayment(bool isnew)
		{
			if (!Dirty && !isnew) return;
			string errmsg = CheckFields();
			if (errmsg != "")
			{
				MessageBox.Show(errmsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			var restClient = (PaymentsRestClient)DataProcessor.GetRestClient("PaymentsRestClient");
			var updated = GetUpdatedPayment();
			_paymentUniqueNumber = updated.UniqueNumber;
			if (isnew)
			{
				_payment = restClient.CreatePayment(updated);
				_paymentUniqueNumber = _payment.UniqueNumber;
				_isnew = false;
			}
			else
			{
				try
				{
					restClient.UpdatePayment(updated);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			RefreshData();
		}

		private string CheckFields()
		{
			string ret = "";
			if (cbBankAccountCode.EditValue == null)
				ret += "Счет получателя не указан. " + Environment.NewLine;
			if (cbPaymentType.EditValue == null)
				ret += "Тип платежа не указан. " + Environment.NewLine;
			if (calPaymentDate.DateTime == DateTime.MinValue)
				ret += "Дата платежа не указана. " + Environment.NewLine;
			decimal amount;
			if (!decimal.TryParse(txtAmount.Text, out amount))
				ret += "Сумма платежа не указана. " + Environment.NewLine;
			else
				if (amount <= 0)
					ret += "Сумма платежа должна быть больше нуля. " + Environment.NewLine;
			return ret;
		}


		private void FrmPayment_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!Dirty) return;
			DialogResult result = MessageBox.Show("Сохранить изменения?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				UpdatePayment(_isnew);
			}
			else
				if (result == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private void cbBankAccountCode_EditValueChanged(object sender, EventArgs e)
		{
			RefreshBankAccount();
		}

		private void RefreshBankAccount()
		{
			if (cbBankAccountCode.EditValue != null)
			{
				BankAccount bankAccount = Persistence.LoggedOrganization().Essentials.BankAccounts.Find(x => x.Code == cbBankAccountCode.EditValue.ToString());
				if (bankAccount != null)
				{
					txtAccountNumber.Text = bankAccount.AccountNumber;
					txtBankAddress.Text = bankAccount.BankAddress;
					txtBankName.Text = bankAccount.BankName;
					txtBik.Text = bankAccount.Bik;
					txtCorrespondingAccountNumber.Text = bankAccount.CorrespondingAccountNumber;
					return;
				}
			}
			txtAccountNumber.Text =
			txtBankAddress.Text =
			txtBankName.Text =
			txtBik.Text =
			txtCorrespondingAccountNumber.Text = "";
		}


		private void btnGetOrder_Click(object sender, EventArgs e)
		{
			GetOrder();
		}

		private void GetOrder()
		{
			string orderUniqueNumber = txtOrderNumberSearch.Text;
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
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("Ошибка: {0}", ex.Message));
			}
		}

		void RefreshOrder()
		{
			txtOrderUniqueNumber.Text = _order.UniqueNumber;
			txtOrderStatus.Text = EnumTranslator.Translate("OrderStatus", _order.Status);
			txtOrderCreatedAt.Text = _order.CreatedAt.ToString("dd MMM yyyy");
			txtPriceDetails_Total.Text = _order.PriceDetails.Total.ToString();
			if (_order.Services != null)
				if (_order.Services.Count > 0)
					txtOrderDescription.Text = _order.Services[0].Description;
			
			bool allowPost = false;
			if (!_payment.IsPosted)
				switch (_order.GetComponent().Status )
				{
					case OrderStatus.Issued:
						goto case OrderStatus.Confirmed;
					case OrderStatus.Pending:
						goto case OrderStatus.Confirmed;
					case OrderStatus.Coordinated:
						goto case OrderStatus.Confirmed;
					case OrderStatus.Confirmed:
						allowPost = true;
						break;
					default:
						txtOrderStatus.BackColor = Color.LightSalmon;
						break;
				}
			btnPost.Enabled = allowPost;
			if (allowPost)
				txtOrderStatus.BackColor = Color.LightGray;
		}

		private void btnPost_Click(object sender, EventArgs e)
		{
			ProceedPosting(true);
		}

		private void ProceedPosting(bool post)
		{
			try
			{
				Dirty = true;
				PaymentPosting posting=null;
				if (post)
				{
					posting = new PaymentPosting
					                         	{	
					                         		Amount = _payment.Amount,
					                         		Description = "",
					                         		OrderUniqueNumber = txtOrderUniqueNumber.Text
					                         	};
				}
				_payment.Postings.Clear();
				if (post)
					_payment.Postings.Add(posting);
				_payment.IsPosted = post;
				UpdatePayment(false);
			}
			catch (Exception e)
			{
				_payment.IsPosted = !post;
				MessageBox.Show(String.Format( e.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
	
		}

		private void txtOrderNumber_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				GetOrder();
			}
		}

		private void btnCancelPost_Click(object sender, EventArgs e)
		{
			ProceedPosting(false);
		}
	}
}
