using ClassLibrary;
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
    public partial class UserDetailsForm : AbstractForm
    {
        private User? selectedUser = null;

        public UserDetailsForm(User? user = null)
        {
            InitializeComponent();

            if (user != null) {
                selectedUser = user;
                textBoxFullName.Text = user.FullName;
                textBoxEmail.Text = user.Email;
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text;
            string email = textBoxEmail.Text;

            if (!Validator.IsRequired(fullName) || !Validator.IsRequired(email))
            {
                MessageBox.Show(Strings.AllFieldsAreRequired);
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show(Strings.EmailIsNotInCorrectFormat);
                return;
            }

            try
            {
                var farmId = NeocropsState.LoggedInUser.UserFarm.Id;
                var data = new User();

                if (selectedUser == null)
                {
                    data = await ApiClient.PostAsync<User>($"/farm/{farmId}/users", new UserDetailsDto
                    {
                        FullName = fullName,
                        Email = email
                    });
                }
                else
                {
                    data = await ApiClient.PatchAsync<User>($"/farm/{farmId}/users/{selectedUser.Id}", new UserDetailsDto
                    {
                        FullName = fullName,
                        Email = email
                    });
                }

                if (data != null)
                {
                    MessageBox.Show(Strings.SuccessfullySaved);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
