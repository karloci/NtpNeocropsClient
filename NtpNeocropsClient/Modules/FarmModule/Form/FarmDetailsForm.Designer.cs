namespace NtpNeocropsClient
{
    partial class FarmDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FarmDetailsForm));
            label1 = new Label();
            label2 = new Label();
            textBoxName = new TextBox();
            label3 = new Label();
            textBoxOib = new TextBox();
            label4 = new Label();
            comboBoxCountry = new ComboBox();
            label5 = new Label();
            textBoxPostalCode = new TextBox();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // textBoxName
            // 
            resources.ApplyResources(textBoxName, "textBoxName");
            textBoxName.Name = "textBoxName";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // textBoxOib
            // 
            resources.ApplyResources(textBoxOib, "textBoxOib");
            textBoxOib.Name = "textBoxOib";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // comboBoxCountry
            // 
            resources.ApplyResources(comboBoxCountry, "comboBoxCountry");
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Name = "comboBoxCountry";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // textBoxPostalCode
            // 
            resources.ApplyResources(textBoxPostalCode, "textBoxPostalCode");
            textBoxPostalCode.Name = "textBoxPostalCode";
            // 
            // buttonSave
            // 
            resources.ApplyResources(buttonSave, "buttonSave");
            buttonSave.Name = "buttonSave";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // FarmDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonSave);
            Controls.Add(textBoxPostalCode);
            Controls.Add(label5);
            Controls.Add(comboBoxCountry);
            Controls.Add(label4);
            Controls.Add(textBoxOib);
            Controls.Add(label3);
            Controls.Add(textBoxName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FarmDetailsForm";
            Load += FarmDetailsForm_Load;
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(textBoxName, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(textBoxOib, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(comboBoxCountry, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(textBoxPostalCode, 0);
            Controls.SetChildIndex(buttonSave, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxName;
        private Label label3;
        private TextBox textBoxOib;
        private Label label4;
        private ComboBox comboBoxCountry;
        private Label label5;
        private TextBox textBoxPostalCode;
        private Button buttonSave;
    }
}