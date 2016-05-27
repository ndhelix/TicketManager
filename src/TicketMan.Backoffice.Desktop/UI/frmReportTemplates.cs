using System;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;


namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmReportTemplates : DevExpress.XtraEditors.XtraForm
	{
		private static FrmReportTemplates _aForm = null;

		public static FrmReportTemplates Instance() //singleton
		{
			if (_aForm == null)
			{
				_aForm = new FrmReportTemplates();
			}
			return _aForm;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
			_aForm = null;
		}

		public FrmReportTemplates()
		{
			InitializeComponent();
		}

		private void frmReportTemplates_Load(object sender, EventArgs e)
		{
			RefreshTemplates();
		}

		void RefreshTemplates(bool reload = false)
		{
			splashScreenManager1.ShowWaitForm();
			gridReportTemplates.DataSource = Persistence.GetReportTemplatesInfo(reload);
			gridViewReportTemplates.Columns[0].Caption = "Код";
			gridViewReportTemplates.Columns[1].Caption = "Наименование";
			splashScreenManager1.CloseWaitForm();
		}

		private void MenuItemCopyAs_Click(object sender, EventArgs e)
		{
			CopyReportTemplate(true);
		}

		private void CopyReportTemplate(bool copyAsNew)
		{
			var o = gridViewReportTemplates.GetRow(gridViewReportTemplates.FocusedRowHandle);
			if (!(o is ReportTemplateInfo)) return;
			var r = o as ReportTemplateInfo;
			splashScreenManager1.ShowWaitForm();
			var form = new FrmReportDesigner(r, copyAsNew);
			form.Show();
			splashScreenManager1.CloseWaitForm();
		}

		private void barButtonItemCopyReportTemplate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			CopyReportTemplate(true);
		}

		private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyReportTemplate(false);
		}

		private void barButtonItemEditReportTemplate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			CopyReportTemplate(false);
		}

		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			RefreshTemplates(true);
		}
	}
}