using ClassLibrary;
using CredentialManagement;
using NtpNeocropsClient.Modules.Profile.Dto;
using NtpNeocropsClient.Modules.Users.Entity;
using NtpNeocropsClient.Shared.Dto;
using NtpNeocropsClient.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NtpNeocropsClient
{
    public partial class ProfileForm : AuthAbstractForm
    {
        public ProfileForm() : base()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            AppUser? loggedInUser = NeocropsState.LoggedInUser;

            if (loggedInUser != null)
            {
                textBoxFullName.Text = loggedInUser.FullName;
                textBoxEmail.Text = loggedInUser.Email;
                LoadAvatar();
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
                var data = await ApiClient.PatchAsync<AppUser>("/profile", new UpdateProfileRequestDto
                {
                    FullName = fullName,
                    Email = email,
                });

                if (data != null)
                {
                    NeocropsState.LoggedInUser = data;

                    MessageBox.Show(Strings.SuccessfullySaved);
                    return;
                }
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private async void buttonChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = textBoxCurrentPassword.Text;
            string newPassword = textBoxNewPassword.Text;
            string repeatPassword = textBoxRepeatNewPassword.Text;

            if (!Validator.IsRequired(currentPassword) || !Validator.IsRequired(newPassword) || !Validator.IsRequired(repeatPassword))
            {
                MessageBox.Show(Strings.AllFieldsAreRequired);
                return;
            }

            if (!newPassword.Equals(repeatPassword))
            {
                MessageBox.Show(Strings.PasswordsDoesNotMatch);
                return;
            }

            if (!Validator.HasMinLength(newPassword, 8) || !Validator.HasMinLength(newPassword, 8))
            {
                MessageBox.Show(Strings.PasswordShouldHaveAtLeastEightCharacters);
                return;
            }

            try
            {
                var data = await ApiClient.PatchAsync<MessageResponseDto>("/profile/password", new ChangePasswordRequestDto
                {
                    CurrentPassword = currentPassword,
                    NewPassword = newPassword,
                    RepeatPassword = repeatPassword
                });

                if (data != null)
                {
                    MessageBox.Show(data.Message);
                    textBoxCurrentPassword.Text = "";
                    textBoxNewPassword.Text = "";
                    textBoxRepeatNewPassword.Text = "";
                    return;
                }
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private async void LoadAvatar()
        {
            var avatar = await ApiClient.GetUserAvatarAsync();
            if (avatar != null)
            {
                pictureBoxAvatar.Image = avatar;
                buttonDeleteAvatar.Show();
            }
            else
            {
                pictureBoxAvatar.Image = Properties.Resources.DefaultAvatar;
                buttonDeleteAvatar.Hide();
            }
        }

        private async void buttonSaveAvatar_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using var uploadedAvatar = Image.FromFile(filePath);

                try
                {
                    await ApiClient.UploadUserAvatarAsync<object>(uploadedAvatar);
                    LoadAvatar();
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private async void buttonDeleteAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                await ApiClient.DeleteAsync<object>("/profile/avatar");
                LoadAvatar();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
