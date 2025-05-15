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
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonBackToLogin);
            Name = "RegisterForm";
            Text = "Register";
            Move += RegisterForm_Move;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonBackToLogin;
    }
}