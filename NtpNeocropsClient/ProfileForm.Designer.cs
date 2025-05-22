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
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 96);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(284, 57);
            label1.TabIndex = 1;
            label1.Text = "Personal data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 196);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(119, 32);
            label2.TabIndex = 2;
            label2.Text = "Full name";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(22, 235);
            textBoxFullName.Margin = new Padding(6, 6, 6, 6);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(661, 39);
            textBoxFullName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 331);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(71, 32);
            label3.TabIndex = 4;
            label3.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(22, 369);
            textBoxEmail.Margin = new Padding(6, 6, 6, 6);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(661, 39);
            textBoxEmail.TabIndex = 5;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(548, 454);
            buttonSave.Margin = new Padding(6, 6, 6, 6);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(139, 49);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(799, 96);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(362, 57);
            label4.TabIndex = 7;
            label4.Text = "Change password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(799, 196);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(200, 32);
            label5.TabIndex = 8;
            label5.Text = "Current password";
            // 
            // textBoxCurrentPassword
            // 
            textBoxCurrentPassword.Location = new Point(799, 235);
            textBoxCurrentPassword.Margin = new Padding(6, 6, 6, 6);
            textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            textBoxCurrentPassword.PasswordChar = '*';
            textBoxCurrentPassword.Size = new Size(661, 39);
            textBoxCurrentPassword.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(799, 331);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(168, 32);
            label6.TabIndex = 10;
            label6.Text = "New password";
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.Location = new Point(799, 369);
            textBoxNewPassword.Margin = new Padding(6, 6, 6, 6);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.PasswordChar = '*';
            textBoxNewPassword.Size = new Size(661, 39);
            textBoxNewPassword.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(799, 471);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(244, 32);
            label7.TabIndex = 12;
            label7.Text = "Repeat new password";
            // 
            // textBoxRepeatNewPassword
            // 
            textBoxRepeatNewPassword.Location = new Point(799, 510);
            textBoxRepeatNewPassword.Margin = new Padding(6, 6, 6, 6);
            textBoxRepeatNewPassword.Name = "textBoxRepeatNewPassword";
            textBoxRepeatNewPassword.PasswordChar = '*';
            textBoxRepeatNewPassword.Size = new Size(661, 39);
            textBoxRepeatNewPassword.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(1209, 619);
            button1.Margin = new Padding(6, 6, 6, 6);
            button1.Name = "button1";
            button1.Size = new Size(254, 49);
            button1.TabIndex = 14;
            button1.Text = "Change password";
            button1.UseVisualStyleBackColor = true;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(button1);
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
            Location = new Point(0, 0);
            Margin = new Padding(20, 28, 20, 28);
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
            Controls.SetChildIndex(button1, 0);
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
        private Button button1;
    }
}