namespace NtpNeocropsClient
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonCreateAccount = new Button();
            label1 = new Label();
            textBoxEmail = new TextBox();
            label2 = new Label();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // buttonCreateAccount
            // 
            buttonCreateAccount.Location = new Point(671, 415);
            buttonCreateAccount.Name = "buttonCreateAccount";
            buttonCreateAccount.Size = new Size(117, 23);
            buttonCreateAccount.TabIndex = 0;
            buttonCreateAccount.Text = "Create account";
            buttonCreateAccount.UseVisualStyleBackColor = true;
            buttonCreateAccount.Click += buttonCreateAccount_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(273, 126);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(273, 144);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(257, 23);
            textBoxEmail.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(273, 187);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(273, 205);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(257, 23);
            textBoxPassword.TabIndex = 4;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(455, 262);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(336, 35);
            label3.Name = "label3";
            label3.Size = new Size(130, 37);
            label3.TabIndex = 6;
            label3.Text = "Welcome";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(label2);
            Controls.Add(textBoxEmail);
            Controls.Add(label1);
            Controls.Add(buttonCreateAccount);
            Name = "LoginForm";
            Text = "Login";
            Move += LoginForm_Move;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCreateAccount;
        private Label label1;
        private TextBox textBoxEmail;
        private Label label2;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Label label3;
    }
}
