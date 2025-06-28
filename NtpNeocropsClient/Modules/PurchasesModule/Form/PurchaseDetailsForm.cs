using ClassLibrary;
using Microsoft.VisualBasic.ApplicationServices;
using NtpNeocropsClient.Modules.CountryModule.Service;
using NtpNeocropsClient.Modules.PurchasesModule.Dto;
using NtpNeocropsClient.Modules.PurchasesModule.Entity;
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

namespace NtpNeocropsClient.Modules.PurchasesModule.Form
{
    public partial class PurchaseDetailsForm : AbstractForm
    {
        private Purchase? selectedPurchase;

        public PurchaseDetailsForm(Purchase? purchase = null)
        {
            InitializeComponent();
            selectedPurchase = purchase;
            SetupComponent();
        }

        private async void SetupComponent()
        {
            try
            {
                var supplies = await SupplyService.GetSuppliesAsync();

                comboBoxSupply.DisplayMember = "DisplayText";
                comboBoxSupply.ValueMember = "Id";
                comboBoxSupply.DataSource = supplies;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (selectedPurchase != null)
            {
                comboBoxSupply.SelectedValue = selectedPurchase.Supply.Id;
                comboBoxSupply.Enabled = false;

                textBoxAmount.Text = selectedPurchase.Amount.ToString();
                textBoxPrice.Text = selectedPurchase.Price.ToString();
                dateTimePickerDate.Text = selectedPurchase.Date.ToString();
                textBoxInvoiceNo.Text = selectedPurchase.InvoiceNo;
                textBoxComment.Text = selectedPurchase.Comment;
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
            string invoiceNo = textBoxInvoiceNo.Text;
            string comment = textBoxComment.Text;

            bool amountParsed = int.TryParse(textBoxAmount.Text, out int amount);
            bool priceParsed = double.TryParse(textBoxPrice.Text, out double price);
            if (!amountParsed || !priceParsed)
            {
                MessageBox.Show(Strings.AmountAndPriceMustBeNumbers);
                return;
            }

            if (!Validator.IsRequired(supply) || !Validator.IsRequired(amount) || !Validator.IsRequired(price) || !Validator.IsRequired(date))
            {
                MessageBox.Show(Strings.AllFieldsAreRequired);
                return;
            }

            var farmId = NeocropsState.LoggedInUser?.UserFarm.Id;

            if (farmId != null)
            {
                try
                {
                    if (selectedPurchase == null)
                    {
                        var data = await ApiClient.PostAsync<Purchase>($"/farm/{farmId}/purchases", new PurchaseDetailsDto
                        {
                            Supply = supply,
                            Amount = amount,
                            Price = price,
                            Date = date,
                            InvoiceNo = invoiceNo,
                            Comment = comment,
                        });

                        if (data != null)
                        {
                            MessageBox.Show(Strings.SuccessfullySaved);
                        }
                    }
                    else
                    {
                        var data = await ApiClient.PutAsync<Purchase>($"/farm/{farmId}/purchases/{selectedPurchase.Id}", new PurchaseDetailsDto
                        {
                            Supply = selectedPurchase.Supply.Id,
                            Amount = amount,
                            Price = price,
                            Date = date,
                            InvoiceNo = invoiceNo,
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

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            var farmId = NeocropsState.LoggedInUser?.UserFarm.Id;

            if (selectedPurchase != null && farmId != null)
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
                    await ApiClient.DeleteAsync<object>($"/farm/{farmId}/purchases/{selectedPurchase.Id}");

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
