namespace TicketMan.Backoffice.Desktop.UI
{
	partial class FrmPosting
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPosting));
			this.panelUpper = new DevExpress.XtraEditors.PanelControl();
			this.txtOrderNumber = new DevExpress.XtraEditors.TextEdit();
			this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.groupControl9 = new DevExpress.XtraEditors.GroupControl();
			this.gridDeals = new DevExpress.XtraGrid.GridControl();
			this.gridViewDeals = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnSavePayment = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.panelUpper)).BeginInit();
			this.panelUpper.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtOrderNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl9)).BeginInit();
			this.groupControl9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDeals)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewDeals)).BeginInit();
			this.SuspendLayout();
			// 
			// panelUpper
			// 
			this.panelUpper.Controls.Add(this.txtOrderNumber);
			this.panelUpper.Controls.Add(this.btnRefresh);
			this.panelUpper.Controls.Add(this.labelControl1);
			this.panelUpper.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelUpper.Location = new System.Drawing.Point(0, 0);
			this.panelUpper.Name = "panelUpper";
			this.panelUpper.Size = new System.Drawing.Size(439, 49);
			this.panelUpper.TabIndex = 0;
			// 
			// txtOrderNumber
			// 
			this.txtOrderNumber.Location = new System.Drawing.Point(96, 12);
			this.txtOrderNumber.Name = "txtOrderNumber";
			this.txtOrderNumber.Properties.MaxLength = 6;
			this.txtOrderNumber.Size = new System.Drawing.Size(79, 22);
			this.txtOrderNumber.TabIndex = 13;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Image = global::TicketMan.Backoffice.Desktop.Properties.Resources.search_icon;
			this.btnRefresh.Location = new System.Drawing.Point(354, 11);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(73, 23);
			this.btnRefresh.TabIndex = 12;
			this.btnRefresh.Text = "Найти";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(9, 15);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(81, 16);
			this.labelControl1.TabIndex = 11;
			this.labelControl1.Text = "Номер заявки";
			// 
			// groupControl9
			// 
			this.groupControl9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupControl9.CaptionImage = global::TicketMan.Backoffice.Desktop.Properties.Resources.deal;
			this.groupControl9.Controls.Add(this.gridDeals);
			this.groupControl9.Location = new System.Drawing.Point(0, 49);
			this.groupControl9.Name = "groupControl9";
			this.groupControl9.Size = new System.Drawing.Size(439, 226);
			this.groupControl9.TabIndex = 6;
			this.groupControl9.Text = "Сделки";
			// 
			// gridDeals
			// 
			this.gridDeals.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridDeals.Location = new System.Drawing.Point(2, 24);
			this.gridDeals.MainView = this.gridViewDeals;
			this.gridDeals.Name = "gridDeals";
			this.gridDeals.Size = new System.Drawing.Size(435, 200);
			this.gridDeals.TabIndex = 5;
			this.gridDeals.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDeals});
			// 
			// gridViewDeals
			// 
			this.gridViewDeals.GridControl = this.gridDeals;
			this.gridViewDeals.Name = "gridViewDeals";
			this.gridViewDeals.OptionsView.ShowGroupPanel = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.CausesValidation = false;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(342, 281);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(85, 23);
			this.btnCancel.TabIndex = 100;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSavePayment
			// 
			this.btnSavePayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSavePayment.Location = new System.Drawing.Point(254, 281);
			this.btnSavePayment.Name = "btnSavePayment";
			this.btnSavePayment.Size = new System.Drawing.Size(82, 23);
			this.btnSavePayment.TabIndex = 101;
			this.btnSavePayment.Text = "Разнести";
			// 
			// FrmPosting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(439, 316);
			this.Controls.Add(this.btnSavePayment);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupControl9);
			this.Controls.Add(this.panelUpper);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmPosting";
			this.Text = "Разноска заявки";
			((System.ComponentModel.ISupportInitialize)(this.panelUpper)).EndInit();
			this.panelUpper.ResumeLayout(false);
			this.panelUpper.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtOrderNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl9)).EndInit();
			this.groupControl9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridDeals)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewDeals)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl panelUpper;
		private DevExpress.XtraEditors.TextEdit txtOrderNumber;
		private DevExpress.XtraEditors.SimpleButton btnRefresh;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.GroupControl groupControl9;
		private DevExpress.XtraGrid.GridControl gridDeals;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewDeals;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnSavePayment;
	}
}