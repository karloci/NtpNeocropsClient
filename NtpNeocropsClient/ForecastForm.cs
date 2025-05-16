using ClassLibrary;
using CredentialManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NtpNeocropsClient
{
    public partial class ForecastForm : Form
    {
        public ForecastForm()
        {
            InitializeComponent();
            WindowPosition.LoadWindowPosition(this);
        }

        private void ForecastForm_Move(object sender, EventArgs e)
        {
            WindowPosition.SaveWindowPosition(this);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cred = new Credential { Target = "Neocrops" };
            cred.Delete();

            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
