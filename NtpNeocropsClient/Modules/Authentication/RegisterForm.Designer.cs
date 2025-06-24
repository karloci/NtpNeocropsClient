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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
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
            textBoxFarmOib = new TextBox();
            label7 = new Label();
            buttonRegister = new Button();
            label8 = new Label();
            textBoxFarmPostalCode = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // buttonBackToLogin
            // 
            resources.ApplyResources(buttonBackToLogin, "buttonBackToLogin");
            buttonBackToLogin.Name = "buttonBackToLogin";
            buttonBackToLogin.UseVisualStyleBackColor = true;
            buttonBackToLogin.Click += buttonBackToLogin_Click;
            // 
            // comboBoxCountry
            // 
            resources.ApplyResources(comboBoxCountry, "comboBoxCountry");
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Name = "comboBoxCountry";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // textBoxFullName
            // 
            resources.ApplyResources(textBoxFullName, "textBoxFullName");
            textBoxFullName.Name = "textBoxFullName";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // textBoxEmail
            // 
            resources.ApplyResources(textBoxEmail, "textBoxEmail");
            textBoxEmail.Name = "textBoxEmail";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // textBoxPassword
            // 
            resources.ApplyResources(textBoxPassword, "textBoxPassword");
            textBoxPassword.Name = "textBoxPassword";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // textBoxRepeatPassword
            // 
            resources.ApplyResources(textBoxRepeatPassword, "textBoxRepeatPassword");
            textBoxRepeatPassword.Name = "textBoxRepeatPassword";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // textBoxFarmName
            // 
            resources.ApplyResources(textBoxFarmName, "textBoxFarmName");
            textBoxFarmName.Name = "textBoxFarmName";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // textBoxFarmId
            // 
            resources.ApplyResources(textBoxFarmOib, "textBoxFarmId");
            textBoxFarmOib.Name = "textBoxFarmId";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // buttonRegister
            // 
            resources.ApplyResources(buttonRegister, "buttonRegister");
            buttonRegister.Name = "buttonRegister";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // textBoxFarmPostalCode
            // 
            resources.ApplyResources(textBoxFarmPostalCode, "textBoxFarmPostalCode");
            textBoxFarmPostalCode.Name = "textBoxFarmPostalCode";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // RegisterForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label9);
            Controls.Add(textBoxFarmPostalCode);
            Controls.Add(label8);
            Controls.Add(buttonRegister);
            Controls.Add(label7);
            Controls.Add(textBoxFarmOib);
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
        private TextBox textBoxFarmOib;
        private Label label7;
        private Button buttonRegister;
        private Label label8;
        private TextBox textBoxFarmPostalCode;
        private Label label9;
    }
}