using ClassLibrary;
using Microsoft.VisualBasic.ApplicationServices;
using NtpNeocropsClient.Modules.ConsumptionModule.Dto;
using NtpNeocropsClient.Modules.ConsumptionModule.Entity;
using NtpNeocropsClient.Modules.CountryModule.Service;
using NtpNeocropsClient.Modules.PurchasesModule.Dto;
using NtpNeocropsClient.Modules.PurchasesModule.Entity;
using NtpNeocropsClient.Modules.SupplyModule.Entity;
using NtpNeocropsClient.Modules.SupplyModule.Service;
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

namespace NtpNeocropsClient.Modules.ConsumptionModule.Form
{
    public partial class ConsumptionDetailsForm : AbstractForm
    {
        private Consumption? selectedConsumption;

        public ConsumptionDetailsForm(Consumption? consumption = null)
        {
            InitializeComponent();


            if (consumption != null)
            {
                selectedConsumption = consumption;
                comboBoxSupply.SelectedValue = consumption.Supply.Id;
                textBoxAmount.Text = consumption.Amount.ToString();
                dateTimePickerDate.Text = consumption.Date.ToString();
                textBoxComment.Text = consumption.Comment;
            }
            else
            {
                buttonDelete.Hide();
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            bool supplyParsed = int.TryParse(comboBoxSupply.SelectedValue?.ToString(), out int supply);
            if (!supplyParsed)
            {
                MessageBox.Show(Strings.SelectedSupplyIsNotCorrect);
                return;
            }

            string date = dateTimePickerDate.Value.ToString("yyyy-MM-dd");
            string comment = textBoxComment.Text;

            bool amountParsed = int.TryParse(textBoxAmount.Text, out int amount);
            if (!amountParsed)
            {
                MessageBox.Show(Strings.AmountAndPriceMustBeNumbers);
                return;
            }

            if (!Validator.IsRequired(supply) || !Validator.IsRequired(amount) || !Validator.IsRequired(date))
            {
                MessageBox.Show(Strings.AllFieldsAreRequired);
                return;
            }

            var farmId = NeocropsState.LoggedInUser?.UserFarm.Id;

            if (farmId != null)
            {
                try
                {
                    if (selectedConsumption == null)
                    {
                        var data = await ApiClient.PostAsync<Purchase>($"/farm/{farmId}/consumptions", new ConsumptionDetailsDto
                        {
                            Supply = supply,
                            Amount = amount,
                            Date = date,
                            Comment = comment,
                        });

                        if (data != null)
                        {
                            MessageBox.Show(Strings.SuccessfullySaved);
                        }
                    }
                    else
                    {
                        var data = await ApiClient.PutAsync<Purchase>($"/farm/{farmId}/purchases/{selectedConsumption.Id}", new ConsumptionDetailsDto
                        {
                            Supply = supply,
                            Amount = amount,
                            Date = date,
                            Comment = comment,
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

        private async void PurchaseDetailsForm_Load(object sender, EventArgs e)
        {
            int? farmId = NeocropsState.LoggedInUser?.UserFarm.Id;
            if (farmId != null)
            {
                try
                {
                    var supplies = await SupplyService.GetAvailableSuppliesAsync(farmId ?? 0);

                    comboBoxSupply.DisplayMember = "DisplayText";
                    comboBoxSupply.ValueMember = "Id";
                    comboBoxSupply.DataSource = supplies;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            var farmId = NeocropsState.LoggedInUser?.UserFarm.Id;

            if (selectedConsumption != null && farmId != null)
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
                    await ApiClient.DeleteAsync<object>($"/farm/{farmId}/consumptions/{selectedConsumption.Id}");

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
