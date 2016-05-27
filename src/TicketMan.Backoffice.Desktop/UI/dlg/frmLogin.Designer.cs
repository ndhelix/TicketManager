namespace TicketMan.Backoffice.Desktop
{
  partial class FrmLogin
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPassword = new DevExpress.XtraEditors.TextEdit();
			this.txtLogin = new DevExpress.XtraEditors.TextEdit();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnSettings = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.cbSiteSlug = new DevExpress.XtraEditors.LookUpEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.chRememberPassword = new DevExpress.XtraEditors.CheckEdit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbSiteSlug.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chRememberPassword.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 132);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Логин";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 160);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Пароль";
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.Location = new System.Drawing.Point(74, 157);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Properties.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(286, 22);
			this.txtPassword.TabIndex = 3;
			// 
			// txtLogin
			// 
			this.txtLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLogin.Location = new System.Drawing.Point(74, 129);
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(286, 22);
			this.txtLogin.TabIndex = 2;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(210, 214);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(71, 30);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(288, 214);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(71, 30);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSettings
			// 
			this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSettings.FlatAppearance.BorderSize = 0;
			this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSettings.Image = global::TicketMan.Backoffice.Desktop.Properties.Resources.settings;
			this.btnSettings.Location = new System.Drawing.Point(10, 214);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(26, 30);
			this.btnSettings.TabIndex = 5;
			this.toolTip1.SetToolTip(this.btnSettings, "Параметры");
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::TicketMan.Backoffice.Desktop.Properties.Resources.TicketMan_logo;
			this.pictureBox1.Location = new System.Drawing.Point(20, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(340, 69);
			this.pictureBox1.TabIndex = 13;
			this.pictureBox1.TabStop = false;
			// 
			// cbSiteSlug
			// 
			this.cbSiteSlug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSiteSlug.Location = new System.Drawing.Point(74, 101);
			this.cbSiteSlug.Name = "cbSiteSlug";
			this.cbSiteSlug.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbSiteSlug.Size = new System.Drawing.Size(212, 22);
			this.cbSiteSlug.TabIndex = 100;
			this.cbSiteSlug.EditValueChanged += new System.EventHandler(this.cbSiteSlug_EditValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 57;
			this.label3.Text = "SiteSlug";
			// 
			// chRememberPassword
			// 
			this.chRememberPassword.Location = new System.Drawing.Point(16, 185);
			this.chRememberPassword.Name = "chRememberPassword";
			this.chRememberPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.chRememberPassword.Properties.Appearance.Options.UseFont = true;
			this.chRememberPassword.Properties.Caption = "Запомнить пароль";
			this.chRememberPassword.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.chRememberPassword.Size = new System.Drawing.Size(136, 21);
			this.chRememberPassword.TabIndex = 4;
			// 
			// FrmLogin
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(370, 256);
			this.Controls.Add(this.chRememberPassword);
			this.Controls.Add(this.cbSiteSlug);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtLogin);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FrmLogin";
			this.Text = "Вход в систему";
			this.Load += new System.EventHandler(this.FrmLogin_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbSiteSlug.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chRememberPassword.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit txtPassword;
		private DevExpress.XtraEditors.TextEdit txtLogin;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private DevExpress.XtraEditors.LookUpEdit cbSiteSlug;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.CheckEdit chRememberPassword;
  }
}