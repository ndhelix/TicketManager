using System;
using System.Linq;
using System.Windows.Forms;
using TicketMan.Backoffice.Desktop.Decorators;


namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmMain : DevExpress.XtraEditors.XtraForm
	{

		void CreateMenus()
		{
			splashScreenManager1.ShowWaitForm();
			CreateOrderReportMenu(MenuItemInInvoice);
			CreateOrderReportMenu(MenuItemOutInvoice);
			splashScreenManager1.CloseWaitForm();
		}


		ToolStripMenuItem[] GetMenuReportFormatItems()
		{
			var menuReportFormatItems = new ToolStripMenuItem[3];
			menuReportFormatItems[1] = new ToolStripMenuItem("Pdf (Adobe Reader)", null, MenuItemReport_Click) { Tag = "Pdf" };
			menuReportFormatItems[2] = new ToolStripMenuItem("Xls (Excel)", null, MenuItemReport_Click) { Tag = "Xls" };
			menuReportFormatItems[0] = new ToolStripMenuItem("Rtf (Word)", null, MenuItemReport_Click) { Tag = "Rtf" };
			return menuReportFormatItems;
		}

		void CreateOrderReportMenu(ToolStripMenuItem menuitem)
		{
			var linfo = Persistence.GetReportTemplatesInfo();//.Where(x => x.TypeCodes.Contains("ininvoice"));
			//var itemdef = new ToolStripMenuItem("По умолчанию", null, GetMenuReportFormatItems());
			//menuitem.DropDownItems.Add(itemdef);
			foreach (var info in linfo)
			{
				var item = new ToolStripMenuItem(info.Name, null, GetMenuReportFormatItems()) { Tag = info.Code };
				menuitem.DropDownItems.Add(item);
			}
		}

		private void MenuItemReport_Click(object sender, EventArgs e)
		{
			object o = gridViewOrders.GetRow(gridViewOrders.FocusedRowHandle);
			if (o is OrderInfoDecorator)
			{
				var od = o as OrderInfoDecorator;
				var item = ((ToolStripMenuItem)sender);
				var parent = (ToolStripMenuItem)item.OwnerItem;
				var grandparent = (ToolStripMenuItem)parent.OwnerItem;
				var templatecode = parent.Tag == null ? null : parent.Tag.ToString();
				splashScreenManager1.ShowWaitForm();
				try
				{
					DataProcessor.CreateReport(od.UniqueNumber, item.Tag.ToString(), templatecode
						, grandparent.Tag.ToString(), null);
				}
				finally
				{
					splashScreenManager1.CloseWaitForm();
				}
			}
		}

		private void ToolStripMenuItemEditOrganization_Click(object sender, EventArgs e)
		{
			OrganizationShow();
		}

		private void OrganizationShow()
		{
			var o = gridViewOrganizations.GetRow(gridViewOrganizations.FocusedRowHandle);
			if (!(o is OrganizationInfoDecorator)) return;
			var od = o as OrganizationInfoDecorator;
			new FrmOrganization(od.Code).Show();
		}

        private void CreatePaymentFromOrg()
        {
            var o = gridViewOrganizations.GetRow(gridViewOrganizations.FocusedRowHandle);
            if (!(o is OrganizationInfoDecorator)) return;
            var od = o as OrganizationInfoDecorator;
            //new FrmPayment("", od.PartyId, od.FullName).Show();
        }

        private void CreateSiteFromOrg()
        {
            var o = gridViewOrganizations.GetRow(gridViewOrganizations.FocusedRowHandle);
            if (!(o is OrganizationInfoDecorator)) return;
            var od = o as OrganizationInfoDecorator;
            new FrmSite("", od.Code).Show();
        }

        private void CreateUserFromSite()
        {
            var o = gridViewSites.GetRow(gridViewSites.FocusedRowHandle);
            if (!(o is SiteDecorator)) return;
            var od = o as SiteDecorator;
            new FrmUser("", od.SiteSlug).Show();
        }

        private void CreatePaymentFromUser()
		{
			var o = gridViewUsers.GetRow(gridViewUsers.FocusedRowHandle);
			if (!(o is UserDecorator)) return;
			var d = o as UserDecorator;
			//new FrmPayment("", d.PartyId, d.FirstName + " " + d.LastName).Show();
		}

		private void UserShow()
		{
		    DevExpress.XtraGrid.Views.Grid.GridView gridView;
            if (xtraTabControl1.SelectedTabPage == xtraTabPageUsers)
                gridView = gridViewUsers;
            else
                if (xtraTabControl1.SelectedTabPage == xtraTabPageAgenciesUsers)
                    gridView = gridViewAgenciesUsers;
                else return;

            var o = gridView.GetRow(gridView.FocusedRowHandle);
			if (!(o is UserDecorator)) return;
            if (o is AgencyUserDecorator)
            {
                var od = o as AgencyUserDecorator;
                new FrmUser(od.EmailAddress, od.SiteSlug).Show();
            }
            else
            {
                var od = o as UserDecorator;
                new FrmUser(od.EmailAddress).Show();
            }
		}

        private void PaymentShow()
        {
            var o = gridViewPayments.GetRow(gridViewPayments.FocusedRowHandle);
            if (!(o is PaymentDecorator)) return;
            var od = o as PaymentDecorator;
            //new FrmPayment(od.UniqueNumber).Show();
        }

        private void SiteShow()
        {
            var o = gridViewSites.GetRow(gridViewSites.FocusedRowHandle);
            if (!(o is SiteDecorator)) return;
            var od = o as SiteDecorator;
            new FrmSite(od.SiteSlug, od.OrganizationCode).Show();
        }

        private void показатьToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			PaymentReportShow();
		}

		private void barButtonItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			RefreshCurrentTab();
		}

		private void RefreshCurrentTab()
		{
			if (xtraTabControl1.SelectedTabPage == xtraTabPage_Orders)
				RefreshOrders();
			if (xtraTabControl1.SelectedTabPage == xtraTabPagePaymentReports)
				RefreshPaymentReports();
			if (xtraTabControl1.SelectedTabPage == xtraTabPageOrganizations)
				RefreshOrganizations();
			if (xtraTabControl1.SelectedTabPage == xtraTabPageUsers)
				RefreshUsers();
            if (xtraTabControl1.SelectedTabPage == xtraTabPagePayments)
                RefreshPayments();
            if (xtraTabControl1.SelectedTabPage == xtraTabPageAgenciesUsers)
                RefreshAgenciesUsers();
            if (xtraTabControl1.SelectedTabPage == xtraTabPageSites)
                RefreshSites();
            UpdateRecordCount();
		}


		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (xtraTabControl1.SelectedTabPage == xtraTabPage_Orders)
				OrderShow();
			if (xtraTabControl1.SelectedTabPage == xtraTabPagePaymentReports)
				PaymentReportShow();
			if (xtraTabControl1.SelectedTabPage == xtraTabPageOrganizations)
				OrganizationShow();
            if (xtraTabControl1.SelectedTabPage == xtraTabPageUsers || xtraTabControl1.SelectedTabPage == xtraTabPageAgenciesUsers)
				UserShow();
            if (xtraTabControl1.SelectedTabPage == xtraTabPagePayments)
                PaymentShow();
            if (xtraTabControl1.SelectedTabPage == xtraTabPageSites)
                SiteShow();
        }
	}
}