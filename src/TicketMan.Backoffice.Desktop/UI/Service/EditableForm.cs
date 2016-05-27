using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace TicketMan.Backoffice.Desktop.UI.Service
{
	public class EditableForm : XtraForm
	{
		public bool Dirty = false;

		public EditableForm()
		{
			this.Load += OnLoad;
		}

		private void OnLoad(object sender, EventArgs eventArgs)
		{
			AddOnChangeHandlerToInputControls(this);
		}

		public void AddOnChangeHandlerToInputControls(Control ctrl)
		{
			foreach (Control subctrl in ctrl.Controls)
			{
				if (subctrl is TextEdit)
					((TextEdit)subctrl).TextChanged +=
							new EventHandler(InputControls_OnChange);
				else if (subctrl is LookUpEdit)
					((LookUpEdit)subctrl).EditValueChanged +=
							new EventHandler(InputControls_OnChange);
				else if (subctrl is CheckEdit)
					((CheckEdit)subctrl).EditValueChanged +=
							new EventHandler(InputControls_OnChange);
				else if (subctrl is GridControl)
				{
					var control = (GridControl) subctrl;
					var gridview = (GridView)control.MainView;
					if(!gridview.OptionsBehavior.ReadOnly)
						control.EditorKeyPress += new KeyPressEventHandler(InputControls_KeyPress);
				}
				else
				{
					if (subctrl.Controls.Count > 0)
						this.AddOnChangeHandlerToInputControls(subctrl);
				}
			}
		}

		private void InputControls_OnChange(object sender, EventArgs e)
		{
			Dirty = true;
		}

		private void InputControls_KeyPress(object sender, KeyPressEventArgs e)
		{
			Dirty = true;
		}

	}
}
