namespace NtpNeocropsClient
{
    partial class AuthAbstractForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthAbstractForm));
            menuStrip1 = new MenuStrip();
            accountToolStripMenuItem = new ToolStripMenuItem();
            profileToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            dashboardToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Items.AddRange(new ToolStripItem[] { accountToolStripMenuItem, dashboardToolStripMenuItem, usersToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            resources.ApplyResources(accountToolStripMenuItem, "accountToolStripMenuItem");
            accountToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { profileToolStripMenuItem, logoutToolStripMenuItem });
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            // 
            // profileToolStripMenuItem
            // 
            resources.ApplyResources(profileToolStripMenuItem, "profileToolStripMenuItem");
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Click += profileToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            resources.ApplyResources(logoutToolStripMenuItem, "logoutToolStripMenuItem");
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // dashboardToolStripMenuItem
            // 
            resources.ApplyResources(dashboardToolStripMenuItem, "dashboardToolStripMenuItem");
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Click += dashboardToolStripMenuItem_Click;
            // 
            // usersToolStripMenuItem
            // 
            resources.ApplyResources(usersToolStripMenuItem, "usersToolStripMenuItem");
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Click += usersToolStripMenuItem_Click;
            // 
            // AuthAbstractForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AuthAbstractForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem dashboardToolStripMenuItem;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem;
    }
}