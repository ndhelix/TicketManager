using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TicketMan.Backoffice.Desktop.UI.dlg
{
    public partial class DlgInfoText : DevExpress.XtraEditors.XtraForm
    {
        private string _caption, _text;
        public DlgInfoText(string caption, string text)
        {
            _caption = caption;
            _text = text;
            InitializeComponent();
        }

        private void DlgInfoText_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DlgInfoText_Load(object sender, EventArgs e)
        {
            this.Text = _caption;
            memoEdit.Text = _text;
        }
    }
}