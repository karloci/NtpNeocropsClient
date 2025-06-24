using ClassLibrary;
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
    public partial class AbstractForm : Form
    {
        public AbstractForm()
        {
            InitializeComponent();
        }

        private void AbstractForm_Load(object sender, EventArgs e)
        {
            WindowPosition.LoadWindowPosition(this);
        }

        private void AbstractForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowPosition.SaveWindowPosition(this);
        }

        private void AbstractForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            WindowPosition.SaveWindowPosition(this);
        }

        private void AbstractForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                WindowPosition.SaveWindowPosition(this);
            }
        }
    }
}
