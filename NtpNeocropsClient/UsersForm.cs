using ClassLibrary;
using Microsoft.VisualBasic.ApplicationServices;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Entity;
using NtpNeocropsClient.Utils;
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
    public partial class UsersForm : AuthAbstractForm
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private async void UsersForm_Load(object sender, EventArgs e)
        {
            try
            {
                var farmId = NeocropsState.LoggedInUser.UserFarm.Id;
                var data = await ApiClient.GetAsync<List<NtpNeocropsClient.Entity.User>>($"/users/{farmId}");

                if (data != null)
                {
                    dataGridViewUsers.DataSource = data;
                    dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewUsers.CellDoubleClick += DataGridViewUsers_CellDoubleClick;
                    dataGridViewUsers.ReadOnly = true;

                    dataGridViewUsers.Columns["Id"].Visible = false;
                    dataGridViewUsers.Columns["userFarm"].Visible = false;

                    dataGridViewUsers.Columns["FullName"].HeaderText = Strings.FullName;
                    dataGridViewUsers.Columns["Email"].HeaderText = Strings.Email;


                }
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var user = (NtpNeocropsClient.Entity.User)dataGridViewUsers.Rows[e.RowIndex].DataBoundItem;

                var userDetailsForm = new UserDetailsForm(user);
                userDetailsForm.ShowDialog();
            }
        }

        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            var userDetailsForm = new UserDetailsForm();
            userDetailsForm.ShowDialog();
        }
    }
}
