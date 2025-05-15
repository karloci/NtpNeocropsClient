using ClassLibrary;
using NtpNeocropsClient.Entity;
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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            WindowPosition.LoadWindowPosition(this);
        }

        private void buttonBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void RegisterForm_Move(object sender, EventArgs e)
        {
            WindowPosition.SaveWindowPosition(this);
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
                countries = await LoadCountriesFromSoapAsync();

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

        private async Task<List<Country>> LoadCountriesFromSoapAsync()
        {
            var countries = new List<Country>();

            var client = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
            var result = await client.ListOfCountryNamesByNameAsync();

            countries = result.Body.ListOfCountryNamesByNameResult
                .Select(c => new Country { Name = c.sName, Code = c.sISOCode })
                .ToList();

            return countries;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string repeatPassword = textBoxRepeatPassword.Text;
            string farmName = textBoxFarmName.Text;
            string farmId = textBoxFarmId.Text;
            string country = comboBoxCountry.SelectedValue?.ToString() ?? "";

            if(
                !Validator.IsRequired(fullName) 
                || !Validator.IsRequired(email) 
                || !Validator.IsRequired(password)
                || !Validator.IsRequired(repeatPassword)
                || !Validator.IsRequired(farmName)
                || !Validator.IsRequired(farmId)
                || !Validator.IsRequired(country)
            )
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            if( !Validator.IsValidEmail(email) )
            {
                MessageBox.Show("Email is not in correct format!");
                return;
            }

            if (!password.Equals(repeatPassword))
            {
                MessageBox.Show("Passwords does not match!");
                return;
            }

            if (!Validator.IsValidOib(farmId))
            {
                MessageBox.Show("Farm ID is not in correct format!");
                return;
            }

            MessageBox.Show("OK");
            return;
        }
    }
}
