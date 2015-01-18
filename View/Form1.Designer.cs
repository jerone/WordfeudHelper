

namespace WordfeudHelper.View
{
	partial class WordfeudHelperForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordfeudHelperForm));
			this.SearchButton = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.WordsDataGridView = new System.Windows.Forms.DataGridView();
			this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Word = new HelperFramework.WinForms.DataGridViewRichTextBoxColumn();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewRichTextBoxColumn1 = new HelperFramework.WinForms.DataGridViewRichTextBoxColumn();
			this.SearchValue2CueTextBox = new HelperFramework.WinForms.CueTextBox();
			this.SearchTypesComboBox = new HelperFramework.WinForms.CueComboBox();
			this.SearchValue1CueTextBox = new HelperFramework.WinForms.CueTextBox();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.WordsDataGridView)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// SearchButton
			// 
			this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SearchButton.Enabled = false;
			this.SearchButton.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.SearchButton.ImageKey = "search.ico";
			this.SearchButton.ImageList = this.imageList1;
			this.SearchButton.Location = new System.Drawing.Point(224, 27);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(48, 48);
			this.SearchButton.TabIndex = 3;
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButtonClick);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "search.ico");
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
			this.statusStrip1.Location = new System.Drawing.Point(0, 240);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(284, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(180, 17);
			this.toolStripStatusLabel2.Spring = true;
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.IsLink = true;
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(89, 17);
			this.toolStripStatusLabel3.Text = "made by jerone";
			this.toolStripStatusLabel3.Click += new System.EventHandler(this.ToolStripStatusLabel3Click);
			// 
			// WordsDataGridView
			// 
			this.WordsDataGridView.AllowUserToAddRows = false;
			this.WordsDataGridView.AllowUserToDeleteRows = false;
			this.WordsDataGridView.AllowUserToOrderColumns = true;
			this.WordsDataGridView.AllowUserToResizeRows = false;
			this.WordsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.WordsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Points,
            this.Length,
            this.Word});
			this.WordsDataGridView.Location = new System.Drawing.Point(12, 81);
			this.WordsDataGridView.MultiSelect = false;
			this.WordsDataGridView.Name = "WordsDataGridView";
			this.WordsDataGridView.ReadOnly = true;
			this.WordsDataGridView.RowHeadersVisible = false;
			this.WordsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.WordsDataGridView.Size = new System.Drawing.Size(260, 156);
			this.WordsDataGridView.TabIndex = 6;
			this.WordsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.WordsDataGridViewCellFormatting);
			this.WordsDataGridView.SelectionChanged += new System.EventHandler(this.WordsDataGridViewSelectionChanged);
			// 
			// Points
			// 
			this.Points.DataPropertyName = "Points";
			this.Points.HeaderText = "Points";
			this.Points.Name = "Points";
			this.Points.ReadOnly = true;
			this.Points.Width = 50;
			// 
			// Length
			// 
			this.Length.DataPropertyName = "Length";
			this.Length.HeaderText = "Length";
			this.Length.Name = "Length";
			this.Length.ReadOnly = true;
			this.Length.Width = 50;
			// 
			// Word
			// 
			this.Word.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Word.DataPropertyName = "Value";
			this.Word.HeaderText = "Word";
			this.Word.Name = "Word";
			this.Word.ReadOnly = true;
			this.Word.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(284, 25);
			this.toolStrip1.TabIndex = 8;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.toolStripMenuItem2});
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
			this.toolStripDropDownButton1.Text = "File";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Enabled = false;
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
			this.toolStripMenuItem1.Text = "Open dictionary";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 22);
			this.toolStripMenuItem2.Text = "Exit";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2Click);
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
			this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
			this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(45, 22);
			this.toolStripDropDownButton2.Text = "Help";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem3.Text = "Help";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(107, 22);
			this.toolStripMenuItem4.Text = "About";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4Click);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Points";
			this.dataGridViewTextBoxColumn1.HeaderText = "Points";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 50;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Length";
			this.dataGridViewTextBoxColumn2.HeaderText = "Length";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 50;
			// 
			// dataGridViewRichTextBoxColumn1
			// 
			this.dataGridViewRichTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewRichTextBoxColumn1.DataPropertyName = "Value";
			this.dataGridViewRichTextBoxColumn1.HeaderText = "Word";
			this.dataGridViewRichTextBoxColumn1.Name = "dataGridViewRichTextBoxColumn1";
			this.dataGridViewRichTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// SearchValue2CueTextBox
			// 
			this.SearchValue2CueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SearchValue2CueTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.SearchValue2CueTextBox.CueText = "Extra value";
			this.SearchValue2CueTextBox.Location = new System.Drawing.Point(118, 55);
			this.SearchValue2CueTextBox.Name = "SearchValue2CueTextBox";
			this.SearchValue2CueTextBox.Size = new System.Drawing.Size(100, 20);
			this.SearchValue2CueTextBox.TabIndex = 7;
			// 
			// SearchTypesComboBox
			// 
			this.SearchTypesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SearchTypesComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.SearchTypesComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.SearchTypesComboBox.CueText = "Choose search type";
			this.SearchTypesComboBox.FormattingEnabled = true;
			this.SearchTypesComboBox.Location = new System.Drawing.Point(12, 28);
			this.SearchTypesComboBox.Name = "SearchTypesComboBox";
			this.SearchTypesComboBox.Size = new System.Drawing.Size(206, 21);
			this.SearchTypesComboBox.TabIndex = 1;
			this.SearchTypesComboBox.SelectedIndexChanged += new System.EventHandler(this.SearchTypesComboBoxSelectedIndexChanged);
			// 
			// SearchValue1CueTextBox
			// 
			this.SearchValue1CueTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.SearchValue1CueTextBox.CueText = "Wordfeud letters";
			this.SearchValue1CueTextBox.Location = new System.Drawing.Point(12, 55);
			this.SearchValue1CueTextBox.Name = "SearchValue1CueTextBox";
			this.SearchValue1CueTextBox.Size = new System.Drawing.Size(100, 20);
			this.SearchValue1CueTextBox.TabIndex = 2;
			// 
			// WordfeudHelperForm
			// 
			this.AcceptButton = this.SearchButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.SearchValue2CueTextBox);
			this.Controls.Add(this.WordsDataGridView);
			this.Controls.Add(this.SearchTypesComboBox);
			this.Controls.Add(this.SearchValue1CueTextBox);
			this.Controls.Add(this.SearchButton);
			this.Controls.Add(this.statusStrip1);
			this.Icon = global::WordfeudHelper.Properties.Resources.wordfeud;
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "WordfeudHelperForm";
			this.Text = "Wordfeud Helper";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.WordsDataGridView)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button SearchButton;
		private HelperFramework.WinForms.CueTextBox SearchValue1CueTextBox;
		private HelperFramework.WinForms.CueComboBox SearchTypesComboBox;
		private HelperFramework.WinForms.CueTextBox SearchValue2CueTextBox;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.DataGridView WordsDataGridView;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Points;
		private System.Windows.Forms.DataGridViewTextBoxColumn Length;
		private HelperFramework.WinForms.DataGridViewRichTextBoxColumn Word;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private HelperFramework.WinForms.DataGridViewRichTextBoxColumn dataGridViewRichTextBoxColumn1;
	}
}

