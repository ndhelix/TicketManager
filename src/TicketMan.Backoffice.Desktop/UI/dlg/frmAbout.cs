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
using Microsoft.Win32;
using DevExpress.XtraEditors;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Systems;

namespace TicketMan.Backoffice.Desktop
{
	public partial class FrmAbout : XtraForm
	{

		public FrmAbout()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private void FrmAbout_Load(object sender, EventArgs e)
		{
			lblVersion.Text += System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

			var restClient = (SystemRestClient)DataProcessor.GetRestClient("SystemRestClient");
			ServerSystemInfo serverSystemInfo = restClient.GetServerSystemInfo();
			lblApiVersion.Text += serverSystemInfo.Version;

			lblUrl.Text += Config.Url;
			lblSiteslug.Text += Config.SiteSlug;
		}

		private void FrmAbout_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}


	}
}
