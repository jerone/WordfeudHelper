
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
			dataGridView1.Columns.Cast<DataGridViewColumn>().Each(__column =>
			{
				// Make columns divide evenly;
				__column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			});
		}

		// Only one HelpForm open;
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
