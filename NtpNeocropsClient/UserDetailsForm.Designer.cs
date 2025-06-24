namespace NtpNeocropsClient
{
    partial class UserDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDetailsForm));
            label1 = new Label();
            textBoxFullName = new TextBox();
            label2 = new Label();
            textBoxEmail = new TextBox();
            buttonSave = new Button();
            SuspendLayout();
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
            // buttonSave
            // 
            resources.ApplyResources(buttonSave, "buttonSave");
            buttonSave.Name = "buttonSave";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // UserDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonSave);
            Controls.Add(textBoxEmail);
            Controls.Add(label2);
            Controls.Add(textBoxFullName);
            Controls.Add(label1);
            Name = "UserDetailsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxFullName;
        private Label label2;
        private TextBox textBoxEmail;
        private Button buttonSave;
    }
}