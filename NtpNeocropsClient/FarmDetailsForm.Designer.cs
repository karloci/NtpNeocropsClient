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
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(129, 30);
            label1.TabIndex = 1;
            label1.Text = "Farm details";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 91);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(376, 23);
            textBoxName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 145);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 4;
            label3.Text = "ID";
            // 
            // textBoxId
            // 
            textBoxOib.Location = new Point(12, 163);
            textBoxOib.Name = "textBoxId";
            textBoxOib.Size = new Size(376, 23);
            textBoxOib.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 220);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 6;
            label4.Text = "Country";
            // 
            // comboBoxCountry
            // 
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Location = new Point(12, 238);
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.Size = new Size(376, 23);
            comboBoxCountry.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 297);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 8;
            label5.Text = "Postal code";
            // 
            // textBoxPostalCode
            // 
            textBoxPostalCode.Location = new Point(12, 315);
            textBoxPostalCode.Name = "textBoxPostalCode";
            textBoxPostalCode.Size = new Size(376, 23);
            textBoxPostalCode.TabIndex = 9;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(313, 372);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // FarmDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Text = "FarmDetailsForm";
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