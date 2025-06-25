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
            resources.ApplyResources(dataGridViewPurchases, "dataGridViewPurchases");
            dataGridViewPurchases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPurchases.Name = "dataGridViewPurchases";
            // 
            // PurchasesForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewPurchases);
            Controls.Add(buttonAddPurchase);
            Name = "PurchasesForm";
            Load += PurchasesForm_Load;
            Controls.SetChildIndex(buttonAddPurchase, 0);
            Controls.SetChildIndex(dataGridViewPurchases, 0);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPurchases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddPurchase;
        private DataGridView dataGridViewPurchases;
    }
}