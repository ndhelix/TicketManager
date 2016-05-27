using System;
using System.Reflection;
using System.Windows.Forms;
using TicketMan.Backoffice.Desktop.UI.dlg;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using DevExpress.Utils.Win;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using TicketMan.Backoffice.Desktop.Decorators;
using DevExpress.XtraTreeList.Nodes;
using System.Drawing;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmMain : XtraForm
	{
		bool _ccboOrderStatusPopupOkClickSet;
		bool _firstload = true;

		public FrmMain()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			SetSizes();
			//BindOrderFilter();
			ccboOrderStatus.CheckAll();
			cbIgnoreBuyerFilter_CheckedChanged(null, null);
			//CreateMenus();
			//RefreshData();
		}


		private void SetSizes() //this method handles strange width behaviour on different PC's
		{
            barManager.ForceInitialize();
		    DevExpress.XtraBars.Controls.CustomBarControl barControl = bar2.GetBarControl();
            int bar2height = barControl.Size.Height;
            barControl = bar3.GetBarControl();
            int bar3height = barControl.Size.Height;

            //int gridheight = this.Size.Height - panelOrderFilter.Size.Height - bar2height * 2 - bar3height * 3;
            int gridheight = this.Size.Height - panelForGridOrder.Top - bar3height*5 + 10;
            int width = this.Size.Width - treeBuyers.Size.Width - 30;
            panelForGridOrder.Size = new Size(width, gridheight);
            panelForOrderFIlter.Size = new Size(width, panelOrderFilter.Size.Height);
            treeBuyers.Size = new Size(treeBuyers.Size.Width, panelForGridOrder.Size.Height + btnRefresh.Size.Height);
        }

		void BindOrderFilter()
		{
			ccboOrderStatus.Properties.DataSource = new EnumDecorator<OrderStatus>().list;//Enum.GetValues(typeof(OrderStatus));
			ccboOrderStatus.Properties.ValueMember = "Value";
			ccboOrderStatus.Properties.DisplayMember = "Caption";
			splashScreenManager1.ShowWaitForm();
			treeBuyers.DataSource = Persistence.GetBuyers();
			treeBuyers.Columns[2].Visible =false;
			splashScreenManager1.CloseWaitForm();
		}

		void RefreshOrders()
		{
			var ordersInfoRequest = GetOrdersInfoRequest();
			splashScreenManager1.ShowWaitForm();
			try
			{
				gridOrders.DataSource = DataProcessor.GetOrders(ordersInfoRequest);
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}
			btnRefreshOrdersIndicator.Visible = false;
		}

		void RefreshPaymentReports()
		{
			splashScreenManager1.ShowWaitForm();
			gridPaymentReports.DataSource = DataProcessor.GetPaymentReports(GetPaymentReportsRequest());
			splashScreenManager1.CloseWaitForm();
		}

		void RefreshData()
		{
			RefreshOrders();
			RefreshPaymentReports();
			RefreshOrganizations();
			//RefreshPayments();
			UpdateRecordCount();
		}

		private void RefreshOrganizations()
		{
			splashScreenManager1.ShowWaitForm();
			gridOrganizations.DataSource = Persistence.GetBuyers(true);
			splashScreenManager1.CloseWaitForm();
		}

		private void RefreshUsers()
		{
			splashScreenManager1.ShowWaitForm();
			gridUsers.DataSource = DataProcessor.GetUsers();
			splashScreenManager1.CloseWaitForm();
		}
        
		private void RefreshPayments()
		{
			splashScreenManager1.ShowWaitForm();
			gridPayments.DataSource = DataProcessor.GetPayments();
			splashScreenManager1.CloseWaitForm();
		}

        private void RefreshAgenciesUsers()
        {
            splashScreenManager1.ShowWaitForm();
            gridAgenciesUsers.DataSource = DataProcessor.GetAgenciesUsers();
            splashScreenManager1.CloseWaitForm();
        }

        private void RefreshSites()
        {
            splashScreenManager1.ShowWaitForm();
            gridSites.DataSource = DataProcessor.GetSites();
            splashScreenManager1.CloseWaitForm();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RefreshData();
		}


		private void ccboOrderStatus_Popup(object sender, EventArgs e)
		{
			if (!_ccboOrderStatusPopupOkClickSet)
				foreach (Control c in ((IPopupControl)sender).PopupWindow.Controls)
					if (c is DevExpress.XtraEditors.SimpleButton)
						if (c.Text == "OK" || c.Text == "ОК")
						{
							SimpleButton sb = (SimpleButton)c;
							sb.Click += new EventHandler(sb_Click);
							_ccboOrderStatusPopupOkClickSet = true;
						}
		}

		void sb_Click(object sender, EventArgs e)
		{
			RefreshCurrentTab();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			RefreshCurrentTab();
		}

		private void cbIgnoreBuyerFilter_CheckedChanged(object sender, EventArgs e)
		{
			treeBuyers.Enabled = !cbIgnoreBuyerFilter.Checked;
			btnRefreshOrdersIndicator.Visible = true;
		}



		private void dateRangeControl_Orders_DateRangeChanged(object sender, EventArgs e)
		{
			if (_firstload) // splashScreenManager1.ShowWaitForm() halts for unknown reason
			{
				_firstload = false;
				return;
			}

			RefreshCurrentTab();
			gridOrders.Focus();

		}

		private void btnRefreshPaymentReports_Click(object sender, EventArgs e)
		{
			RefreshPaymentReports();
		}

		private void dateRangeControl_PaymentReports_DateRangeChanged(object sender, EventArgs e)
		{
			RefreshCurrentTab();
			gridPaymentReports.Focus();
		}


		private void btnCreateOrganization_Click(object sender, EventArgs e)
		{

		}

		private void btnRefreshOrganizations_Click(object sender, EventArgs e)
		{
			RefreshCurrentTab();
		}

		private void barButtonItemReportTemplates_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			FrmReportTemplates.Instance().Show();
		}

		private void gridPaymentReports_DoubleClick(object sender, EventArgs e)
		{
			PaymentReportShow();
		}

		private void PaymentReportShow()
		{
			object o = gridViewPaymentReports.GetRow(gridViewPaymentReports.FocusedRowHandle);
			if (o is PaymentReportInfoDecorator)
			{
				var od = o as PaymentReportInfoDecorator;
				new FrmPaymentReport(od.UniqueNumber).Show();
				//new FrmPaymentReport(od.OrderUniqueNumber).Show();
			}
		}

		private void gridOrders_DoubleClick(object sender, EventArgs e)
		{
			OrderShow();
		}

		private void OrderShow()
		{
			object o = gridViewOrders.GetRow(gridViewOrders.FocusedRowHandle);
			if (o is OrderInfoDecorator)
			{
				var od = o as OrderInfoDecorator;
				new FrmOrder(od.UniqueNumber).Show();
			}
		}

		private void показатьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OrderShow();
		}

		private void treeBuyers_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
		{
			e.Node.Selected = e.Node.Checked;
			btnRefreshOrdersIndicator.Visible = true;
		}

		private void treeBuyers_SelectionChanged(object sender, EventArgs e)
		{
			foreach (TreeListNode node in treeBuyers.Nodes)
			{
				node.Checked = node.Selected;
			}
			btnRefreshOrdersIndicator.Visible = true;
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			RefreshCurrentTab();
		}

		private void txtOrderNumberFilter_EditValueChanged(object sender, EventArgs e)
		{
			SetOrderFilterCommonGroup(txtOrderNumberFilter.Text == "");
		}

		private void txtOrderNumberFilter_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				RefreshCurrentTab();
			}
		}

		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			new FrmAbout().ShowDialog();
		}

		private void MenuItemAgentReport_Click(object sender, EventArgs e)
		{
			var o = gridViewOrganizations.GetRow(gridViewOrganizations.FocusedRowHandle);
			if (!(o is OrganizationInfoDecorator)) return;
			var od = o as OrganizationInfoDecorator;
			new UI.dlg.DlgAgentReportRequest(od.Code).ShowDialog();
		}

		private void btnRefreshPayments_Click(object sender, EventArgs e)
		{
			RefreshCurrentTab();
		}

		private void btnCreateOrganization_Click_1(object sender, EventArgs e)
		{
			new FrmOrganization("").Show();
		}

		private void btnRefreshUsers_Click(object sender, EventArgs e)
		{
			RefreshCurrentTab();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			UserShow();
		}

		private void menuItemCreatePaymentFromOrg_Click(object sender, EventArgs e)
		{
			CreatePaymentFromOrg();
		}

		private void menuItemEditPayment_Click(object sender, EventArgs e)
		{
			PaymentShow();
		}

		private void gridOrganizations_DoubleClick(object sender, EventArgs e)
		{
			OrganizationShow();
		}

		private void gridPayments_DoubleClick(object sender, EventArgs e)
		{
			PaymentShow();
		}

		private void gridUsers_DoubleClick(object sender, EventArgs e)
		{
			UserShow();
		}

		private void menuItemCreatePaymentFromUser_Click(object sender, EventArgs e)
		{
			CreatePaymentFromUser();
		}

		private void btnCreateUser_Click(object sender, EventArgs e)
		{
			new FrmUser("").Show();
		}

		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			new FrmOrganization("").Show();
		}

		private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			new FrmUser("").Show();
		}

		private void barButtonItemImportOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			new DlgImportOrder().Show();
		}

		private void UpdateRecordCount()
		{
			int recordCount = 0;
			if (xtraTabControl1.SelectedTabPage == xtraTabPage_Orders)
				recordCount = gridViewOrders.RowCount;
			if (xtraTabControl1.SelectedTabPage == xtraTabPagePaymentReports)
				recordCount = gridViewPaymentReports.RowCount;
			if (xtraTabControl1.SelectedTabPage == xtraTabPageOrganizations)
				recordCount = gridViewOrganizations.RowCount;
			if (xtraTabControl1.SelectedTabPage == xtraTabPageUsers)
				recordCount = gridViewUsers.RowCount;
            if (xtraTabControl1.SelectedTabPage == xtraTabPagePayments)
                recordCount = gridViewPayments.RowCount;
            if (xtraTabControl1.SelectedTabPage == xtraTabPageAgenciesUsers)
                recordCount = gridViewAgenciesUsers.RowCount;
            if (xtraTabControl1.SelectedTabPage == xtraTabPageSites)
                recordCount = gridViewSites.RowCount;
            barStaticItemRecordCount.Caption = "Записей: " + recordCount;
		}

		
		private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			UpdateRecordCount();
		}

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            RefreshCurrentTab();
        }

        private void создатьСайтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSiteFromOrg();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiteShow();
        }

        private void создатьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUserFromSite();
        }

        
	}
}
