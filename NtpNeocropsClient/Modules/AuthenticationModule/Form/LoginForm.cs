using ClassLibrary;
using CredentialManagement;
using Microsoft.Win32;
using NtpNeocropsClient.Modules.Authentication.Dto;
using NtpNeocropsClient.Modules.Authentication.Entity;
using NtpNeocropsClient.Utils;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Windows.Forms;

namespace NtpNeocropsClient
{
    public partial class LoginForm : AbstractForm
    {
        public LoginForm() : base()
        {
            InitializeComponent();

            comboBoxLanguage.Items.Add(new LanguageOption { Code = "hr", DisplayName = "Hrvatski" });
            comboBoxLanguage.Items.Add(new LanguageOption { Code = "en", DisplayName = "English" });

            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\NeocropsApp\Language"))
            {
                var savedLanguage = key?.GetValue("Language") as string ?? "en";

                foreach (LanguageOption item in comboBoxLanguage.Items)
                {
                    if (item.Code == savedLanguage)
                    {
                        comboBoxLanguage.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            if (!Validator.IsRequired(email) || !Validator.IsRequired(password))
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
                var data = await ApiClient.PostAsync<AuthenticationResponseDto>("/authentication/login", new LoginRequestDto
                {
                    Email = email,
                    Password = password
                });

                if (data != null)
                {
                    NeocropsState.SaveCredentials(data.LoggedInUser.Email, data.RefreshToken);
                    NeocropsState.LoggedInUser = data.LoggedInUser;
                    NeocropsState.AccessToken = data.AccessToken;
                    NeocropsState.RefreshToken = data.RefreshToken;

                    this.Hide();
                    ForecastForm forecastForm = new ForecastForm();
                    forecastForm.Show();
                }
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLanguage.SelectedItem is LanguageOption selectedLanguage)
            {
                string languageCode = selectedLanguage.Code;

                Debug.WriteLine(languageCode);

                using (var key = Registry.CurrentUser.CreateSubKey(@"Software\NeocropsApp\Language"))
                {
                    var savedLanguage = key?.GetValue("Language") as string ?? "en";
                    if (savedLanguage != languageCode && key != null)
                    {
                        key.SetValue("Language", languageCode, RegistryValueKind.String);
                        Application.Restart();
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
