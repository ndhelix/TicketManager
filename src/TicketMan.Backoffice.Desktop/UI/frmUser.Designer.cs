namespace TicketMan.Backoffice.Desktop
{
		partial class FrmUser
		{
				/// <summary>
				/// Required designer variable.
				/// </summary>
				private System.ComponentModel.IContainer components = null;


				#region Windows Form Designer generated code

				/// <summary>
				/// Required method for Designer support - do not modify
				/// the contents of this method with the code editor.
				/// </summary>
				private void InitializeComponent()
				{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUser));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBoxPassword = new System.Windows.Forms.GroupBox();
            this.chSetPassword = new DevExpress.XtraEditors.CheckEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxOrganizationMember = new System.Windows.Forms.GroupBox();
            this.chRoleOn = new DevExpress.XtraEditors.CheckEdit();
            this.btnAgencySearch = new DevExpress.XtraEditors.SimpleButton();
            this.lblAgencyCode = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtAgencySearch = new DevExpress.XtraEditors.TextEdit();
            this.lblAgencyName = new DevExpress.XtraEditors.LabelControl();
            this.rbOrganizationMember = new System.Windows.Forms.RadioButton();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.txtPhoneNumbers = new DevExpress.XtraEditors.TextEdit();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSiteSlug = new DevExpress.XtraEditors.TextEdit();
            this.txtEmailAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnChangePassword = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangeLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveUser = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TicketMan.Backoffice.Desktop.WaitForm1), false, false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBoxPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chSetPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxOrganizationMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chRoleOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgencySearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNumbers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteSlug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailAddress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.CaptionImage = global::TicketMan.Backoffice.Desktop.Properties.Resources.icon_book;
            this.groupControl1.Controls.Add(this.groupBoxPassword);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.txtId);
            this.groupControl1.Controls.Add(this.txtPhoneNumbers);
            this.groupControl1.Controls.Add(this.txtLastName);
            this.groupControl1.Controls.Add(this.txtFirstName);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtSiteSlug);
            this.groupControl1.Controls.Add(this.txtEmailAddress);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(392, 455);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Общая информация";
            // 
            // groupBoxPassword
            // 
            this.groupBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPassword.Controls.Add(this.chSetPassword);
            this.groupBoxPassword.Controls.Add(this.txtPassword);
            this.groupBoxPassword.Location = new System.Drawing.Point(9, 388);
            this.groupBoxPassword.Name = "groupBoxPassword";
            this.groupBoxPassword.Size = new System.Drawing.Size(377, 55);
            this.groupBoxPassword.TabIndex = 43;
            this.groupBoxPassword.TabStop = false;
            this.groupBoxPassword.Text = "Пароль";
            // 
            // chSetPassword
            // 
            this.chSetPassword.Location = new System.Drawing.Point(6, 22);
            this.chSetPassword.Name = "chSetPassword";
            this.chSetPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chSetPassword.Properties.Appearance.Options.UseFont = true;
            this.chSetPassword.Properties.Caption = "Задать пароль";
            this.chSetPassword.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chSetPassword.Size = new System.Drawing.Size(116, 21);
            this.chSetPassword.TabIndex = 43;
            this.chSetPassword.CheckedChanged += new System.EventHandler(this.chSetPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(130, 21);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(241, 22);
            this.txtPassword.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBoxOrganizationMember);
            this.groupBox1.Controls.Add(this.rbOrganizationMember);
            this.groupBox1.Controls.Add(this.rbCustomer);
            this.groupBox1.Location = new System.Drawing.Point(9, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 189);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип";
            // 
            // groupBoxOrganizationMember
            // 
            this.groupBoxOrganizationMember.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOrganizationMember.Controls.Add(this.chRoleOn);
            this.groupBoxOrganizationMember.Controls.Add(this.btnAgencySearch);
            this.groupBoxOrganizationMember.Controls.Add(this.lblAgencyCode);
            this.groupBoxOrganizationMember.Controls.Add(this.labelControl5);
            this.groupBoxOrganizationMember.Controls.Add(this.txtAgencySearch);
            this.groupBoxOrganizationMember.Controls.Add(this.lblAgencyName);
            this.groupBoxOrganizationMember.Location = new System.Drawing.Point(29, 64);
            this.groupBoxOrganizationMember.Name = "groupBoxOrganizationMember";
            this.groupBoxOrganizationMember.Size = new System.Drawing.Size(342, 119);
            this.groupBoxOrganizationMember.TabIndex = 19;
            this.groupBoxOrganizationMember.TabStop = false;
            // 
            // chRoleOn
            // 
            this.chRoleOn.Location = new System.Drawing.Point(6, 90);
            this.chRoleOn.Name = "chRoleOn";
            this.chRoleOn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chRoleOn.Properties.Appearance.Options.UseFont = true;
            this.chRoleOn.Properties.Caption = "Разрешить выписывать и импортировать заявки";
            this.chRoleOn.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chRoleOn.Size = new System.Drawing.Size(315, 21);
            this.chRoleOn.TabIndex = 86;
            // 
            // btnAgencySearch
            // 
            this.btnAgencySearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgencySearch.Image = global::TicketMan.Backoffice.Desktop.Properties.Resources.search_icon;
            this.btnAgencySearch.Location = new System.Drawing.Point(263, 31);
            this.btnAgencySearch.Name = "btnAgencySearch";
            this.btnAgencySearch.Size = new System.Drawing.Size(73, 23);
            this.btnAgencySearch.TabIndex = 85;
            this.btnAgencySearch.Text = "Найти";
            this.btnAgencySearch.Click += new System.EventHandler(this.btnAgencySearch_Click);
            // 
            // lblAgencyCode
            // 
            this.lblAgencyCode.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAgencyCode.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblAgencyCode.Location = new System.Drawing.Point(6, 60);
            this.lblAgencyCode.Name = "lblAgencyCode";
            this.lblAgencyCode.Size = new System.Drawing.Size(69, 18);
            this.lblAgencyCode.TabIndex = 1;
            this.lblAgencyCode.Text = "TicketMan";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(6, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(308, 16);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Введите часть наименования или кода организации";
            // 
            // txtAgencySearch
            // 
            this.txtAgencySearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAgencySearch.Location = new System.Drawing.Point(6, 32);
            this.txtAgencySearch.Name = "txtAgencySearch";
            this.txtAgencySearch.Size = new System.Drawing.Size(251, 22);
            this.txtAgencySearch.TabIndex = 12;
            this.txtAgencySearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAgencySearch_KeyDown);
            // 
            // lblAgencyName
            // 
            this.lblAgencyName.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAgencyName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblAgencyName.Location = new System.Drawing.Point(119, 62);
            this.lblAgencyName.Name = "lblAgencyName";
            this.lblAgencyName.Size = new System.Drawing.Size(71, 16);
            this.lblAgencyName.TabIndex = 1;
            this.lblAgencyName.Text = "Альпонлайн";
            // 
            // rbOrganizationMember
            // 
            this.rbOrganizationMember.AutoSize = true;
            this.rbOrganizationMember.Font = new System.Drawing.Font("Tahoma", 7.4F);
            this.rbOrganizationMember.Location = new System.Drawing.Point(6, 48);
            this.rbOrganizationMember.Name = "rbOrganizationMember";
            this.rbOrganizationMember.Size = new System.Drawing.Size(152, 20);
            this.rbOrganizationMember.TabIndex = 18;
            this.rbOrganizationMember.Text = "Сотрудник агентства";
            this.rbOrganizationMember.UseVisualStyleBackColor = true;
            this.rbOrganizationMember.CheckedChanged += new System.EventHandler(this.rbCustomer_CheckedChanged);
            // 
            // rbCustomer
            // 
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Checked = true;
            this.rbCustomer.Font = new System.Drawing.Font("Tahoma", 7.4F);
            this.rbCustomer.Location = new System.Drawing.Point(6, 22);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(131, 20);
            this.rbCustomer.TabIndex = 15;
            this.rbCustomer.TabStop = true;
            this.rbCustomer.Text = "Физическое лицо";
            this.rbCustomer.UseVisualStyleBackColor = true;
            this.rbCustomer.CheckedChanged += new System.EventHandler(this.rbCustomer_CheckedChanged);
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(204, 27);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.txtId.Properties.Appearance.Options.UseBackColor = true;
            this.txtId.Properties.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(182, 22);
            this.txtId.TabIndex = 100;
            // 
            // txtPhoneNumbers
            // 
            this.txtPhoneNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNumbers.Location = new System.Drawing.Point(114, 169);
            this.txtPhoneNumbers.Name = "txtPhoneNumbers";
            this.txtPhoneNumbers.Size = new System.Drawing.Size(272, 22);
            this.txtPhoneNumbers.TabIndex = 12;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(114, 141);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(272, 22);
            this.txtLastName.TabIndex = 8;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(114, 113);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(272, 22);
            this.txtFirstName.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 172);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 16);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Телефоны";
            // 
            // txtSiteSlug
            // 
            this.txtSiteSlug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiteSlug.Location = new System.Drawing.Point(114, 57);
            this.txtSiteSlug.Name = "txtSiteSlug";
            this.txtSiteSlug.Properties.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.txtSiteSlug.Properties.Appearance.Options.UseBackColor = true;
            this.txtSiteSlug.Properties.ReadOnly = true;
            this.txtSiteSlug.Size = new System.Drawing.Size(272, 22);
            this.txtSiteSlug.TabIndex = 101;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailAddress.Location = new System.Drawing.Point(114, 85);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(272, 22);
            this.txtEmailAddress.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(7, 144);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(53, 16);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "Фамилия";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(167, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Глобальный идентификатор";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(6, 60);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(47, 16);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "SiteSlug";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 116);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Имя";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(83, 16);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "E-mail (логин)";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangePassword.Image = global::TicketMan.Backoffice.Desktop.Properties.Resources.password_key;
            this.btnChangePassword.Location = new System.Drawing.Point(155, 413);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(137, 35);
            this.btnChangePassword.TabIndex = 85;
            this.btnChangePassword.Text = "Изменить пароль";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnChangeLogin
            // 
            this.btnChangeLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeLogin.Image = global::TicketMan.Backoffice.Desktop.Properties.Resources.login_icon;
            this.btnChangeLogin.Location = new System.Drawing.Point(12, 413);
            this.btnChangeLogin.Name = "btnChangeLogin";
            this.btnChangeLogin.Size = new System.Drawing.Size(137, 35);
            this.btnChangeLogin.TabIndex = 85;
            this.btnChangeLogin.Text = "Изменить логин";
            this.btnChangeLogin.Click += new System.EventHandler(this.btnChangeLogin_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(170, 464);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(105, 23);
            this.btnCreate.TabIndex = 51;
            this.btnCreate.Text = "Создать";
            this.btnCreate.Visible = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveUser.Location = new System.Drawing.Point(175, 464);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(100, 23);
            this.btnSaveUser.TabIndex = 50;
            this.btnSaveUser.Text = "Сохранить";
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(281, 464);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 23);
            this.btnCancel.TabIndex = 55;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(401, 493);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnChangeLogin);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveUser);
            this.Controls.Add(this.btnCreate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FrmUser";
            this.Text = "Редактирование пользователя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUser_FormClosing);
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.groupBoxPassword.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chSetPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxOrganizationMember.ResumeLayout(false);
            this.groupBoxOrganizationMember.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chRoleOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgencySearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNumbers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteSlug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailAddress.Properties)).EndInit();
            this.ResumeLayout(false);

				}

				#endregion

				private DevExpress.XtraEditors.LabelControl labelControl1;
				private DevExpress.XtraEditors.TextEdit txtId;
				private DevExpress.XtraEditors.LabelControl labelControl2;
				private DevExpress.XtraEditors.LabelControl labelControl3;
				private DevExpress.XtraEditors.TextEdit txtEmailAddress;
				private DevExpress.XtraEditors.SimpleButton btnSaveUser;
				private DevExpress.XtraEditors.GroupControl groupControl1;
				private DevExpress.XtraEditors.SimpleButton btnCreate;
				private DevExpress.XtraEditors.LabelControl labelControl6;
				private DevExpress.XtraEditors.SimpleButton btnCancel;
				private DevExpress.XtraEditors.TextEdit txtLastName;
				private DevExpress.XtraEditors.TextEdit txtFirstName;
				private DevExpress.XtraEditors.TextEdit txtPhoneNumbers;
				private DevExpress.XtraEditors.LabelControl labelControl4;
				private System.Windows.Forms.GroupBox groupBox1;
				private System.Windows.Forms.RadioButton rbOrganizationMember;
				private System.Windows.Forms.RadioButton rbCustomer;
				private System.Windows.Forms.GroupBox groupBoxPassword;
				private DevExpress.XtraEditors.CheckEdit chSetPassword;
				private DevExpress.XtraEditors.TextEdit txtPassword;
				private System.Windows.Forms.GroupBox groupBoxOrganizationMember;
				private DevExpress.XtraEditors.LabelControl labelControl5;
				private DevExpress.XtraEditors.TextEdit txtAgencySearch;
				private DevExpress.XtraEditors.SimpleButton btnAgencySearch;
				private DevExpress.XtraEditors.LabelControl lblAgencyCode;
                private DevExpress.XtraEditors.LabelControl lblAgencyName;
                private DevExpress.XtraEditors.TextEdit txtSiteSlug;
                private DevExpress.XtraEditors.LabelControl labelControl7;
                private DevExpress.XtraEditors.SimpleButton btnChangeLogin;
                private DevExpress.XtraEditors.SimpleButton btnChangePassword;
                private DevExpress.XtraEditors.CheckEdit chRoleOn;
                private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;

		}
}