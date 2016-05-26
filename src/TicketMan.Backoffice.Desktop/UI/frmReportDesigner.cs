using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UserDesigner;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Api.Shared;
using System.IO;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmReportDesigner : XtraForm
	{
		private CommandBarItem _commandBarItemSaveToServer;
		private BarButtonItem _barButtonItemSaveCopyToServer;
		private BarButtonItem _barButtonItemSaveToServer;
		ReportTemplate _template;
		private bool _copyAsNew;

		public FrmReportDesigner(ReportTemplateInfo info, bool copyAsNew)
		{
			InitializeComponent();
			LoadReport(info);
			_copyAsNew = copyAsNew;
		}



		public void OpenReport(DevExpress.XtraReports.UI.XtraReport newReport)
		{
			xrDesignMdiController1.OpenReport(newReport);
		}
		public void CreateNewReport()
		{
			xrDesignMdiController1.CreateNewReport();
		}
		public XRDesignPanel ActiveXRDesignPanel
		{
			get { return xrDesignMdiController1.ActiveDesignPanel; }
		}

		void LoadReport(ReportTemplateInfo info)
		{
			_template = DataProcessor.GetReportTemplate(info.TypeCodes[0], info.Code);
			DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromStream(new System.IO.MemoryStream(_template.TemplateContent, true), true);
			xrDesignMdiController1.OpenReport(report);
			//template.
		}

		private void SaveCopyToServer()
		{
			var dlg = new DlgSaveReportTemplate(Guid.NewGuid().ToString(), _template.TypeCodes, _template.Name + " Copy");
			dlg.ShowDialog();
			if (dlg.DialogResult == DialogResult.OK)
			{
				var newtemplate = new ReportTemplate(dlg.name, dlg.TypeCodes, dlg.code);
				var stream = new MemoryStream();
				xrDesignMdiController1.ActiveDesignPanel.Report.SaveLayout(stream);
				newtemplate.TemplateContent = stream.ToArray();
				var restClient = (ReportsRestClient)DataProcessor.GetRestClient("ReportsRestClient");
				restClient.SaveReportTemplate(newtemplate);
			}
		}

		private void SaveToServer()
		{
			var stream = new MemoryStream();
			xrDesignMdiController1.ActiveDesignPanel.Report.SaveLayout(stream);
			_template.TemplateContent = stream.ToArray();
			var restClient = (ReportsRestClient)DataProcessor.GetRestClient("ReportsRestClient");
			restClient.SaveReportTemplate(_template);
		}

		private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
		{
			SaveCopyToServer();
		}

		private void _barButtonItemSaveToServer_ItemClick(object sender, ItemClickEventArgs e)
		{
			SaveToServer();
		}

		private void FrmReportDesigner_Load(object sender, EventArgs e)
		{
			_barButtonItemSaveToServer.Enabled = !_copyAsNew;
			//_barButtonItemSaveToServer.Visibility = _copyAsNew ? BarItemVisibility.Never : BarItemVisibility.Always;

		}

	}
}
