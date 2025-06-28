namespace NtpNeocropsClient.Modules.PurchasesModule.Form
{
    partial class PurchaseDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseDetailsForm));
            label1 = new Label();
            comboBoxSupply = new ComboBox();
            label2 = new Label();
            textBoxAmount = new TextBox();
            label3 = new Label();
            textBoxPrice = new TextBox();
            label4 = new Label();
            dateTimePickerDate = new DateTimePicker();
            label5 = new Label();
            textBoxInvoiceNo = new TextBox();
            label6 = new Label();
            textBoxComment = new TextBox();
            buttonSave = new Button();
            buttonDelete = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // comboBoxSupply
            // 
            resources.ApplyResources(comboBoxSupply, "comboBoxSupply");
            comboBoxSupply.FormattingEnabled = true;
            comboBoxSupply.Name = "comboBoxSupply";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // textBoxAmount
            // 
            resources.ApplyResources(textBoxAmount, "textBoxAmount");
            textBoxAmount.Name = "textBoxAmount";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // textBoxPrice
            // 
            resources.ApplyResources(textBoxPrice, "textBoxPrice");
            textBoxPrice.Name = "textBoxPrice";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // dateTimePickerDate
            // 
            resources.ApplyResources(dateTimePickerDate, "dateTimePickerDate");
            dateTimePickerDate.Name = "dateTimePickerDate";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // textBoxInvoiceNo
            // 
            resources.ApplyResources(textBoxInvoiceNo, "textBoxInvoiceNo");
            textBoxInvoiceNo.Name = "textBoxInvoiceNo";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // textBoxComment
            // 
            resources.ApplyResources(textBoxComment, "textBoxComment");
            textBoxComment.Name = "textBoxComment";
            // 
            // buttonSave
            // 
            resources.ApplyResources(buttonSave, "buttonSave");
            buttonSave.Name = "buttonSave";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonDelete
            // 
            resources.ApplyResources(buttonDelete, "buttonDelete");
            buttonDelete.Name = "buttonDelete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // PurchaseDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonDelete);
            Controls.Add(buttonSave);
            Controls.Add(textBoxComment);
            Controls.Add(label6);
            Controls.Add(textBoxInvoiceNo);
            Controls.Add(label5);
            Controls.Add(dateTimePickerDate);
            Controls.Add(label4);
            Controls.Add(textBoxPrice);
            Controls.Add(label3);
            Controls.Add(textBoxAmount);
            Controls.Add(label2);
            Controls.Add(comboBoxSupply);
            Controls.Add(label1);
            Name = "PurchaseDetailsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxSupply;
        private Label label2;
        private TextBox textBoxAmount;
        private Label label3;
        private TextBox textBoxPrice;
        private Label label4;
        private DateTimePicker dateTimePickerDate;
        private Label label5;
        private TextBox textBoxInvoiceNo;
        private Label label6;
        private TextBox textBoxComment;
        private Button buttonSave;
        private Button buttonDelete;
    }
}