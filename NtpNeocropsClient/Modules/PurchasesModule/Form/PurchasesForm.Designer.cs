namespace NtpNeocropsClient.Modules.PurchasesModule.Form
{
    partial class PurchasesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchasesForm));
            buttonAddPurchase = new Button();
            dataGridViewPurchases = new DataGridView();
            comboBoxSort = new ComboBox();
            label1 = new Label();
            textBoxFilter = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPurchases).BeginInit();
            SuspendLayout();
            // 
            // buttonAddPurchase
            // 
            resources.ApplyResources(buttonAddPurchase, "buttonAddPurchase");
            buttonAddPurchase.Name = "buttonAddPurchase";
            buttonAddPurchase.UseVisualStyleBackColor = true;
            buttonAddPurchase.Click += buttonAddPurchase_Click;
            // 
            // dataGridViewPurchases
            // 
            dataGridViewPurchases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dataGridViewPurchases, "dataGridViewPurchases");
            dataGridViewPurchases.Name = "dataGridViewPurchases";
            // 
            // comboBoxSort
            // 
            comboBoxSort.FormattingEnabled = true;
            resources.ApplyResources(comboBoxSort, "comboBoxSort");
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
            // PurchasesForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(textBoxFilter);
            Controls.Add(label1);
            Controls.Add(comboBoxSort);
            Controls.Add(dataGridViewPurchases);
            Controls.Add(buttonAddPurchase);
            Name = "PurchasesForm";
            Load += PurchasesForm_Load;
            Controls.SetChildIndex(buttonAddPurchase, 0);
            Controls.SetChildIndex(dataGridViewPurchases, 0);
            Controls.SetChildIndex(comboBoxSort, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(textBoxFilter, 0);
            Controls.SetChildIndex(label2, 0);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPurchases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddPurchase;
        private DataGridView dataGridViewPurchases;
        private ComboBox comboBoxSort;
        private Label label1;
        private TextBox textBoxFilter;
        private Label label2;
    }
}