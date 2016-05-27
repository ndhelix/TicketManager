using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TicketMan.Backoffice.Desktop.Core;
using TicketMan.Backoffice.Desktop.Decorators;
using TicketMan.Backoffice.Desktop.UI.Service;
using TicketMan.Backoffice.Desktop.UI.dlg;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Exceptions;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Profile;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using TicketMan.Platform.Api.Shared.Protocol.Requests;
using System.Text.RegularExpressions;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmSite : EditableForm
	{
		Site _site;
        string _siteslug;
        string _orgcode;
        bool _isnew;

        public FrmSite(string siteslug, string orgcode)
		{
            _siteslug = siteslug;
            _isnew = _siteslug == "";
            _orgcode = orgcode;
			InitializeComponent();
		}
        
		private void frmSite_Load(object sender, EventArgs e)
		{
			RefreshData();
		    SetInitialDesign();
		}

        void SetInitialDesign()
        {
            if (_isnew)
            {
                txtSiteSlug.Text = _orgcode;
                txtOrganizationCode.Text = _orgcode;
                chActive.Checked = true;
                chSenMessageRequired.Checked = true;
                Dirty = false;
            }
        }

		void SetDesign()
		{
			btnCreate.Visible = _isnew;
			btnSaveSite.Visible = !btnCreate.Visible;
            Text = _isnew ? "Создание сайта" : "Редактирование сайта";
			txtSiteSlug.Properties.ReadOnly = !_isnew;
		    txtSiteSlug.BackColor = _isnew ? Color.White : Color.LightGray;
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
					GetSite();
					RefreshSite();
				}
				SetDesign();
				Dirty = false;
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}
		}

		void GetSite()
		{
			var restClient = (SiteRestClient)DataProcessor.GetRestClient("SiteRestClient");
			_site = restClient.GetSite(_siteslug);
		}

		void RefreshSite()
		{
		    txtSiteSlug.Text = _site.SiteSlug;
			txtName.Text = _site.Name;
			txtOrganizationCode.Text = _site.OrganizationCode;
		    chActive.Checked = _site.IsActive;
            chSenMessageRequired.Checked = _site.IsCreatingUserMessageRequired ?? false;

		}

		Site GetUpdatedSite()
		{
			Site newsite = _site ?? new Site();

            newsite.SiteSlug = txtSiteSlug.Text;
            newsite.Name = txtName.Text;
            newsite.OrganizationCode = txtOrganizationCode.Text;
            newsite.IsActive = chActive.Checked;
            newsite.IsCreatingUserMessageRequired = chSenMessageRequired.Checked;



			return newsite;
		}

		private void btnSaveSite_Click(object sender, EventArgs e)
		{
			UpdateSite(false);
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			UpdateSite(true);
		}

		void UpdateSite(bool isnew)
		{
			if (!Dirty && !isnew) return;
			string errmsg = CheckFields();
			if (errmsg != "")
			{
				MessageBox.Show(errmsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

		    try
		    {
                var restClient = (SiteRestClient)DataProcessor.GetRestClient("SiteRestClient");
                var updated = GetUpdatedSite();
                if (isnew)
                {
                    _site = restClient.CreateSite(updated);
                    _isnew = false;
                    string siteinfo = String.Format(
                        "Скопируйте и сохраните эту информацию.\r\n" +
                        "Создан новый сайт: \r\n " +
                        "SiteSlug: {0}\r\n" +
                        "Название: {1}\r\n" +
                        "Код организации: {2}\r\n" +
                        "API key: {3}"
                        , _site.SiteSlug
                        , _site.Name
                        , _site.OrganizationCode
                        , _site.ApiKey
                        );
                    _siteslug = _site.SiteSlug;
                    new DlgInfoText("Создан новый сайт", siteinfo).ShowDialog();
                }
                else
                    restClient.UpdateSite(updated);

		    }
		    catch (LogicalApiException ex)
		    {
		        if (ex.Code == ErrorCode.SiteAlreadyExists)
                    MessageBox.Show("Сайт с таким кодом уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		        else
		        {
                    MessageBox.Show(ex.Message, "Ошибка API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
		    {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
		    }
			RefreshData();
		}

		private string CheckFields()
		{
			string ret = "";
            if (txtName.Text == "")
                ret += "Название сайта не заполнено.\r\n";
			return ret;
		}

		private void FrmSite_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!Dirty) return;
			DialogResult result = MessageBox.Show("Сохранить изменения?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				UpdateSite(_isnew);
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


		
	}
}
