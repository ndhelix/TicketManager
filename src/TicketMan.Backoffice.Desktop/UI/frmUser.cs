using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicketMan.Backoffice.Desktop.Core;
using TicketMan.Backoffice.Desktop.Decorators;
using TicketMan.Backoffice.Desktop.UI.Service;
using TicketMan.Backoffice.Desktop.UI.dlg;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Profile;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using TicketMan.Platform.Api.Shared.Protocol.Requests;
using System.Text.RegularExpressions;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmUser : EditableForm
	{
		User _user;
        string _email;
        string _siteslug;
        bool _isnew;
        bool _isAgencyUser = false;


		public FrmUser(string email)
		{
			_email = email;
			_isnew = email == "";
		    _siteslug = Config.SiteSlug;
			InitializeComponent();
		}
        public FrmUser(string email, string siteslug):this(email)
        {
            _siteslug = siteslug;
            _isAgencyUser = true;
        }

		private void frmUser_Load(object sender, EventArgs e)
		{
			RefreshStaticData();
			RefreshData();
			SetInitialDesign();
		}

		private void SetInitialDesign()
		{
			if (!_isnew)
			{
                Height = Height - (groupBoxPassword.Height - btnChangePassword.Height);
			}
		}

		void RefreshStaticData()
		{
			lblAgencyCode.Text = lblAgencyName.Text = "";
            txtSiteSlug.Text = _siteslug;
			groupBoxOrganizationMember.Enabled = rbOrganizationMember.Checked;
		}

		void SetDesign()
		{
			btnCreate.Visible = _isnew;
			btnSaveUser.Visible = !btnCreate.Visible;
			Text = _isnew ? "Создание пользователя" : "Редактирование пользователя";
			groupBoxPassword.Visible = _isnew;
            btnChangeLogin.Visible = btnChangePassword.Visible = !_isnew;
			txtEmailAddress.Properties.ReadOnly = !_isnew;
			if (_isnew)
			{
				//txtCurrencyCode.Text = "Rub";
				//cbServiceType.EditValue = "flights";
			}
		}


		void RefreshData()
		{
			try
			{
				splashScreenManager1.ShowWaitForm();
				if (!_isnew)
				{
					GetUser();
					RefreshUser();
				}
				SetDesign();
				Dirty = false;
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}
		}

		void GetUser()
		{
			var restClient = (UserRestClient)DataProcessor.GetRestClient("UserRestClient");
			_user = restClient.GetUser(_siteslug, _email);
		}

		void RefreshUser()
		{
			txtId.Text = _user.Id.ToString();
		    txtSiteSlug.Text = _user.SiteSlug;
			txtEmailAddress.Text = _user.EmailAddress;
			txtFirstName.Text = _user.FirstName;
			txtLastName.Text = _user.LastName;
			if (_user.PhoneNumbers != null)
				txtPhoneNumbers.Text = string.Join("; ", _user.PhoneNumbers.ToArray());
			rbCustomer.Checked = _user.Type == UserType.Customer;
			groupBoxOrganizationMember.Enabled = rbOrganizationMember.Checked = !rbCustomer.Checked;
			if (rbOrganizationMember.Checked)
				lblAgencyCode.Text = _user.OrganizationCode;
            chRoleOn.Checked = _user.Permissions.Find(x => x.Code == "office.IssueOrder") != null;
        }

		User GetUpdatedUser()
		{
			User newuser = _user ?? new User();

			newuser.EmailAddress = txtEmailAddress.Text;
			newuser.FirstName = txtFirstName.Text;
			newuser.LastName = txtLastName.Text;
			if (txtPhoneNumbers.Text != "")
				if (newuser.PhoneNumbers == null)
					newuser.PhoneNumbers = new List<string> { txtPhoneNumbers.Text };
				else
					if (newuser.PhoneNumbers.Count == 0)
						newuser.PhoneNumbers.Add(txtPhoneNumbers.Text);
					else
						newuser.PhoneNumbers[0] = txtPhoneNumbers.Text;
			else
                newuser.PhoneNumbers = new List<string>();
			if (rbOrganizationMember.Checked)
			{
				newuser.Type = UserType.OrganizationMember;
				newuser.OrganizationCode = lblAgencyCode.Text;
                newuser.Roles = new List<Role>();
                if (chRoleOn.Checked) newuser.Roles.Add(new Role { Code = "ticketIssuer"});
                //newuser.Permissions.Add(new Permission("office.IssueOrder"));
            }
			else
			{
				newuser.Type = UserType.Customer;
				newuser.OrganizationCode = null;
			}
			return newuser;
		}

		private void btnSaveUser_Click(object sender, EventArgs e)
		{
			UpdateUser(false);
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			UpdateUser(true);
		}

		bool UpdateUser(bool isnew)
		{
			if (!Dirty && !isnew) return true;
			string errmsg = CheckFields();
			if (errmsg != "")
			{
				MessageBox.Show(errmsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			var restClient = (UserRestClient)DataProcessor.GetRestClient("UserRestClient");
			var updated = GetUpdatedUser();
			_email = updated.EmailAddress;
			if (isnew)
			{
				var createUserRequest = new CreateUserRequest();
				if (chSetPassword.Checked)
				{
					createUserRequest.Password = txtPassword.Text;
				}
				createUserRequest.User = updated;
				createUserRequest.User.SiteSlug = _siteslug;
				_user = restClient.CreateUser(createUserRequest);
				_email = _user.EmailAddress;
				_isnew = false;
			}
			else
				restClient.UpdateUser(updated);
			RefreshData();
		    return true;
		}

		private string CheckFields()
		{
			string ret = "";
            Match match = Regex.Match(txtEmailAddress.Text, Constants.RegexEmail);
			if (!match.Success)
			{
				ret += "Email некорректный. " + Environment.NewLine;
			}
			if (rbOrganizationMember.Checked && lblAgencyCode.Text == "")
			{
				ret += "Необходимо указать организацию, сотрудником которой является пользователь.";
			}

			return ret;
		}

		private void FrmUser_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!Dirty) return;
			DialogResult result = MessageBox.Show("Сохранить изменения?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				bool success = UpdateUser(_isnew);
			    e.Cancel = !success;
			}
			else
				if (result == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void rbCustomer_CheckedChanged(object sender, EventArgs e)
		{
			groupBoxOrganizationMember.Enabled = rbOrganizationMember.Checked;
			Dirty = true;
		}

		private void chSetPassword_CheckedChanged(object sender, EventArgs e)
		{
			txtPassword.Enabled = chSetPassword.Checked;
		}

		private void btnAgencySearch_Click(object sender, EventArgs e)
		{
			if (txtAgencySearch.Text == "") return;
            var agency = Persistence.FindAgency(txtAgencySearch.Text);
			if (agency != null)
			{
				lblAgencyCode.Text = agency.Code;
				lblAgencyName.Text = agency.FullName;
			}
			else
			{
				lblAgencyCode.Text = lblAgencyName.Text = "";				
			}
		}

		private void txtAgencySearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnAgencySearch_Click(sender, e);
			}
		}

        private void btnChangeLogin_Click(object sender, EventArgs e)
        {
            var dlg =new DlgChangeLoginPassword(_email, _user.Id, _siteslug, true);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
                this.Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            new DlgChangeLoginPassword(_email, _user.Id, _siteslug, false).ShowDialog();
        }

		
	}
}
