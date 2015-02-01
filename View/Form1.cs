using HelperFramework.DataType;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WordfeudHelper.Business;

namespace WordfeudHelper.View
{
	public partial class WordfeudHelperForm : Form
	{
		private static readonly List<Word> WordsOriginal = new List<Word>();

		private delegate void EnableButtonCallback(Boolean enable);
		private delegate void FillGridCallback(IEnumerable<Word> words);

		public WordfeudHelperForm()
		{
			InitializeComponent();

			ReadLines();

			SearchTypesComboBox.ValueMember = String.Empty;
			SearchTypesComboBox.DisplayMember = "Name";
			SearchTypesComboBox.DataSource = SearchType.Get();
			SearchTypesComboBox.SelectedItem = SearchType.Contains;
		}

		#region Events;

		private void SearchButtonClick(Object sender, EventArgs e)
		{
			if ((SearchValue1CueTextBox.Enabled && SearchValue1CueTextBox.Text.Length > 0)
			 || (SearchValue2CueTextBox.Enabled && SearchValue2CueTextBox.Text.Length > 0))
			{
				String searchValue1 = SearchValue1CueTextBox.Enabled ? SearchValue1CueTextBox.Text.Trim() : String.Empty;
				String searchValue2 = SearchValue2CueTextBox.Enabled ? SearchValue2CueTextBox.Text.Trim() : String.Empty;
				SearchType searchType = SearchTypesComboBox.SelectedItem as SearchType;
				if (searchType != null)
				{
					FillData(searchValue1, searchValue2, searchType);
				}
			}
			else
			{
				WordsDataGridView.Rows.Clear();
			}
		}

		private void WordsDataGridViewSelectionChanged(Object sender, EventArgs e)
		{
			if (WordsDataGridView.SelectedCells.Count == 0) return;
			if (WordsDataGridView.Columns["Word"] == null) return;
			if (WordsDataGridView.SelectedCells[0].OwningColumn.Name == "Word") return;

			WordsDataGridView.SelectedCells[0].OwningRow.Cells["Word"].Selected = true;
		}

		private void SearchTypesComboBoxSelectedIndexChanged(Object sender, EventArgs e)
		{
			SearchType searchType = SearchTypesComboBox.SelectedItem as SearchType;
			if (searchType != null)
			{
				if (!(SearchValue1CueTextBox.Enabled = searchType.UseLetters))
				{
					SearchValue1CueTextBox.Clear();
				}
				if (!(SearchValue2CueTextBox.Enabled = searchType.UseExtra))
				{
					SearchValue2CueTextBox.Clear();
				}
			}
		}

		private void WordsDataGridViewCellFormatting(Object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (WordsDataGridView.Columns[e.ColumnIndex].DataPropertyName == "Value")
			{
				if (e.Value != null)
				{
					try
					{
						Word word = WordsDataGridView.Rows[e.RowIndex].DataBoundItem as Word;
						if (word != null)
						{
							String value = e.Value.ToString();

							Dictionary<Int32, Char> matches = word.Matches;
							if (matches.Count > 0)
							{
								List<String> values = value.ToCharArray().Select(__char =>
									__char.ToString(CultureInfo.InvariantCulture)).ToList();
								foreach (Int32 letterIndex in matches.Keys)
								{
									values[letterIndex] = String.Format(@"\ul {0} \ul0", values[letterIndex]);
								}
								value = String.Format(@"{{\rtf1\ansi\deff0{0}}}", values.Join());
							}

							e.Value = value;

							e.FormattingApplied = true;
						}
					}
					catch (FormatException)
					{
						e.FormattingApplied = false;
					}
				}
			}
		}

		private void ToolStripMenuItem2Click(Object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void ToolStripMenuItem4Click(Object sender, EventArgs e)
		{
			new AboutBox().ShowDialog();
		}

		private HelpForm _helpForm;
		private void ToolStripMenuItem3Click(Object sender, EventArgs e)
		{
			if (_helpForm == null || _helpForm.IsDisposed)
			{
				_helpForm = new HelpForm();
			}
			_helpForm.Show();
		}

		private void ToolStripStatusLabel3Click(Object sender, EventArgs e)
		{
			Process.Start("http://www.jeroenvanwarmerdam.nl");
		}

		#endregion Events;

		#region Private Methods;

		private void ReadLines()
		{
			ThreadPool.QueueUserWorkItem(__obj =>
			{
				UseWaitCursor = true;
				Cursor.Position = Cursor.Position;

				ButtonStatus(false);

				IEnumerable<String> allWords = File.ReadLines("Data/OpenTaal-210G-basis-gekeurd.txt");
				IEnumerable<String> validWords = allWords.Where(__word =>
				{
					return __word.Length >= 2
						&& __word.Length <= 15
						&& !__word.Contains(" ");
				});
				foreach (String word in validWords.Select(__word => __word.ToUpper()).Distinct())
				{
					WordsOriginal.Add(new Word(word));
				}

				ButtonStatus(true);

				toolStripStatusLabel1.Text = String.Format("{0} words; {1} valid.",
															allWords.Count(),
															WordsOriginal.Count);

				UseWaitCursor = false;
				Cursor.Position = Cursor.Position;
			});
		}

		private void FillData(String searchValue1, String searchValue2, SearchType searchType)
		{
			ThreadPool.QueueUserWorkItem(__obj =>
			{
				UseWaitCursor = true;
				Cursor.Position = Cursor.Position;

				ButtonStatus(false);

				FillGrid(null);  // Empty datagrid;

				IEnumerable<Word> wordsFiltered = searchType.MatchList(searchValue1.ToUpper(),
																	   searchValue2.ToUpper(),
																	   WordsOriginal.ToList());
				wordsFiltered = wordsFiltered.OrderByDescending(__word => __word.Points);

				FillGrid(wordsFiltered);  // Fill datagrid;

				ButtonStatus(true);

				UseWaitCursor = false;
				Cursor.Position = Cursor.Position;
			});
		}

		private void ButtonStatus(Boolean enable)
		{
			if (SearchButton.InvokeRequired)
			{
				EnableButtonCallback enableButtonCallback = ButtonStatus;
				Invoke(enableButtonCallback, new Object[] { enable });
			}
			else
			{
				SearchButton.Enabled = enable;
			}
		}

		private void FillGrid(IEnumerable<Word> words)
		{
			if (WordsDataGridView.InvokeRequired)
			{
				FillGridCallback fillGridCallback = FillGrid;
				Invoke(fillGridCallback, new Object[] { words });
			}
			else
			{
				WordsDataGridView.Rows.Clear();
				if (words != null)
				{
					WordsDataGridView.DataSource = new SortableBindingList<Word>(words);
				}
			}
		}

		#endregion Private Methods;

	}
}

