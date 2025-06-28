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
            ((System.ComponentModel.ISupportInitialize)dataGridViewStocks).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStocks
            // 
            dataGridViewStocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStocks.Location = new Point(12, 27);
            dataGridViewStocks.Name = "dataGridViewStocks";
            dataGridViewStocks.Size = new Size(776, 411);
            dataGridViewStocks.TabIndex = 1;
            // 
            // StocksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewStocks);
            Name = "StocksForm";
            Text = "Stock status";
            Load += StocksForm_Load;
            Controls.SetChildIndex(dataGridViewStocks, 0);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStocks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStocks;
    }
}