using ClassLibrary;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Entity;
using NtpNeocropsClient.Service;
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
    public partial class FarmDetailsForm : AuthAbstractForm
    {
        public FarmDetailsForm()
        {
            InitializeComponent();
        }

        private async void FarmDetailsForm_Load(object sender, EventArgs e)
        {
            Farm userFarm = NeocropsState.LoggedInUser.UserFarm;

            if (userFarm != null)
            {
                textBoxName.Text = userFarm.Name;
                textBoxOib.Text = userFarm.Oib;
                textBoxPostalCode.Text = userFarm.PostalCode;
            }

            try
            {
                var countries = await CountryService.GetCountriesAsync();

                comboBoxCountry.DisplayMember = "Name";
                comboBoxCountry.ValueMember = "Code";
                comboBoxCountry.DataSource = countries;

                if (userFarm != null)
                {
                    comboBoxCountry.SelectedValue = userFarm.CountryIsoCode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void buttonSave_Click(object sender, EventArgs e)
        {
            string farmName = textBoxName.Text;
            string farmOib = textBoxOib.Text;
            string country = comboBoxCountry.SelectedValue?.ToString() ?? "";
            string farmPostalCode = textBoxPostalCode.Text;

            if (!Validator.IsRequired(farmName) || !Validator.IsRequired(farmOib) || !Validator.IsRequired(country) || !Validator.IsRequired(farmPostalCode))
            {
                MessageBox.Show(Strings.AllFieldsAreRequired);
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
                var data = await ApiClient.PutAsync<Farm>("/farm", new FarmDetailsDto
                {
                    Name = farmName,
                    Oib = farmOib,
                    CountryIsoCode = country,
                    PostalCode = farmPostalCode,
                });

                if (data != null)
                {
                    NeocropsState.LoggedInUser.UserFarm = data;

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
    }
}
