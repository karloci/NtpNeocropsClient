using ClassLibrary;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Entity;
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
                var countries = await GetCountriesAsync();

                comboBoxCountry.DisplayMember = "Name";
                comboBoxCountry.ValueMember = "Code";
                comboBoxCountry.DataSource = countries;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task<List<Country>> GetCountriesAsync()
        {
            var countries = new List<Country>();

            string cacheDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");
            Directory.CreateDirectory(cacheDir);

            string countriesFile = Path.Combine(cacheDir, "countries.bin");
            if (File.Exists(countriesFile) && (DateTime.Now - File.GetLastWriteTime(countriesFile)).TotalMinutes <= 5)
            {
                countries = LoadCountriesFromFile(countriesFile);
            }
            else
            {
                var client = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
                var result = await client.ListOfCountryNamesByNameAsync();

                countries = result.Body.ListOfCountryNamesByNameResult
                    .Select(c => new Country { Name = c.sName, Code = c.sISOCode })
                    .ToList();

                using (var fs = new FileStream(countriesFile, FileMode.Create, FileAccess.Write))
                using (var writer = new BinaryWriter(fs))
                {
                    writer.Write(countries.Count);
                    foreach (var country in countries)
                    {
                        writer.Write(country.Name);
                        writer.Write(country.Code);
                    }
                }
            }

            return countries;
        }

        private List<Country> LoadCountriesFromFile(string countriesFile)
        {
            var countries = new List<Country>();

            using (var fs = new FileStream(countriesFile, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs))
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string name = reader.ReadString();
                    string code = reader.ReadString();
                    countries.Add(new Country { Name = name, Code = code });
                }
            }

            return countries;
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string repeatPassword = textBoxRepeatPassword.Text;
            string farmName = textBoxFarmName.Text;
            string farmId = textBoxFarmId.Text;
            string country = comboBoxCountry.SelectedValue?.ToString() ?? "";
            string farmPostalCode = textBoxFarmPostalCode.Text;

            if (
                !Validator.IsRequired(fullName)
                || !Validator.IsRequired(email)
                || !Validator.IsRequired(password)
                || !Validator.IsRequired(repeatPassword)
                || !Validator.IsRequired(farmName)
                || !Validator.IsRequired(farmId)
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

            if (!Validator.IsValidOib(farmId))
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
                    FarmOib = farmId,
                    FarmCountryIsoCode = country,
                    FarmPostalCode = farmPostalCode,
                });

                if (data != null)
                {
                    NeocropsState.SaveCredentials(data.User.Email, data.RefreshToken);
                    NeocropsState.LoggedInUser = data.User;
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
