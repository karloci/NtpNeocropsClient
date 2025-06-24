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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace NtpNeocropsClient
{
    public partial class UsersForm : AuthAbstractForm
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private async void FetchUsers()
        {
            try
            {
                var farmId = NeocropsState.LoggedInUser.UserFarm.Id;
                var data = await ApiClient.GetAsync<List<NtpNeocropsClient.Entity.User>>($"/farm/{farmId}/users");

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

        private async void UsersForm_Load(object sender, EventArgs e)
        {
            FetchUsers();
        }

        private void DataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var user = (NtpNeocropsClient.Entity.User)dataGridViewUsers.Rows[e.RowIndex].DataBoundItem;

                var userDetailsForm = new UserDetailsForm(user);
                var result = userDetailsForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    dataGridViewUsers.CellDoubleClick -= DataGridViewUsers_CellDoubleClick;

                    dataGridViewUsers.ClearSelection();
                    dataGridViewUsers.CurrentCell = null;

                    FetchUsers();
                }
            }
        }


        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            var userDetailsForm = new UserDetailsForm();
            var result = userDetailsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                FetchUsers();
            }
        }
    }
}
