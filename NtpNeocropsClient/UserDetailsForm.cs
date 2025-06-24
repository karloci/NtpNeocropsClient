using NtpNeocropsClient.Entity;
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
    public partial class UserDetailsForm : AbstractForm
    {
        public UserDetailsForm(User? user = null)
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
