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

            // binarna datoteka
            if (File.Exists(countriesFile))
            {
                var lastModified = File.GetLastWriteTime(countriesFile);
                if ((DateTime.Now - lastModified).TotalMinutes <= 5)
                {
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
            }

            // soap
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

            return countries;
        }
    }
}
