namespace NtpNeocropsClient.Modules.InventoryModule.Form
{
    partial class StocksForm
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
            dataGridViewStocks = new DataGridView();
            comboBoxSort = new ComboBox();
            label1 = new Label();
            textBoxFilter = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStocks).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStocks
            // 
            dataGridViewStocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStocks.Location = new Point(12, 56);
            dataGridViewStocks.Name = "dataGridViewStocks";
            dataGridViewStocks.Size = new Size(776, 382);
            dataGridViewStocks.TabIndex = 1;
            // 
            // comboBoxSort
            // 
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.Location = new Point(667, 27);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new Size(121, 23);
            comboBoxSort.TabIndex = 2;
            comboBoxSort.SelectedIndexChanged += comboBoxSort_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(614, 30);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Sort by:";
            // 
            // textBoxFilter
            // 
            textBoxFilter.Location = new Point(508, 27);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(100, 23);
            textBoxFilter.TabIndex = 4;
            textBoxFilter.TextChanged += textBoxFilter_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(450, 30);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 5;
            label2.Text = "Filter by:";
            // 
            // StocksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(textBoxFilter);
            Controls.Add(label1);
            Controls.Add(comboBoxSort);
            Controls.Add(dataGridViewStocks);
            Name = "StocksForm";
            Text = "Stock status";
            Load += StocksForm_Load;
            Controls.SetChildIndex(dataGridViewStocks, 0);
            Controls.SetChildIndex(comboBoxSort, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(textBoxFilter, 0);
            Controls.SetChildIndex(label2, 0);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStocks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStocks;
        private ComboBox comboBoxSort;
        private Label label1;
        private TextBox textBoxFilter;
        private Label label2;
    }
}