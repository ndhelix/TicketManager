using System;
using System.Windows.Forms;
using TicketMan.Platform.Api.Shared;
using DevExpress.XtraEditors;
using TicketMan.Platform.Api.Shared.Protocol.Requests;

namespace TicketMan.Backoffice.Desktop.UI.dlg
{
	public partial class DlgImportOrder : XtraForm
	{
		private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;

		public DlgImportOrder()
		{
			InitializeComponent();
			this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TicketMan.Backoffice.Desktop.WaitForm1), true, true);

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			splashScreenManager1.ShowWaitForm();
			try
			{
				ImportOrder();
				MessageBox.Show("Заявка была импортирована");
				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format(ex.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}
		}

		private void ImportOrder()
		{
			var restClient = (FlightsRestClient)DataProcessor.GetRestClient("FlightsRestClient");
			var request = new ImportOrderRequest
			{
				VendorUniqueNumber = txtVendorUniqueNumber.Text,
				Owner = new ImportOrderRequest.User
				{
					Login = txtLogin.Text,
					SiteSlug = txtSiteSlug.Text
				}
			};
			restClient.ImportOrder(request);
		}

		private void DlgImportOrder_Load(object sender, EventArgs e)
		{

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}


	}
}
