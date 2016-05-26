using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using TicketMan.Backoffice.Desktop.Decorators;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Api.Shared.Exceptions;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using DevExpress.XtraEditors;
using TicketMan.Backoffice.Desktop.UI.Service;
using TicketMan.Backoffice.Desktop.Core;
using TicketMan.Backoffice.Desktop.Properties;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmOrganization : EditableForm
	{

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
			//aForm = null;
		}

		public Organization _organization;
		string _organizationcode;
		bool _isnew;
		public HashSet<ContractAndServiceType> ExistingContractAndServiceTypes;
		public List<Contract> Contracts;

		public FrmOrganization(string organizationcode)
		{
			this._organizationcode = organizationcode;
			InitializeComponent();
		}

		private void frmOrganization_Load(object sender, EventArgs e)
		{
			ExistingContractAndServiceTypes = new HashSet<ContractAndServiceType>();
			RefreshData();
			CreateMenus();
		}

		private void CreateMenus()
		{
			ToolStripMenuItemCreateContract.DropDownItems.Clear();
			foreach (ContractType contractType in Enum.GetValues(typeof(ContractType)))
			{
				//if (!ExistingContractAndServiceTypes.Contains(contractType))
				{
					var item = new ToolStripMenuItem(contractType.ToString(), null, MenuItemCreateContract_Click) {Tag = contractType};
					ToolStripMenuItemCreateContract.DropDownItems.Add(item);
				}
			}
		}

		private void MenuItemCreateContract_Click(object sender, EventArgs e)
		{
			var item = (ToolStripMenuItem)sender;
			new FrmContract("", txtPartyId.Text, (ContractType)Enum.Parse(typeof(ContractType), item.Tag.ToString()), this).Show();
		}

		void SetDesign()
		{
			_isnew = _organizationcode == "";
			btnCreate.Visible = _isnew;
			btnCreateBankAccount.Enabled = !_isnew;
			btnSaveOrganization.Visible = !btnCreate.Visible;
			Text = _isnew ? "Создание организации" : "Редактирование организации";
			txtCode.Properties.ReadOnly = txtPartyId.Properties.ReadOnly = !_isnew;
			txtCode.BackColor = txtCode.Properties.ReadOnly ? Color.LightGray : Color.White;
		}

		void RefreshData()
		{
			splashScreenManager1.ShowWaitForm();
			try
			{
				SetDesign();
				if (_organizationcode != "")
				{
					GetOrganization();
					RefreshOrganization();
					RefreshContracts();
				}
				Dirty = false;
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}
		}

		public void RefreshContracts()
		{
			List<ContractDecorator> list = DataProcessor.GetContracts(_organizationcode);
			gridContracts.DataSource = list;
			ExistingContractAndServiceTypes.Clear();
			foreach (ContractDecorator contract in list)
					ExistingContractAndServiceTypes.Add(new ContractAndServiceType{ContractType=contract.ContractType,ServiceType=contract.ServiceType} ) ;
		}

		void GetOrganization()
		{
			var restClient = (OrganizationRestClient)DataProcessor.GetRestClient("OrganizationRestClient");
			_organization = restClient.GetOrganization(_organizationcode);
		}

		void RefreshOrganization()
		{
			txtCode.Text = _organization.Code;
			txtFullName.Text = _organization.FullName;
			txtParentOrganizationCode.Text = _organization.ParentOrganizationCode;
			txtPartyId.Text = _organization.PartyId.ToString(CultureInfo.InvariantCulture);
			txtShortName.Text = _organization.ShortName;

			txtInn.Text = _organization.Essentials.Inn;
			txtKpp.Text = _organization.Essentials.Kpp;
			txtOgrn.Text = _organization.Essentials.Ogrn;
			txtLegalAddress.Text = _organization.Essentials.LegalAddress;
			txtAddress.Text = _organization.Essentials.Address;
			txtLegalName.Text = _organization.Essentials.LegalName;

			RefreshBankAccounts();
		}

		private void RefreshBankAccounts(string code = null)
		{
			cbBankAccountCode.Properties.DataSource = _organization.Essentials.BankAccounts;
			cbBankAccountCode.Properties.ValueMember = "Code";
			cbBankAccountCode.Properties.DisplayMember = "AccountNumber";
			cbBankAccountCode.EditValue = code ?? _organization.Essentials.DefaultBankAccountCode;
			btnDeleteBankAccount.Enabled = _organization.Essentials.BankAccounts.Count > 1;
			txtAccountNumber.Enabled = txtCorrespondingAccountNumber.Enabled = txtBik.Enabled = txtBankName.Enabled =
				txtBankAddress.Enabled = cbBankAccountCode.EditValue != null;
			RefreshBankAccount();
		}

		private void RefreshBankAccount()
		{
			//if (cbBankAccountCode.EditValue != null)
			{
				BankAccount bankAccount = _organization.Essentials.BankAccounts.Find(x => x.Code == cbBankAccountCode.EditValue.ToString());
				if (bankAccount != null)
				{
					txtAccountNumber.Text = bankAccount.AccountNumber;
					txtBankAddress.Text = bankAccount.BankAddress;
					txtBankName.Text = bankAccount.BankName;
					txtBik.Text = bankAccount.Bik;
					txtCorrespondingAccountNumber.Text = bankAccount.CorrespondingAccountNumber;
					SetDefaultBankAccountIndicator(bankAccount.Code == _organization.Essentials.DefaultBankAccountCode);
					return;
				}
			}
			txtAccountNumber.Text = txtBankAddress.Text = txtBankName.Text = txtBik.Text = txtCorrespondingAccountNumber.Text = "";
		}



		Organization GetUpdatedOrganization()
		{
			Organization org;
			org = _organization ?? new Organization();
			org.Code = txtCode.Text;
			org.FullName = txtFullName.Text;
			org.ParentOrganizationCode = txtParentOrganizationCode.Text;
			var partyid = 0;
			if (int.TryParse(txtPartyId.Text, out partyid))
				org.PartyId = partyid;
			org.ShortName = txtShortName.Text;

			GetUpdatedEssentials(ref org);

			return org;
		}

		private void GetUpdatedEssentials(ref Organization org)
		{
			string newBankAccountCode = Guid.NewGuid().ToString();
			if (org.Essentials == null)
				org.Essentials = new Essentials();
			
			org.Essentials.Inn = txtInn.Text;
			org.Essentials.Kpp = txtKpp.Text;
			org.Essentials.Ogrn = txtOgrn.Text;
			org.Essentials.LegalAddress = txtLegalAddress.Text;
			org.Essentials.Address = txtAddress.Text;
			org.Essentials.LegalName = txtLegalName.Text;
			org.Essentials.DefaultBankAccountCode = org.Essentials.DefaultBankAccountCode ?? newBankAccountCode;
			var defaltBankAccountCode = org.Essentials.DefaultBankAccountCode;
			if (org.Essentials.BankAccounts == null)
				org.Essentials.BankAccounts = new List<BankAccount>();

			var bankAccount = org.Essentials.BankAccounts.Find(x => x.Code == cbBankAccountCode.EditValue.ToString());
			if (bankAccount == null) bankAccount = new BankAccount();

			if (cbBankAccountCode.EditValue != null)
			{
				bankAccount.Code = cbBankAccountCode.EditValue.ToString();
				bankAccount.AccountNumber = txtAccountNumber.Text;
				bankAccount.BankAddress = txtBankAddress.Text;
				bankAccount.BankName = txtBankName.Text;
				bankAccount.Bik = txtBik.Text;
				bankAccount.CorrespondingAccountNumber = txtCorrespondingAccountNumber.Text;
			}
			if (!org.Essentials.BankAccounts.Contains(bankAccount))
				org.Essentials.BankAccounts.Add(bankAccount);
		}

		private void btnSaveOrganization_Click(object sender, EventArgs e)
		{
			UpdateOrganization(false);
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			UpdateOrganization(true);
		}

		public void UpdateOrganization(bool isnew)
		{
			var restClient = (OrganizationRestClient)DataProcessor.GetRestClient("OrganizationRestClient");
			Organization updated = GetUpdatedOrganization();
			_organizationcode = updated.Code;
			if (_organizationcode == "") return;
			if (isnew)
				try
				{
					restClient.CreateOrganization(updated, Contracts);
				}
				catch (LogicalApiException ex)
				{
					MessageBox.Show(Utils.ErrorMsg(ex), "Desktop", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			else
			{
				restClient.UpdateOrganization(updated);
			}
			RefreshData();
		}

		private void ToolStripMenuItemEditContract_Click(object sender, EventArgs e)
		{
			object o = gridViewContracts.GetRow(gridViewContracts.FocusedRowHandle);
			if (o is ContractDecorator)
			{
				var d = o as ContractDecorator;
				//frmOrganization.Instance(od).Show();
				new FrmContract(d.UniqueNumber, this, d.ContractType).Show();
			}

		}

		private void txtNotEmpty_Validating(object sender, CancelEventArgs e)
		{
			var t = (TextEdit)sender;
			if (t.Text == "")
				e.Cancel = true;
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCreateContract_Click(object sender, EventArgs e)
		{
			ContextMenuContracts.Show(btnCreateContract, -80,-30);
			ContextMenuContracts.Hide();
			ToolStripMenuItemCreateContract.ShowDropDown();
		}

		private void FrmOrganization_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!Dirty) return;
			DialogResult result = MessageBox.Show("Сохранить изменения?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				UpdateOrganization(_isnew);
			}
			else
				if (result == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
		}

		private void btnCreateBankAccount_Click(object sender, EventArgs e)
		{
			string newBankAccountCode = Guid.NewGuid().ToString();
			_organization.Essentials.BankAccounts.Add(new BankAccount { AccountNumber = "", BankAddress = "", BankName = "", Bik = "", Code = newBankAccountCode, CorrespondingAccountNumber = "" });
			RefreshBankAccounts(newBankAccountCode);
		}

		private void cbBankAccountCode_EditValueChanged(object sender, EventArgs e)
		{
			RefreshBankAccount();
		}

		private void btnDeleteBankAccount_Click(object sender, EventArgs e)
		{
			if (_organization.Essentials.BankAccounts.Count <= 1) return;
			BankAccount bankAccount = _organization.Essentials.BankAccounts.Find(x => x.Code == cbBankAccountCode.EditValue.ToString());
			if (bankAccount != null)
			{
				_organization.Essentials.BankAccounts.Remove(bankAccount);
				if (_organization.Essentials.DefaultBankAccountCode == bankAccount.Code)
				{
					_organization.Essentials.DefaultBankAccountCode = _organization.Essentials.BankAccounts[0].Code;
				}
			}
			RefreshBankAccounts(_organization.Essentials.DefaultBankAccountCode);
		}

		private void SetDefaultBankAccountIndicator(bool IsDefault)
		{
			if (IsDefault)
			{
				btnDefaultBankAccount.Image = Resources.star_yellow;
				btnDefaultBankAccount.ToolTip = "Данный счет является счетом по умолчанию (основным)";
			}
			else
			{
				btnDefaultBankAccount.Image = Resources.star_white;
				btnDefaultBankAccount.ToolTip = "Установить данный счет как счет по умолчанию (основной)";
			}
		}

		private void btnDefaultBankAccount_Click(object sender, EventArgs e)
		{
			_organization.Essentials.DefaultBankAccountCode = cbBankAccountCode.EditValue.ToString();
			RefreshBankAccounts();
		}

		private void btnAgentReport_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(_organizationcode))
			new UI.dlg.DlgAgentReportRequest(_organizationcode).ShowDialog();
		}		
	}
}
