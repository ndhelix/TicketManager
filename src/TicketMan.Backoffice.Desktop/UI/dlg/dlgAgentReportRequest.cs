using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TicketMan.Platform.Api.Shared.Protocol.Requests;

namespace TicketMan.Backoffice.Desktop.UI.dlg
{
	public partial class DlgAgentReportRequest : XtraForm
	{
		private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
		string _orgcode;

		public DlgAgentReportRequest(string orgcode)
		{
			InitializeComponent();
			this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TicketMan.Backoffice.Desktop.WaitForm1), true, true);

			_orgcode = orgcode;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var agencyReportRequest = new AgencyReportRequest();
			agencyReportRequest.ServiceType = "flights";
			agencyReportRequest.OrganizationCode = _orgcode;
			agencyReportRequest.BeginDate = calFrom.DateTime;
			agencyReportRequest.EndDate = calTo.DateTime;

			splashScreenManager1.ShowWaitForm();
			try
			{
				DataProcessor.CreateReport(null, cbFormat.EditValue.ToString(), null, "agentreport", agencyReportRequest);
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}

			this.DialogResult = DialogResult.OK;
		}

		private void DlgAgentReportRequest_Load(object sender, EventArgs e)
		{
			calTo.DateTime = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
			calFrom.DateTime = DateTime.Now.Date.AddMonths(-1).AddDays(1);

			cbFormat.Properties.DataSource = ApiUtils.GetReportFormats();
			cbFormat.Properties.ValueMember = "Code";
			cbFormat.Properties.DisplayMember = "Title";
			cbFormat.EditValue = "Pdf";
			cbFormat.Properties.ShowHeader = false;
		}
	}
}
