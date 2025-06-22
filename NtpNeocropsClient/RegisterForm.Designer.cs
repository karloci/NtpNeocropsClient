namespace NtpNeocropsClient
{
    partial class RegisterForm
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
            buttonBackToLogin = new Button();
            comboBoxCountry = new ComboBox();
            label1 = new Label();
            textBoxFullName = new TextBox();
            label2 = new Label();
            textBoxEmail = new TextBox();
            label3 = new Label();
            textBoxPassword = new TextBox();
            label4 = new Label();
            textBoxRepeatPassword = new TextBox();
            label5 = new Label();
            textBoxFarmName = new TextBox();
            label6 = new Label();
            textBoxFarmId = new TextBox();
            label7 = new Label();
            buttonRegister = new Button();
            label8 = new Label();
            textBoxFarmPostalCode = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // buttonBackToLogin
            // 
            buttonBackToLogin.Location = new Point(679, 415);
            buttonBackToLogin.Name = "buttonBackToLogin";
            buttonBackToLogin.Size = new Size(109, 23);
            buttonBackToLogin.TabIndex = 0;
            buttonBackToLogin.Text = "Back to Login";
            buttonBackToLogin.UseVisualStyleBackColor = true;
            buttonBackToLogin.Click += buttonBackToLogin_Click;
            // 
            // comboBoxCountry
            // 
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Location = new Point(424, 248);
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.Size = new Size(282, 23);
            comboBoxCountry.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 100);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 2;
            label1.Text = "Full name";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(112, 118);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(282, 23);
            textBoxFullName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(112, 164);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 4;
            label2.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(112, 182);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(282, 23);
            textBoxEmail.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(112, 230);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 6;
            label3.Text = "Password";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(112, 248);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(282, 23);
            textBoxPassword.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(112, 295);
            label4.Name = "label4";
            label4.Size = new Size(96, 15);
            label4.TabIndex = 8;
            label4.Text = "Repeat password";
            // 
            // textBoxRepeatPassword
            // 
            textBoxRepeatPassword.Location = new Point(112, 313);
            textBoxRepeatPassword.Name = "textBoxRepeatPassword";
            textBoxRepeatPassword.PasswordChar = '*';
            textBoxRepeatPassword.Size = new Size(282, 23);
            textBoxRepeatPassword.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(424, 100);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 10;
            label5.Text = "Farm name";
            // 
            // textBoxFarmName
            // 
            textBoxFarmName.Location = new Point(424, 118);
            textBoxFarmName.Name = "textBoxFarmName";
            textBoxFarmName.Size = new Size(282, 23);
            textBoxFarmName.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(424, 164);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 12;
            label6.Text = "Farm ID";
            // 
            // textBoxFarmId
            // 
            textBoxFarmId.Location = new Point(424, 182);
            textBoxFarmId.Name = "textBoxFarmId";
            textBoxFarmId.Size = new Size(282, 23);
            textBoxFarmId.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(424, 230);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 14;
            label7.Text = "Country";
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(631, 357);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(75, 23);
            buttonRegister.TabIndex = 15;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(304, 29);
            label8.Name = "label8";
            label8.Size = new Size(209, 37);
            label8.TabIndex = 16;
            label8.Text = "Create account!";
            // 
            // textBoxFarmPostalCode
            // 
            textBoxFarmPostalCode.Location = new Point(424, 313);
            textBoxFarmPostalCode.Name = "textBoxFarmPostalCode";
            textBoxFarmPostalCode.Size = new Size(282, 23);
            textBoxFarmPostalCode.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(424, 295);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 18;
            label9.Text = "Postal code";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label9);
            Controls.Add(textBoxFarmPostalCode);
            Controls.Add(label8);
            Controls.Add(buttonRegister);
            Controls.Add(label7);
            Controls.Add(textBoxFarmId);
            Controls.Add(label6);
            Controls.Add(textBoxFarmName);
            Controls.Add(label5);
            Controls.Add(textBoxRepeatPassword);
            Controls.Add(label4);
            Controls.Add(textBoxPassword);
            Controls.Add(label3);
            Controls.Add(textBoxEmail);
            Controls.Add(label2);
            Controls.Add(textBoxFullName);
            Controls.Add(label1);
            Controls.Add(comboBoxCountry);
            Controls.Add(buttonBackToLogin);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Register";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonBackToLogin;
        private ComboBox comboBoxCountry;
        private Label label1;
        private TextBox textBoxFullName;
        private Label label2;
        private TextBox textBoxEmail;
        private Label label3;
        private TextBox textBoxPassword;
        private Label label4;
        private TextBox textBoxRepeatPassword;
        private Label label5;
        private TextBox textBoxFarmName;
        private Label label6;
        private TextBox textBoxFarmId;
        private Label label7;
        private Button buttonRegister;
        private Label label8;
        private TextBox textBoxFarmPostalCode;
        private Label label9;
    }
}