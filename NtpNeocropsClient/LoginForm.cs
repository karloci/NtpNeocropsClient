using ClassLibrary;
using CredentialManagement;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Entity;
using NtpNeocropsClient.Utils;
using System.Net;

namespace NtpNeocropsClient
{
    public partial class LoginForm : AbstractForm
    {
        public LoginForm(): base()
        {
            InitializeComponent();
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
                MessageBox.Show("All fields are required!");
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Email is not in correct format!");
                return;
            }

            try
            {
                var data = await ApiClient.PostAsync<AuthenticationResponseDto>("/login", new AuthenticationRequestDto
                {
                    Email = email,
                    Password = password
                });

                if (data != null)
                {
                    var cred = new Credential
                    {
                        Target = "Neocrops",
                        Username = data.User.Email,
                        Password = data.RefreshToken,
                        Type = CredentialType.Generic,
                        PersistanceType = PersistanceType.LocalComputer
                    };
                    cred.Save();

                    NeocropsState.LoggedInUser = data.User;

                    this.Hide();
                    ForecastForm forecastForm = new ForecastForm();
                    forecastForm.Show();
                }
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Wrong email or password!");
                    return;
                }
                else if (ex.StatusCode == HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Server error!");
                    return;
                }
            }
        }
    }
}
