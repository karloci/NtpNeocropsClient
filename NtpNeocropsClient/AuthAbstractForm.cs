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
    public partial class AuthAbstractForm : Form
    {
        public AuthAbstractForm() : base()
        {
            InitializeComponent();
            WindowPosition.LoadWindowPosition(this);
        }

        private void AuthAbstractForm_Load(object sender, EventArgs e)
        {
            WindowPosition.LoadWindowPosition(this);
        }

        private void AuthAbstractForm_Move(object sender, EventArgs e)
        {
            WindowPosition.SaveWindowPosition(this);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cred = new Credential { Target = "Neocrops" };
            cred.Delete();

            WindowPosition.SaveWindowPosition(this);
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowPosition.SaveWindowPosition(this);
            this.Hide();
            ForecastForm forecastForm = new ForecastForm();
            forecastForm.Show();
        }
    }
}
