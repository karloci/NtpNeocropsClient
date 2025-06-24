using ClassLibrary;
using NtpNeocropsClient.Modules.Users.Dto;
using NtpNeocropsClient.Modules.Users.Entity;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NtpNeocropsClient
{
    public partial class UserDetailsForm : AbstractForm
    {
        private AppUser? selectedUser = null;

        public UserDetailsForm(AppUser? user = null)
        {
            InitializeComponent();

            if (user != null)
            {
                selectedUser = user;
                textBoxFullName.Text = user.FullName;
                textBoxEmail.Text = user.Email;
            }
            else
            {
                buttonDelete.Hide();
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

            var farmId = NeocropsState.LoggedInUser?.UserFarm.Id;

            if (farmId != null) {
                try
                {
                    if (selectedUser == null)
                    {
                        var data = await ApiClient.PostAsync<AppUser>($"/farm/{farmId}/users", new UserDetailsDto
                        {
                            FullName = fullName,
                            Email = email
                        });

                        if (data != null)
                        {
                            MessageBox.Show(Strings.SuccessfullySaved);
                        }
                    }
                    else
                    {
                        var data = await ApiClient.PatchAsync<AppUser>($"/farm/{farmId}/users/{selectedUser.Id}", new UserDetailsDto
                        {
                            FullName = fullName,
                            Email = email
                        });

                        if (data != null)
                        {
                            MessageBox.Show(Strings.SuccessfullyUpdated);
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            var farmId = NeocropsState.LoggedInUser?.UserFarm.Id;

            if (selectedUser != null && farmId != null)
            {
                var result = MessageBox.Show(
                    Strings.AreYouSure,
                    Strings.Confirm,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    await ApiClient.DeleteAsync<object>($"/farm/{farmId}/users/{selectedUser.Id}");

                    MessageBox.Show(Strings.SuccessfullyDeleted);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
    }
}
