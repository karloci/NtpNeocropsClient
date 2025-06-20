using ClassLibrary;
using CredentialManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NtpNeocropsClient
{
    public partial class AuthAbstractForm : AbstractForm
    {
        public AuthAbstractForm() : base()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cred = new Credential { Target = "Neocrops" };
            cred.Delete();

            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForecastForm forecastForm = new ForecastForm();
            forecastForm.Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfileForm profileForm = new ProfileForm();
            profileForm.Show();
        }
    }
}
