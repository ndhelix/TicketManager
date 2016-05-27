using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments;
using TicketMan.Backoffice.Desktop.Decorators;
using TicketMan.Platform.Api.Shared.Exceptions;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmPaymentReport : DevExpress.XtraEditors.XtraForm
	{
		PaymentReport _paymentReport;
		string _paymentReportUniqueNumber;

		public FrmPaymentReport(string paymentReportUniqueNumber)
		{
			_paymentReportUniqueNumber = paymentReportUniqueNumber;
			InitializeComponent();
		}

		private void frmPaymentReport_Load(object sender, EventArgs e)
		{
			RefreshData();
		}



		void RefreshData()
		{
			splashScreenManager1.ShowWaitForm();
			try
			{
				if (_paymentReportUniqueNumber != "")
				{
					GetPaymentReport();
					RefreshPaymentReport();
				}
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}
		}


		void GetPaymentReport()
		{
			try
			{
				var restClient = (PaymentReportsRestClient)DataProcessor.GetRestClient("PaymentReportsRestClient");
                _paymentReport = restClient.GetPaymentReport(_paymentReportUniqueNumber);
			}
			catch (LogicalApiException e)
			{
				MessageBox.Show(String.Format("Ошибка. Код: {0}. Сообщение: {1}", e.Code, e.Message));
			}

		}

		void RefreshPaymentReport()
		{
			if (_paymentReport == null) return;
			txtCurrencyCode.Text = _paymentReport.CurrencyCode;
			txtPaymentAmount.Text = _paymentReport.PaymentAmount.ToString("0.00");
            txtReceivedAmount.Text = _paymentReport.RecivingAmount.ToString("0.00");
			txtBeneficiaryName.Text = _paymentReport.Beneficiar.Name;
			txtComment.Text = _paymentReport.Comment;
			txtCreatedAt.Text = _paymentReport.CreatedAt.ToString();
			txtOrderUniqueNumber.Text = _paymentReport.OrderUniqueNumber;
			txtPayer.Text = _paymentReport.Payer.Name;
			txtPaymentSystem.Text = _paymentReport.PaymentSystem.Name;
			txtPayerLegalStatus.Text = _paymentReport.PayerLegalStatus.ToString();
			txtPaymentSystemUniqueNumber.Text = _paymentReport.PaymentSystemUniqueNumber;
			txtType.Text = _paymentReport.Type.ToString();
			txtUniqueNumber.Text = _paymentReport.UniqueNumber;
            txtCommissionAmount.Text = _paymentReport.CommissionAmount.ToString("0.00");
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void txtComment_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnReassign_Click(object sender, EventArgs e)
        {
            if (txtNewOrderNumber.Text.Trim() == "")
            {
                MessageBox.Show("Номер заявки не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string msg = string.Format("Вы уверены, что хотите перенести отчет об оплате № {0} с заявки {1} на заявку {2}"
                , _paymentReportUniqueNumber, _paymentReport.OrderUniqueNumber, txtNewOrderNumber.Text.Trim());
            DialogResult result = MessageBox.Show(msg, "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            var restClient = (PaymentReportsRestClient)DataProcessor.GetRestClient("PaymentReportsRestClient");
            try
            {
                //restClient.ReassignPaymentReport(_paymentReportUniqueNumber, txtNewOrderNumber.Text.Trim());
                MessageBox.Show("Отчет об оплате успешно перенесен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(ex.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





	}
}
