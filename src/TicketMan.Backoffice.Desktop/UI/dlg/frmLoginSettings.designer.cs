namespace TicketMan.Backoffice.Desktop
{
  partial class FrmLoginSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoginSettings));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApiKey = new DevExpress.XtraEditors.TextEdit();
            this.txtSiteSlug = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUrl = new DevExpress.XtraEditors.TextEdit();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.cbSiteSlug = new DevExpress.XtraEditors.LookUpEdit();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtApiKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteSlug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSiteSlug.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "SiteSlug";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "ApiKey";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApiKey.Location = new System.Drawing.Point(88, 70);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Properties.PasswordChar = '*';
            this.txtApiKey.Size = new System.Drawing.Size(275, 22);
            this.txtApiKey.TabIndex = 4;
            // 
            // txtSiteSlug
            // 
            this.txtSiteSlug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiteSlug.Location = new System.Drawing.Point(88, 42);
            this.txtSiteSlug.Name = "txtSiteSlug";
            this.txtSiteSlug.Size = new System.Drawing.Size(275, 22);
            this.txtSiteSlug.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(291, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Url";
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(88, 98);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(275, 22);
            this.txtUrl.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Image = global::TicketMan.Backoffice.Desktop.Properties.Resources.plus_icon;
            this.btnCreate.Location = new System.Drawing.Point(310, 11);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(23, 23);
            this.btnCreate.TabIndex = 57;
            this.btnCreate.ToolTip = "Добавить";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::TicketMan.Backoffice.Desktop.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(339, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 59;
            this.btnDelete.ToolTip = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbSiteSlug
            // 
            this.cbSiteSlug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSiteSlug.Location = new System.Drawing.Point(88, 12);
            this.cbSiteSlug.Name = "cbSiteSlug";
            this.cbSiteSlug.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSiteSlug.Properties.NullText = "";
            this.cbSiteSlug.Size = new System.Drawing.Size(212, 22);
            this.cbSiteSlug.TabIndex = 56;
            this.cbSiteSlug.EditValueChanged += new System.EventHandler(this.cbSiteSlug_EditValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(210, 136);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // FrmLoginSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(370, 178);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cbSiteSlug);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSiteSlug);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmLoginSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры входа в систему";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLoginSettings_FormClosed);
            this.Load += new System.EventHandler(this.FrmLoginSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtApiKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteSlug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSiteSlug.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.TextEdit txtApiKey;
		private DevExpress.XtraEditors.TextEdit txtSiteSlug;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.TextEdit txtUrl;
		private DevExpress.XtraEditors.SimpleButton btnCreate;
		private DevExpress.XtraEditors.SimpleButton btnDelete;
		private DevExpress.XtraEditors.LookUpEdit cbSiteSlug;
		private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
  }
}