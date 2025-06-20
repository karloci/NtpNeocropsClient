namespace NtpNeocropsClient
{
    partial class ProfileForm
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
            textBoxFullName = new TextBox();
            label3 = new Label();
            textBoxEmail = new TextBox();
            buttonSave = new Button();
            label4 = new Label();
            label5 = new Label();
            textBoxCurrentPassword = new TextBox();
            label6 = new Label();
            textBoxNewPassword = new TextBox();
            label7 = new Label();
            textBoxRepeatNewPassword = new TextBox();
            buttonChangePassword = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 45);
            label1.Name = "label1";
            label1.Size = new Size(142, 30);
            label1.TabIndex = 1;
            label1.Text = "Personal data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 92);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 2;
            label2.Text = "Full name";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(12, 110);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(358, 23);
            textBoxFullName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 155);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(12, 173);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(358, 23);
            textBoxEmail.TabIndex = 5;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(295, 213);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(430, 45);
            label4.Name = "label4";
            label4.Size = new Size(183, 30);
            label4.TabIndex = 7;
            label4.Text = "Change password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(430, 92);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 8;
            label5.Text = "Current password";
            // 
            // textBoxCurrentPassword
            // 
            textBoxCurrentPassword.Location = new Point(430, 110);
            textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            textBoxCurrentPassword.PasswordChar = '*';
            textBoxCurrentPassword.Size = new Size(358, 23);
            textBoxCurrentPassword.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(430, 155);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 10;
            label6.Text = "New password";
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.Location = new Point(430, 173);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.PasswordChar = '*';
            textBoxNewPassword.Size = new Size(358, 23);
            textBoxNewPassword.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(430, 221);
            label7.Name = "label7";
            label7.Size = new Size(121, 15);
            label7.TabIndex = 12;
            label7.Text = "Repeat new password";
            // 
            // textBoxRepeatNewPassword
            // 
            textBoxRepeatNewPassword.Location = new Point(430, 239);
            textBoxRepeatNewPassword.Name = "textBoxRepeatNewPassword";
            textBoxRepeatNewPassword.PasswordChar = '*';
            textBoxRepeatNewPassword.Size = new Size(358, 23);
            textBoxRepeatNewPassword.TabIndex = 13;
            // 
            // buttonChangePassword
            // 
            buttonChangePassword.Location = new Point(651, 290);
            buttonChangePassword.Name = "buttonChangePassword";
            buttonChangePassword.Size = new Size(137, 23);
            buttonChangePassword.TabIndex = 14;
            buttonChangePassword.Text = "Change password";
            buttonChangePassword.UseVisualStyleBackColor = true;
            buttonChangePassword.Click += buttonChangePassword_Click;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonChangePassword);
            Controls.Add(textBoxRepeatNewPassword);
            Controls.Add(label7);
            Controls.Add(textBoxNewPassword);
            Controls.Add(label6);
            Controls.Add(textBoxCurrentPassword);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(buttonSave);
            Controls.Add(textBoxEmail);
            Controls.Add(label3);
            Controls.Add(textBoxFullName);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(11, 13, 11, 13);
            Name = "ProfileForm";
            Text = "Profile";
            Load += ProfileForm_Load;
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(textBoxFullName, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(textBoxEmail, 0);
            Controls.SetChildIndex(buttonSave, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(textBoxCurrentPassword, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(textBoxNewPassword, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(textBoxRepeatNewPassword, 0);
            Controls.SetChildIndex(buttonChangePassword, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxFullName;
        private Label label3;
        private TextBox textBoxEmail;
        private Button buttonSave;
        private Label label4;
        private Label label5;
        private TextBox textBoxCurrentPassword;
        private Label label6;
        private TextBox textBoxNewPassword;
        private Label label7;
        private TextBox textBoxRepeatNewPassword;
        private Button buttonChangePassword;
    }
}