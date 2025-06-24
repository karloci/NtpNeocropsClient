using ClassLibrary;
using NtpNeocropsClient.Modules.Authentication.Dto;
using NtpNeocropsClient.Modules.CountryModule.Service;
using NtpNeocropsClient.Utils;
using ServiceReference;
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
    public partial class RegisterForm : AbstractForm
    {
        public RegisterForm() : base()
        {
            InitializeComponent();
        }

        private void buttonBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private async void RegisterForm_Load(object sender, EventArgs e)
        {
            try
            {
                var countries = await CountryService.GetCountriesAsync();

                comboBoxCountry.DisplayMember = "Name";
                comboBoxCountry.ValueMember = "Code";
                comboBoxCountry.DataSource = countries;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string repeatPassword = textBoxRepeatPassword.Text;
            string farmName = textBoxFarmName.Text;
            string farmOib = textBoxFarmOib.Text;
            string country = comboBoxCountry.SelectedValue?.ToString() ?? "";
            string farmPostalCode = textBoxFarmPostalCode.Text;

            if (
                !Validator.IsRequired(fullName)
                || !Validator.IsRequired(email)
                || !Validator.IsRequired(password)
                || !Validator.IsRequired(repeatPassword)
                || !Validator.IsRequired(farmName)
                || !Validator.IsRequired(farmOib)
                || !Validator.IsRequired(country)
                || !Validator.IsRequired(farmPostalCode)
            )
            {
                MessageBox.Show(Strings.AllFieldsAreRequired);
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show(Strings.EmailIsNotInCorrectFormat);
                return;
            }

            if (!password.Equals(repeatPassword))
            {
                MessageBox.Show(Strings.PasswordsDoesNotMatch);
                return;
            }

            if (!Validator.IsValidOib(farmOib))
            {
                MessageBox.Show(Strings.FarmIdIsNotInCorrectFormat);
                return;
            }

            if (!Validator.HasMinLength(farmPostalCode, 5) || !Validator.HasMaxLength(farmPostalCode, 5))
            {
                MessageBox.Show(Strings.PostalCodeMustHaveFiveCharacters);
                return;
            }

            try
            {
                var data = await ApiClient.PostAsync<AuthenticationResponseDto>("/authentication/register", new RegisterRequestDto
                {
                    FullName = fullName,
                    Email = email,
                    Password = password,
                    RepeatPassword = repeatPassword,
                    FarmName = farmName,
                    FarmOib = farmOib,
                    FarmCountryIsoCode = country,
                    FarmPostalCode = farmPostalCode,
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
    }
}
