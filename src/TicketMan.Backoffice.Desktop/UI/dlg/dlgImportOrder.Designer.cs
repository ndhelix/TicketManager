namespace TicketMan.Backoffice.Desktop.UI.dlg
{
  partial class DlgImportOrder
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgImportOrder));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtVendorUniqueNumber = new DevExpress.XtraEditors.TextEdit();
			this.txtSiteSlug = new DevExpress.XtraEditors.TextEdit();
			this.txtLogin = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.txtVendorUniqueNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSiteSlug.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(166, 116);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(66, 27);
			this.btnCancel.TabIndex = 25;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(94, 116);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(67, 27);
			this.btnOK.TabIndex = 22;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Внешний номер";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "SiteSlug";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Логин";
			// 
			// txtVendorUniqueNumber
			// 
			this.txtVendorUniqueNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtVendorUniqueNumber.Location = new System.Drawing.Point(123, 10);
			this.txtVendorUniqueNumber.Name = "txtVendorUniqueNumber";
			this.txtVendorUniqueNumber.Size = new System.Drawing.Size(107, 22);
			this.txtVendorUniqueNumber.TabIndex = 3;
			// 
			// txtSiteSlug
			// 
			this.txtSiteSlug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSiteSlug.Location = new System.Drawing.Point(70, 38);
			this.txtSiteSlug.Name = "txtSiteSlug";
			this.txtSiteSlug.Size = new System.Drawing.Size(160, 22);
			this.txtSiteSlug.TabIndex = 9;
			// 
			// txtLogin
			// 
			this.txtLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLogin.Location = new System.Drawing.Point(70, 68);
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(160, 22);
			this.txtLogin.TabIndex = 13;
			// 
			// DlgImportOrder
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(242, 151);
			this.Controls.Add(this.txtLogin);
			this.Controls.Add(this.txtSiteSlug);
			this.Controls.Add(this.txtVendorUniqueNumber);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DlgImportOrder";
			this.Text = "Импорт заявки";
			this.Load += new System.EventHandler(this.DlgImportOrder_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtVendorUniqueNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSiteSlug.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label3;
	private DevExpress.XtraEditors.TextEdit txtVendorUniqueNumber;
	private DevExpress.XtraEditors.TextEdit txtSiteSlug;
	private DevExpress.XtraEditors.TextEdit txtLogin;
  }
}