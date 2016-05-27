using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace TicketMan.Backoffice.Desktop
{
		public partial class DateRangeControl : UserControl
		{
				public DateTime From;
				public DateTime To;

				[EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
				DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
				Bindable(true)]
				public override string Text
				{
						get { return labelControl1.Text; }
						set { labelControl1.Text = value; }
				}

				public delegate void DateRangeChangedHandler(object sender, EventArgs e);
				public event DateRangeChangedHandler DateRangeChanged;


				public DateRangeControl()
				{
						InitializeComponent();

						From = dtTrim(DateTime.Now);
						To = dtTrim(DateTime.Now.AddDays(1));

						lookUpDate.EditValueChanged += lookUpOrderDate_EditValueChanged;
				}

				void lookUpOrderDate_EditValueChanged(object sender, EventArgs e)
				{
						if (lookUpDate.EditValue is StubIgnore)
						{
								panelDate.Visible = true;
								From = dtTrim(dateEditFrom.DateTime);
								To = dtTrim(dateEditTo.DateTime.AddDays(1));
						}
						else
						{
								panelDate.Visible = false;
								From = dtTrim(((DateRelative)lookUpDate.EditValue).DateFrom());
								To = dtTrim(DateTime.Now.AddDays(1));

								if (DateRangeChanged != null)
										DateRangeChanged(sender, e);
						}
				}

				private DateTime dtTrim(DateTime dt)
				{
						return new DateTime(dt.Year, dt.Month, dt.Day);
				}

				private void DateRangeControl_Load(object sender, EventArgs e)
				{

						dateEditFrom.DateTime = DateTime.Now.AddMonths(-1);
						dateEditTo.DateTime = DateTime.Now;

						lookUpDate.Properties.DataSource = DateFilterData.getRelativePeriodList();
						lookUpDate.Properties.DisplayMember = "name";
						lookUpDate.Properties.ValueMember = "filterobj";
						lookUpDate.Properties.PopulateColumns();
						lookUpDate.Properties.ShowHeader = false;
						lookUpDate.SelectedText = "Today";
						lookUpDate.EditValue = lookUpDate.Properties.GetDataSourceValue(lookUpDate.Properties.ValueMember, 0);
						lookUpDate.Properties.Columns[1].Visible = false;
				}

				private void btnDateFilterApply_Click(object sender, EventArgs e)
				{
						From = dtTrim(dateEditFrom.DateTime);
						To = dtTrim(dateEditTo.DateTime.AddDays(1));

						if (DateRangeChanged != null)
								this.DateRangeChanged(sender, e);
				}

				private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
				{
						From = dtTrim(dateEditFrom.DateTime);
				}

				private void dateEditTo_EditValueChanged(object sender, EventArgs e)
				{
						To = dtTrim(dateEditFrom.DateTime.AddDays(1));
				}
		}


		static class DateFilterData
		{
				//static List<DateFilterStruct> list;

				public static DataTable getRelativePeriodList()
				{
						var dt = new DataTable();
						dt.Columns.Add("name", Type.GetType("System.String"));
						dt.Columns.Add("filterobj", Type.GetType("System.Object"));

						dt.Rows.Add("Сегодня", new DateRelative(0, "day"));
						dt.Rows.Add("За два дня", new DateRelative(-1, "day"));
						dt.Rows.Add("За неделю", new DateRelative(-1, "week"));
						dt.Rows.Add("За две недели", new DateRelative(-2, "week"));
						dt.Rows.Add("За месяц", new DateRelative(-1, "month"));
						dt.Rows.Add("За два месяца", new DateRelative(-2, "month"));
						dt.Rows.Add("Все", new DateRelative(-100, "year"));
						dt.Rows.Add("Выбор...", new StubIgnore());

						return dt;
				}
		}

		class StubIgnore
		{
		}

		struct DateRelative
		{
				readonly int _relativefrom;
				readonly string _interval;

				public DateRelative(int relativefrom, string interval)
				{
						this._relativefrom = relativefrom;
						_interval = interval;
				}

				public DateTime DateFrom()
				{
						var ret = DateTime.Now.AddDays(-1);
						switch (_interval)
						{
								case "day":
										ret = DateTime.Now.AddDays(_relativefrom);
										break;
								case "week":
										ret = DateTime.Now.AddDays(_relativefrom * 7);
										ret = ret.AddDays(1);
										break;
								case "month":
										ret = DateTime.Now.AddMonths(_relativefrom);
										ret = ret.AddDays(1);
										break;
								case "year":
										ret = DateTime.Now.AddYears(_relativefrom);
										ret = ret.AddDays(1);
										break;
						}
						return ret;
				}
		}

}
