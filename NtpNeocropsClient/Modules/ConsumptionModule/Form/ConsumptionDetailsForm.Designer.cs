namespace NtpNeocropsClient.Modules.ConsumptionModule.Form
{
    partial class ConsumptionDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsumptionDetailsForm));
            label1 = new Label();
            comboBoxSupply = new ComboBox();
            label2 = new Label();
            textBoxAmount = new TextBox();
            label4 = new Label();
            dateTimePickerDate = new DateTimePicker();
            label6 = new Label();
            buttonSave = new Button();
            buttonDelete = new Button();
            textBoxComment = new TextBox();
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
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
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
            // textBoxComment
            // 
            resources.ApplyResources(textBoxComment, "textBoxComment");
            textBoxComment.Name = "textBoxComment";
            // 
            // ConsumptionDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonDelete);
            Controls.Add(buttonSave);
            Controls.Add(textBoxComment);
            Controls.Add(label6);
            Controls.Add(dateTimePickerDate);
            Controls.Add(label4);
            Controls.Add(textBoxAmount);
            Controls.Add(label2);
            Controls.Add(comboBoxSupply);
            Controls.Add(label1);
            Name = "ConsumptionDetailsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxSupply;
        private Label label2;
        private TextBox textBoxAmount;
        private Label label4;
        private DateTimePicker dateTimePickerDate;
        private Label label6;
        private Button buttonSave;
        private Button buttonDelete;
        private TextBox textBoxComment;
    }
}