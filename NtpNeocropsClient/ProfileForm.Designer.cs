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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
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
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // textBoxFullName
            // 
            resources.ApplyResources(textBoxFullName, "textBoxFullName");
            textBoxFullName.Name = "textBoxFullName";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // textBoxEmail
            // 
            resources.ApplyResources(textBoxEmail, "textBoxEmail");
            textBoxEmail.Name = "textBoxEmail";
            // 
            // buttonSave
            // 
            resources.ApplyResources(buttonSave, "buttonSave");
            buttonSave.Name = "buttonSave";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // textBoxCurrentPassword
            // 
            resources.ApplyResources(textBoxCurrentPassword, "textBoxCurrentPassword");
            textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // textBoxNewPassword
            // 
            resources.ApplyResources(textBoxNewPassword, "textBoxNewPassword");
            textBoxNewPassword.Name = "textBoxNewPassword";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // textBoxRepeatNewPassword
            // 
            resources.ApplyResources(textBoxRepeatNewPassword, "textBoxRepeatNewPassword");
            textBoxRepeatNewPassword.Name = "textBoxRepeatNewPassword";
            // 
            // buttonChangePassword
            // 
            resources.ApplyResources(buttonChangePassword, "buttonChangePassword");
            buttonChangePassword.Name = "buttonChangePassword";
            buttonChangePassword.UseVisualStyleBackColor = true;
            buttonChangePassword.Click += buttonChangePassword_Click;
            // 
            // ProfileForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
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
            Name = "ProfileForm";
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