using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Exceptions;
using DevExpress.XtraEditors;
using TicketMan.Backoffice.Desktop.Core;
using DevExpress.XtraEditors.Controls;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmLogin : XtraForm
	{

		RegistryData _registryData;
		RegRecord _current;

		private FrmLogin()
		{
			InitializeComponent();
			//toolTip1.Show("Параметры", btnSettings);
		}
		private static bool IsShown = false;
		private static readonly FrmLogin MyInstance = new FrmLogin();
		public static FrmLogin OnlyInstance //singleton
		{
			get { return MyInstance; }
		}
		public new void Show()
		{
			if (IsShown)
				base.Show();
			else
			{
				base.Show();
				IsShown = true;
			}
		}
		static FrmLogin()
		{
			OnlyInstance.FormClosing += new FormClosingEventHandler(OnlyInstance_FormClosing);
		}
		private static void OnlyInstance_FormClosing(object sender, FormClosingEventArgs e)
		{
			//e.Cancel = true;
			IsShown = false;
			OnlyInstance.Hide();
		}


		private void btnOK_Click(object sender, EventArgs e)
		{
			Config.UserLogin = txtLogin.Text;
			Config.UserPassword = txtPassword.Text;

			Config.ApiKey = _current.ApiKey;
			Config.SiteSlug = _current.SiteSlug;
			Config.Url = _current.Url;

			RegistryManager.UpdateDefaultSiteSlug(_current.Code);

			try
			{
				var restClient = CreateRestClient();
				var user = restClient.GetCurrentUser();
				RegistryManager.SetLastLogin(txtLogin.Text);
				RegistryManager.SetRememberPasswordCheck(chRememberPassword.Checked);
				if (chRememberPassword.Checked)
					RegistryManager.SetPassword(txtPassword.Text);
				DialogResult = DialogResult.OK;
			}
			catch (AuthorizationApiException ex)
			{
				MessageBox.Show("Пользователь не авторизован: " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private UserRestClient CreateRestClient()
		{
			var restClient = new UserRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
			restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

			return restClient;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FrmLogin_Load(object sender, EventArgs e)
		{
			RegistryManager.CreateRegistryKeyReg();
			txtLogin.Text = RegistryManager.GetLastLogin();
			chRememberPassword.Checked = RegistryManager.GetRememberPasswordCheck();
			if (chRememberPassword.Checked)
				txtPassword.Text = RegistryManager.GetPassword();
			if (!RegistryManager.RegistryIsWritten())
			{
				btnSettings_Click(this, null);
			}
			else
				GetData();
		}

		public void GetData()
		{
			_registryData = RegistryManager.GetData();
			cbSiteSlug.EditValue = _registryData.DefaultSiteSlug;
			cbSiteSlug_EditValueChanged(null, null);

			cbSiteSlug.Properties.DataSource = _registryData.List.FindAll(x => x.Deleted == false);
			cbSiteSlug.Properties.DisplayMember = "SiteSlug";
			cbSiteSlug.Properties.ValueMember = "Code";

			if (cbSiteSlug.Properties.Columns.Count == 0)
			{
				cbSiteSlug.Properties.Columns.Add(new LookUpColumnInfo("Code", 0, ""));
				cbSiteSlug.Properties.Columns.Add(new LookUpColumnInfo("SiteSlug", 50, "SiteSlug"));
			}
		}

		private void btnSettings_Click(object sender, EventArgs e)
		{
			new FrmLoginSettings().ShowDialog(this);
			//this.Hide();

		}

		private void cbSiteSlug_EditValueChanged(object sender, EventArgs e)
		{
			_current = _registryData.List.Find(x => x.Code == cbSiteSlug.EditValue.ToString());
		}



	}
}
