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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StocksForm));
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
            resources.ApplyResources(dataGridViewStocks, "dataGridViewStocks");
            dataGridViewStocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStocks.Name = "dataGridViewStocks";
            // 
            // comboBoxSort
            // 
            resources.ApplyResources(comboBoxSort, "comboBoxSort");
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.SelectedIndexChanged += comboBoxSort_SelectedIndexChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // textBoxFilter
            // 
            resources.ApplyResources(textBoxFilter, "textBoxFilter");
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.TextChanged += textBoxFilter_TextChanged;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // StocksForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(textBoxFilter);
            Controls.Add(label1);
            Controls.Add(comboBoxSort);
            Controls.Add(dataGridViewStocks);
            Name = "StocksForm";
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