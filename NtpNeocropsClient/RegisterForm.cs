using ClassLibrary;
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
                var client = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
                var result = await client.ListOfCountryNamesByNameAsync();

                var countries = result.Body.ListOfCountryNamesByNameResult
                    .Select((c) => {
                        return new { Name = c.sName, Code = c.sISOCode };
                    })
                    .ToList();

                comboBoxCountry.DisplayMember = "Name";
                comboBoxCountry.ValueMember = "Code";
                comboBoxCountry.DataSource = countries;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dohvaćanju zemalja: " + ex.Message);
            }
        }
    }
}
