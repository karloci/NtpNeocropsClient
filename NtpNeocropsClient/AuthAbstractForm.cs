using ClassLibrary;
using CredentialManagement;
using NtpNeocropsClient.Utils;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            NeocropsState.LoggedInUser = null;
            NeocropsState.AccessToken = null;
            NeocropsState.RefreshToken = null;

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

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void farmDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FarmDetailsForm farmDetailsForm = new FarmDetailsForm();
            farmDetailsForm.Show();
        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForm usersForm = new UsersForm();
            usersForm.Show();
        }
    }
}
