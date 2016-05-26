using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicketMan.Backoffice.Desktop.Core;
using TicketMan.Backoffice.Desktop.UI.Service;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmContract : EditableForm
	{
		Contract _contract;
		string _contractUniqueNumber;
		bool _isnew, _isnewOrganization;
		List<ContractFormula> _formulas;
		string _organizationcode = "", _organizationname = "";
		private ContractType _contractType;
		private FrmOrganization _frmParent;
		long _BuyerPartyId;
		long _SellerPartyId;

		public FrmContract(string contractUniqueNumber, FrmOrganization frmParent, ContractType contractType)
			: this(contractUniqueNumber, string.Empty, contractType, frmParent)
		{
		}

		public FrmContract(string contractUniqueNumber, string organizationcode, ContractType contractType, FrmOrganization frmParent)
		{
			_organizationcode = organizationcode;
			_organizationname = frmParent.txtShortName.Text;
			if (_organizationname == "")
				_organizationname = frmParent.txtFullName.Text;
			_isnewOrganization = organizationcode == "";
			_contractUniqueNumber = contractUniqueNumber;
			_isnew = contractUniqueNumber == "";
			_contractType = contractType;
			_frmParent = frmParent;
			InitializeComponent();
		}

		private void frmContract_Load(object sender, EventArgs e)
		{
			RefreshData();
			RefreshStaticData();
		}

		void RefreshStaticData()
		{
			cbServiceType.Properties.DataSource = DataProcessor.GetServiceTypes();
			cbServiceType.Properties.ValueMember = "Code"; //"PriceRowTypeId";
			cbServiceType.Properties.DisplayMember = "Code";
		}

		void SetDesign()
		{
			btnCreate.Visible = _isnew;
			//btnCreateFormula.Visible = 
			btnSaveContract.Visible = !btnCreate.Visible;
			Text = _isnew ? "Создание контракта" : "Редактирование контракта";
			//txtBuyerPartyId.Properties.ReadOnly = !isnew;
			txtContractType.Text = _contractType.ToString();
			if (_isnew)
			{
				txtCurrencyCode.Text = "Rub";
				cbServiceType.EditValue = "flights";
			}
			SetFormulaGridDesign();
		}

		private void SetFormulaGridDesign()
		{
			if (this.gridViewFormulas.Columns.Count > 0)
			{
				gridViewFormulas.Columns[0].OptionsColumn.ReadOnly = true;

				gridViewFormulas.Columns[0].Caption = "№";
				gridViewFormulas.Columns[0].MaxWidth = 30;
				gridViewFormulas.Columns[1].Caption = "Описание";
				gridViewFormulas.Columns[2].Caption = "Тип сделки";
				gridViewFormulas.Columns[2].Width = 30;
				gridViewFormulas.Columns[3].Caption = "Формула";
			}
		}

		private void SetСontractors()
		{
			if (_contractType == ContractType.AttractClient)
			{
				txtSeller.Text = _organizationname;
				txtBuyer.Text = Persistence.LoggedOrganization().ShortName;
				if (_isnew)
				{
					long.TryParse(_organizationcode, out _SellerPartyId);
					_BuyerPartyId = Persistence.LoggedOrganization().PartyId;
				}
			}
			else
			{
				txtSeller.Text = Persistence.LoggedOrganization().ShortName;
				txtBuyer.Text = _organizationname;
				if (_isnew)
				{
					long.TryParse(_organizationcode, out _BuyerPartyId);
					_SellerPartyId = Persistence.LoggedOrganization().PartyId;
				}
			}
		}

		void RefreshData()
		{
			try
			{
				splashScreenManager1.ShowWaitForm();
				if (!_isnew)
				{
					GetContract();
					RefreshContract();
					RefreshFormulas();
				}
				SetDesign();
				SetСontractors();
				Dirty = false;
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}
		}

		private void RefreshFormulas()
		{
			if (_formulas != null)
			{
				_formulas.Sort((f1, f2) => f1.Number.CompareTo(f2.Number));
			}
			gridFormulas.DataSource = null;
			gridFormulas.DataSource = _formulas;
			var restClient = (ContractsRestClient)DataProcessor.GetRestClient("ContractsRestClient");
			var riCombo = new RepositoryItemLookUpEdit();
			riCombo.EditValueChanged += RiComboOnEditValueChanged;
			riCombo.DataSource = restClient.GetPriceRowTypes();
			riCombo.NullText = "";

			gridFormulas.RepositoryItems.Add(riCombo);
			riCombo.ValueMember = "Code";
			riCombo.DisplayMember = "Code";
			if (gridViewFormulas.Columns.Count > 1)
			{
				gridViewFormulas.Columns[2].ColumnEdit = riCombo;
			}
			
		}

		private void RiComboOnEditValueChanged(object sender, EventArgs eventArgs)
		{
			Dirty = true;
		}


		void GetContract()
		{
			var restClient = (ContractsRestClient)DataProcessor.GetRestClient("ContractsRestClient");
			_contract = restClient.GetContract(_contractUniqueNumber);
		}

		void RefreshContract()
		{
			txtUniqueNumber.Text = _contract.UniqueNumber;
			txtExternalNumber.Text = _contract.ExternalNumber;
			_BuyerPartyId = _contract.BuyerPartyId;
			_SellerPartyId = _contract.SellerPartyId;
			chIsActive.Checked = _contract.IsActive;

			cbServiceType.EditValue = _contract.ServiceType;

			txtLastUpdate.Text = _contract.LastUpdate.ToString();
			txtCurrencyCode.Text = _contract.CurrencyCode;
			txtContractType.Text = _contractType.ToString();
			_formulas = _contract.Formulas;

			if (_contract.ContractType == ContractType.AttractClient)
				cbBankAccountCode.Properties.DataSource = _frmParent._organization.Essentials.BankAccounts;
			else
				cbBankAccountCode.Properties.DataSource = Persistence.LoggedOrganization().Essentials.BankAccounts;
			cbBankAccountCode.Properties.ValueMember = "Code";
			cbBankAccountCode.Properties.DisplayMember = "AccountNumber";
			cbBankAccountCode.EditValue = _contract.SellerBankAccountCode;
		}

		Contract GetUpdatedContract()
		{
			Contract newcontract = _contract ?? new Contract();

			newcontract.ExternalNumber = txtExternalNumber.Text;
			newcontract.IsActive = chIsActive.Checked;

			newcontract.ServiceType = cbServiceType.EditValue.ToString();
			if (_isnew)
				newcontract.ContractType = _contractType;

			newcontract.BuyerPartyId = _BuyerPartyId;
			newcontract.SellerPartyId = _SellerPartyId;

			newcontract.CurrencyCode = txtCurrencyCode.Text;

			UpdateFormulas();
			newcontract.Formulas = _formulas;

			if (cbBankAccountCode.EditValue != null)
				newcontract.SellerBankAccountCode = cbBankAccountCode.EditValue.ToString();
			return newcontract;
		}

		private void btnSaveContract_Click(object sender, EventArgs e)
		{
			UpdateContract(false);
		}

		private void UpdateFormulas()
		{
			_formulas = new List<ContractFormula>();
			for (int i = 0; i < gridViewFormulas.RowCount; i++)
			{
				var dr = gridViewFormulas.GetRow(i);
				if (!(dr is ContractFormula)) continue;
				var formula = dr as ContractFormula;

				_formulas.Add(formula);
			}
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			UpdateContract(true);
		}

		void UpdateContract(bool isnew)
		{
			var restClient = (ContractsRestClient)DataProcessor.GetRestClient("ContractsRestClient");
			var updated = GetUpdatedContract();
			_contractUniqueNumber = updated.UniqueNumber;
			if (isnew)
			{
				if (AlreadyExistContractAndServiceType(updated))
					return;
				if (_isnewOrganization)
				{
					_frmParent.Contracts = new List<Contract> { updated };
					_frmParent.UpdateOrganization(true);
					Dirty = false;
					this.Close();
					return;
				}
				_contract = restClient.CreateContract(updated);
				_contractUniqueNumber = _contract.UniqueNumber;
				_isnew = false;
			}
			else
				restClient.UpdateContract(updated);
			RefreshData();
			_frmParent.RefreshContracts();
		}

		private bool AlreadyExistContractAndServiceType(Contract contract)
		{
			var contractAndServiceType = new ContractAndServiceType { ContractType = contract.ContractType, ServiceType = contract.ServiceType };
			if (_frmParent.ExistingContractAndServiceTypes.Contains(contractAndServiceType))
			{
				MessageBox.Show("Ошибка. Контракт с таким типом и типом услуги уже существует.", "Desktop", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return true;
			}
			return false;
		}

		private void FrmContract_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!Dirty) return;
			DialogResult result = MessageBox.Show("Сохранить изменения?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				UpdateContract(_isnew);
				Dirty = false;
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

		private void btnCreateFormula_Click(object sender, EventArgs e)
		{
			CreateFormula();
		}

		private void CreateFormula()
		{
			if (_formulas == null) _formulas = new List<ContractFormula>();
			int number = 0;
			foreach (var f in _formulas)
				if (f.Number > number)
					number = f.Number;
			number++;
			_formulas.Add(new ContractFormula { Number = number, Description = "", Formula = "" });
			Dirty = true;
			RefreshFormulas();
			SetFormulaGridDesign();
		}

		private void btnEmptyBankAccount_Click(object sender, EventArgs e)
		{
			cbBankAccountCode.EditValue = "";
			//RefreshBankAccount();
		}

		private void cbBankAccountCode_EditValueChanged(object sender, EventArgs e)
		{
			RefreshBankAccount();
		}

		private void RefreshBankAccount()
		{
			if (cbBankAccountCode.EditValue != null)
			{
				BankAccount bankAccount = ApiUtils.GetBankAccount(_contract, _frmParent._organization, cbBankAccountCode.EditValue.ToString());
				if (bankAccount != null)
				{
					txtAccountNumber.Text = bankAccount.AccountNumber;
					txtBankAddress.Text = bankAccount.BankAddress;
					txtBankName.Text = bankAccount.BankName;
					txtBik.Text = bankAccount.Bik;
					txtCorrespondingAccountNumber.Text = bankAccount.CorrespondingAccountNumber;
					return;
				}
			}
			txtAccountNumber.Text =
			txtBankAddress.Text =
			txtBankName.Text =
			txtBik.Text =
			txtCorrespondingAccountNumber.Text = "";

		}

		private void btnDeleteFormula_Click(object sender, EventArgs e)
		{
			DeleteFormula();
		}

		private void DeleteFormula()
		{
			var o = gridViewFormulas.GetRow(gridViewFormulas.FocusedRowHandle);
			if (!(o is ContractFormula)) return;
			string title = Application.ProductName;
			string question = "Удалить формулу?";
			if (DialogResult.Yes !=
			 MessageBox.Show(this, question, title,
							 MessageBoxButtons.YesNo,
							 MessageBoxIcon.Question))
				return;
			var formula = o as ContractFormula;
			_formulas.Remove(formula);
			foreach (var contractFormula in _formulas)
			{
				if (contractFormula.Number > formula.Number)
					contractFormula.Number--;
			}
			RefreshFormulas();
			Dirty = true;
		}

		private void btnFormulaUp_Click(object sender, EventArgs e)
		{
			FormulaMoveUpDown(true);
		}

		private void FormulaMoveUpDown(bool moveUp)
		{
			var o = gridViewFormulas.GetRow(gridViewFormulas.FocusedRowHandle);
			if (!(o is ContractFormula)) return;
			var formula1 = o as ContractFormula;
			int a = moveUp ? -1 : 1;
			ContractFormula formula2 = _formulas.Find(f => f.Number == formula1.Number + a);
			if (formula2 == null) return;
			int num = formula1.Number;
			formula1.Number = formula2.Number;
			formula2.Number = num;
			RefreshFormulas();
			Dirty = true;
		}

		private void btnFormulaDown_Click(object sender, EventArgs e)
		{
			FormulaMoveUpDown(false);
		}
	}
}
