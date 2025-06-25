namespace NtpNeocropsClient
{
    partial class UsersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersForm));
            dataGridViewUsers = new DataGridView();
            buttonNewUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            resources.ApplyResources(dataGridViewUsers, "dataGridViewUsers");
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Name = "dataGridViewUsers";
            // 
            // buttonNewUser
            // 
            resources.ApplyResources(buttonNewUser, "buttonNewUser");
            buttonNewUser.Name = "buttonNewUser";
            buttonNewUser.UseVisualStyleBackColor = true;
            buttonNewUser.Click += buttonNewUser_Click;
            // 
            // UsersForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonNewUser);
            Controls.Add(dataGridViewUsers);
            Name = "UsersForm";
            Load += UsersForm_Load;
            Controls.SetChildIndex(dataGridViewUsers, 0);
            Controls.SetChildIndex(buttonNewUser, 0);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewUsers;
        private Button buttonNewUser;
    }
}