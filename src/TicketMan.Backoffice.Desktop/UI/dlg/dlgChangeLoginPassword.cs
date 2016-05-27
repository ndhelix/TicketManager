using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TicketMan.Backoffice.Desktop.Core;
using TicketMan.Platform.Api.Shared;
using DevExpress.XtraEditors;
using TicketMan.Platform.Api.Shared.Protocol.Requests;

namespace TicketMan.Backoffice.Desktop.UI.dlg
{
	public partial class DlgChangeLoginPassword : XtraForm
	{
		private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;

        private long _userid;
        private string _siteslug;
        private bool _ischanginglogin;

        public DlgChangeLoginPassword(string login, long userid, string siteslug, bool ischanginglogin)
		{
			InitializeComponent();
			this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TicketMan.Backoffice.Desktop.WaitForm1), true, true);
            
            txtLoginOld.Text = login;
            _userid = userid;
            _ischanginglogin = ischanginglogin;
            _siteslug = siteslug;

            SetInitialDesign();
		}

	    private void SetInitialDesign()
	    {
	        if (_ischanginglogin)
	        {
	            this.Text = "Изменение логина";
	            lblNewReg.Text = "Новый логин";
	        }
	        else
	        {
                this.Text = "Изменение пароля";
                lblNewReg.Text = "Новый пароль";
	        }
	    }

	    private void btnSave_Click(object sender, EventArgs e)
		{
			splashScreenManager1.ShowWaitForm();
			try
			{
                if (_ischanginglogin)
                {
                    ChangeLogin();
                    MessageBox.Show("Логин был изменен");
                }
                else
                {
                    ChangePassword();
                    MessageBox.Show("Пароль был изменен");
                }
				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format(ex.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				splashScreenManager1.CloseWaitForm();
			}
		}

	    private void ChangePassword()
	    {
            if (txtNewReg.Text.Length == 0)
            {
                MessageBox.Show("Пароль не задан.");
                return;
            }
            var restClient = (UserRestClient)DataProcessor.GetRestClient("UserRestClient");
            //restClient.UpdatePassword(_siteslug, txtLoginOld.Text, txtNewReg.Text);
        }

	    private void ChangeLogin()
		{
            Match match = Regex.Match(txtNewReg.Text, Constants.RegexEmail);
            if (!match.Success)
            {
                throw new Exception("Логин (email) некорректный.");
            }
            var restClient = (UserRestClient)DataProcessor.GetRestClient("UserRestClient");
            //restClient.ChangeLogin(_userid, txtNewReg.Text);
		}

		private void DlgChangeLoginPassword_Load(object sender, EventArgs e)
		{

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}


	}
}
