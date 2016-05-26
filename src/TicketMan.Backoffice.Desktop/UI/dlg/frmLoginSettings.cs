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
	public partial class FrmLoginSettings : XtraForm
  {
		RegistryData _registryData;
		RegRecord _current;
		FrmLogin _parent;

		public void ShowDialog(FrmLogin parent)
		{
			_parent = parent;
			this.ShowDialog();
		}

    public FrmLoginSettings()
    {
      InitializeComponent();
			cbSiteSlug.Properties.ShowHeader = false;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {

			if (Save())
				this.Close();
		}

		bool Save()
		{
			if (txtSiteSlug.Text == "")
			{
				MessageBox.Show("SiteSlug не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			//RegRecord reg = new RegRecord { ApiKey = txtApiKey.Text, Url = txtUrl.Text, SiteSlug = txtSiteSlug.Text, Code = code };
			_current.ApiKey = txtApiKey.Text;
			_current.Url = txtUrl.Text;
			_current.SiteSlug = txtSiteSlug.Text;
			_registryData.DefaultSiteSlug = _current.Code;
			RegistryManager.UpdateData(_registryData);
			
			return true;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FrmLoginSettings_Load(object sender, EventArgs e)
		{
			_registryData = RegistryManager.GetData();
			GetData();
		}


		void GetData()
		{
			string code = "";
			if (_registryData.List.Count == 0)
			{
				code = Guid.NewGuid().ToString();
				RegRecord reg = new RegRecord { Url = "https://api2.TicketMan.ru/", Code = code, SiteSlug = "", Deleted=false };
				_registryData.List.Add(reg);
			}

			btnDelete.Enabled = _registryData.List.FindAll(x => x.Deleted == false).Count > 1;

			cbSiteSlug.EditValue = _registryData.DefaultSiteSlug == "" ? code : _registryData.DefaultSiteSlug;
			//cbSiteSlug_EditValueChanged(null, null);

			cbSiteSlug.Properties.DataSource = _registryData.List.FindAll(x => x.Deleted == false);
			cbSiteSlug.Properties.DisplayMember = "SiteSlug";
			cbSiteSlug.Properties.ValueMember = "Code";

			if (cbSiteSlug.Properties.Columns.Count == 0)
			{
				cbSiteSlug.Properties.Columns.Add(new LookUpColumnInfo("Code", 0, ""));
				cbSiteSlug.Properties.Columns.Add(new LookUpColumnInfo("SiteSlug", 50, "SiteSlug"));
			}
		}


		private void cbSiteSlug_EditValueChanged(object sender, EventArgs e)
		{
			_current = _registryData.List.Find(x => x.Code == cbSiteSlug.EditValue.ToString());
			if (_current != null)
			{
				txtApiKey.Text = _current.ApiKey;
				txtUrl.Text = _current.Url;
				txtSiteSlug.Text = _current.SiteSlug;
			}
		}

		private void FrmLoginSettings_FormClosed(object sender, FormClosedEventArgs e)
		{
			_parent.GetData();
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			string code = Guid.NewGuid().ToString();
			RegRecord reg = new RegRecord { Url = "https://api2.TicketMan.ru/", Code = code, SiteSlug = "", Deleted=false };
			_registryData.List.Add(reg);
			GetData();
			cbSiteSlug.EditValue = code;
			btnCreate.Enabled = false;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			_current.Deleted = true;
			if (_registryData.DefaultSiteSlug == _current.Code)
			{
				_registryData.DefaultSiteSlug = _registryData.List.FindAll(x => x.Deleted == false)[0].Code;
			}
			GetData();
			btnCreate.Enabled = true;
		}

  }
}
