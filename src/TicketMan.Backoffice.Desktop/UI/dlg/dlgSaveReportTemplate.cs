using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicketMan.Backoffice.Desktop
{
	public partial class DlgSaveReportTemplate : Form
	{
		public string name, code;
		public List<string> TypeCodes { get; set; }

		public DlgSaveReportTemplate(string code, List<string> typecodes, string name)
		{
			InitializeComponent();

			txtCode.Text = code;
			txtType.Text = string.Join("; ", typecodes.ToArray());
			TypeCodes = typecodes;
			txtName.Text = name;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			//TypeCodes = new List<string> {txtType.Text};
			name = txtName.Text;
			code = txtCode.Text;
			this.DialogResult = DialogResult.OK;
		}
	}
}
