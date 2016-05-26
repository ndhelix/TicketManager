namespace TicketMan.Backoffice.Desktop
{
  partial class FrmReportTemplates
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
						this.components = new System.ComponentModel.Container();
						System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportTemplates));
						this.gridReportTemplates = new DevExpress.XtraGrid.GridControl();
						this.ContextMenuTemplates = new System.Windows.Forms.ContextMenuStrip(this.components);
						this.MenuItemCopyAs = new System.Windows.Forms.ToolStripMenuItem();
						this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
						this.gridViewReportTemplates = new DevExpress.XtraGrid.Views.Grid.GridView();
						this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TicketMan.Backoffice.Desktop.WaitForm1), true, true);
						this.barManager = new DevExpress.XtraBars.BarManager(this.components);
						this.bar2 = new DevExpress.XtraBars.Bar();
						this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
						this.barButtonItemCopyReportTemplate = new DevExpress.XtraBars.BarButtonItem();
						this.barButtonItemEditReportTemplate = new DevExpress.XtraBars.BarButtonItem();
						this.bar3 = new DevExpress.XtraBars.Bar();
						this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
						this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
						this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
						this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
						this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
						this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
						this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
						((System.ComponentModel.ISupportInitialize)(this.gridReportTemplates)).BeginInit();
						this.ContextMenuTemplates.SuspendLayout();
						((System.ComponentModel.ISupportInitialize)(this.gridViewReportTemplates)).BeginInit();
						((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
						this.SuspendLayout();
						// 
						// gridReportTemplates
						// 
						this.gridReportTemplates.ContextMenuStrip = this.ContextMenuTemplates;
						this.gridReportTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
						this.gridReportTemplates.Location = new System.Drawing.Point(0, 24);
						this.gridReportTemplates.MainView = this.gridViewReportTemplates;
						this.gridReportTemplates.Name = "gridReportTemplates";
						this.gridReportTemplates.Size = new System.Drawing.Size(628, 389);
						this.gridReportTemplates.TabIndex = 0;
						this.gridReportTemplates.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewReportTemplates});
						// 
						// ContextMenuTemplates
						// 
						this.ContextMenuTemplates.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCopyAs,
            this.редактироватьToolStripMenuItem});
						this.ContextMenuTemplates.Name = "contextMenuOrder";
						this.ContextMenuTemplates.Size = new System.Drawing.Size(195, 48);
						this.ContextMenuTemplates.Text = "Отчеты";
						// 
						// MenuItemCopyAs
						// 
						this.MenuItemCopyAs.Name = "MenuItemCopyAs";
						this.MenuItemCopyAs.Size = new System.Drawing.Size(194, 22);
						this.MenuItemCopyAs.Text = "Копировать...";
						this.MenuItemCopyAs.Click += new System.EventHandler(this.MenuItemCopyAs_Click);
						// 
						// редактироватьToolStripMenuItem
						// 
						this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
						this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
						this.редактироватьToolStripMenuItem.Text = "Редактировать...";
						this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
						// 
						// gridViewReportTemplates
						// 
						this.gridViewReportTemplates.GridControl = this.gridReportTemplates;
						this.gridViewReportTemplates.Name = "gridViewReportTemplates";
						this.gridViewReportTemplates.OptionsView.ShowGroupPanel = false;
						// 
						// barManager
						// 
						this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
						this.barManager.DockControls.Add(this.barDockControlTop);
						this.barManager.DockControls.Add(this.barDockControlBottom);
						this.barManager.DockControls.Add(this.barDockControlLeft);
						this.barManager.DockControls.Add(this.barDockControlRight);
						this.barManager.Form = this;
						this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barButtonItemCopyReportTemplate,
            this.barButtonItemEditReportTemplate,
            this.barSubItem2,
            this.barSubItem3,
            this.barButtonItem1});
						this.barManager.MainMenu = this.bar2;
						this.barManager.MaxItemId = 7;
						this.barManager.StatusBar = this.bar3;
						// 
						// bar2
						// 
						this.bar2.BarName = "Main menu";
						this.bar2.DockCol = 0;
						this.bar2.DockRow = 0;
						this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
						this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
						this.bar2.OptionsBar.MultiLine = true;
						this.bar2.OptionsBar.UseWholeRow = true;
						this.bar2.Text = "Main menu";
						// 
						// barSubItem1
						// 
						this.barSubItem1.Caption = "Правка";
						this.barSubItem1.Id = 1;
						this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCopyReportTemplate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemEditReportTemplate)});
						this.barSubItem1.Name = "barSubItem1";
						// 
						// barButtonItemCopyReportTemplate
						// 
						this.barButtonItemCopyReportTemplate.Caption = "Копировать...";
						this.barButtonItemCopyReportTemplate.Id = 2;
						this.barButtonItemCopyReportTemplate.Name = "barButtonItemCopyReportTemplate";
						this.barButtonItemCopyReportTemplate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCopyReportTemplate_ItemClick);
						// 
						// barButtonItemEditReportTemplate
						// 
						this.barButtonItemEditReportTemplate.Caption = "Редактировать...";
						this.barButtonItemEditReportTemplate.Id = 3;
						this.barButtonItemEditReportTemplate.Name = "barButtonItemEditReportTemplate";
						this.barButtonItemEditReportTemplate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemEditReportTemplate_ItemClick);
						// 
						// bar3
						// 
						this.bar3.BarName = "Status bar";
						this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
						this.bar3.DockCol = 0;
						this.bar3.DockRow = 0;
						this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
						this.bar3.OptionsBar.AllowQuickCustomization = false;
						this.bar3.OptionsBar.DrawDragBorder = false;
						this.bar3.OptionsBar.UseWholeRow = true;
						this.bar3.Text = "Status bar";
						this.bar3.Visible = false;
						// 
						// barDockControlTop
						// 
						this.barDockControlTop.CausesValidation = false;
						this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
						this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
						this.barDockControlTop.Size = new System.Drawing.Size(628, 24);
						// 
						// barDockControlBottom
						// 
						this.barDockControlBottom.CausesValidation = false;
						this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
						this.barDockControlBottom.Location = new System.Drawing.Point(0, 413);
						this.barDockControlBottom.Size = new System.Drawing.Size(628, 23);
						// 
						// barDockControlLeft
						// 
						this.barDockControlLeft.CausesValidation = false;
						this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
						this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
						this.barDockControlLeft.Size = new System.Drawing.Size(0, 389);
						// 
						// barDockControlRight
						// 
						this.barDockControlRight.CausesValidation = false;
						this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
						this.barDockControlRight.Location = new System.Drawing.Point(628, 24);
						this.barDockControlRight.Size = new System.Drawing.Size(0, 389);
						// 
						// barSubItem2
						// 
						this.barSubItem2.Caption = "Данные";
						this.barSubItem2.Id = 4;
						this.barSubItem2.Name = "barSubItem2";
						// 
						// barSubItem3
						// 
						this.barSubItem3.Caption = "Данные";
						this.barSubItem3.Id = 5;
						this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
						this.barSubItem3.Name = "barSubItem3";
						// 
						// barButtonItem1
						// 
						this.barButtonItem1.Caption = "Обновить";
						this.barButtonItem1.Id = 6;
						this.barButtonItem1.Name = "barButtonItem1";
						this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
						// 
						// FrmReportTemplates
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.ClientSize = new System.Drawing.Size(628, 436);
						this.Controls.Add(this.gridReportTemplates);
						this.Controls.Add(this.barDockControlLeft);
						this.Controls.Add(this.barDockControlRight);
						this.Controls.Add(this.barDockControlBottom);
						this.Controls.Add(this.barDockControlTop);
						this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
						this.Name = "FrmReportTemplates";
						this.Text = "Шаблоны отчетов";
						this.Load += new System.EventHandler(this.frmReportTemplates_Load);
						((System.ComponentModel.ISupportInitialize)(this.gridReportTemplates)).EndInit();
						this.ContextMenuTemplates.ResumeLayout(false);
						((System.ComponentModel.ISupportInitialize)(this.gridViewReportTemplates)).EndInit();
						((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
						this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridReportTemplates;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewReportTemplates;
    private System.Windows.Forms.ContextMenuStrip ContextMenuTemplates;
		private System.Windows.Forms.ToolStripMenuItem MenuItemCopyAs;
		private DevExpress.XtraBars.BarManager barManager;
		private DevExpress.XtraBars.Bar bar2;
		private DevExpress.XtraBars.BarSubItem barSubItem1;
		private DevExpress.XtraBars.BarButtonItem barButtonItemCopyReportTemplate;
		private DevExpress.XtraBars.BarButtonItem barButtonItemEditReportTemplate;
		private DevExpress.XtraBars.Bar bar3;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
		private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
		private DevExpress.XtraBars.BarSubItem barSubItem3;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private DevExpress.XtraBars.BarSubItem barSubItem2;
  }
}