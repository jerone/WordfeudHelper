
namespace WordfeudHelper.View
{
	using HelperFramework.DataType;
	using System;
	using System.Linq;
	using System.Windows.Forms;
	using WordfeudHelper.Business;

	public partial class HelpForm : Form
	{
		private Boolean _isShown;

		public HelpForm()
		{
			InitializeComponent();

			dataGridView1.DataSource = new SortableBindingList<Letter>(Letter.Get(typeof(Letter.Dutch)));
			Int32 columnWidth = (dataGridView1.Width - SystemInformation.BorderSize.Width * 2
								- SystemInformation.VerticalScrollBarWidth)
								/ dataGridView1.Columns.GetColumnCount(DataGridViewElementStates.Visible);
			dataGridView1.Columns.Cast<DataGridViewColumn>().Each(__column => __column.Width = columnWidth);
		}

		public new void Show()
		{
			if (_isShown)
			{
				this.Select();
			}
			else
			{
				base.Show();
				_isShown = true;
			}
		}
	}
}
