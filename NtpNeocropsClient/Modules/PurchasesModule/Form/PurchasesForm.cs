using ClassLibrary;
using NtpNeocropsClient.Modules.PurchasesModule.Entity;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NtpNeocropsClient.Modules.PurchasesModule.Form
{
    public partial class PurchasesForm : AuthAbstractForm
    {
        private List<Purchase> allPurchases = new List<Purchase>();
        private string selectedFilter = "";
        private string selectedSortKey = "Supply";

        public PurchasesForm()
        {
            InitializeComponent();

            var sortOptions = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Supply", Strings.Supply),
                new KeyValuePair<string, string>("Manufacturer", Strings.Manufacturer),
                new KeyValuePair<string, string>("Amount", Strings.Amount),
                new KeyValuePair<string, string>("Price", Strings.Price),
                new KeyValuePair<string, string>("Date", Strings.Date),
                new KeyValuePair<string, string>("InvoiceNo", Strings.InvoiceNo),
                new KeyValuePair<string, string>("Comment", Strings.Comment)
            };

            comboBoxSort.DataSource = sortOptions;
            comboBoxSort.DisplayMember = "Value";
            comboBoxSort.ValueMember = "Key";
        }

        private async void PurchasesForm_Load(object sender, EventArgs e)
        {
            dataGridViewPurchases.AutoGenerateColumns = false;
            dataGridViewPurchases.Columns.Clear();

            dataGridViewPurchases.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Supply,
                DataPropertyName = "SupplyName"
            });

            dataGridViewPurchases.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Manufacturer,
                DataPropertyName = "ManufacturerName"
            });

            dataGridViewPurchases.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Amount,
                DataPropertyName = "AmountWithUnit"
            });

            dataGridViewPurchases.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Price,
                DataPropertyName = "PriceInEuros"
            });

            dataGridViewPurchases.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Date,
                DataPropertyName = "Date"
            });

            dataGridViewPurchases.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.InvoiceNo,
                DataPropertyName = "InvoiceNo"
            });

            dataGridViewPurchases.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Comment,
                DataPropertyName = "Comment"
            });

            dataGridViewPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPurchases.ReadOnly = true;
            dataGridViewPurchases.AllowUserToAddRows = false;

            allPurchases = await FetchPurchasesAsync();
            BindPurchases(allPurchases);
        }

        private async Task<List<Purchase>> FetchPurchasesAsync()
        {
            var farmId = NeocropsState.LoggedInUser?.UserFarm.Id;
            if (farmId == null)
            {
                return new List<Purchase>();
            }

            try
            {
                var data = await ApiClient.GetAsync<List<Purchase>>($"/farm/{farmId}/purchases");
                return data ?? new List<Purchase>();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Purchase>();
            }
        }

        private void BindPurchases(List<Purchase> purchases)
        {
            dataGridViewPurchases.CellDoubleClick -= DataGridViewPurchases_CellDoubleClick!;

            dataGridViewPurchases.DataSource = purchases;
            dataGridViewPurchases.ClearSelection();
            dataGridViewPurchases.CurrentCell = null;

            dataGridViewPurchases.CellDoubleClick += DataGridViewPurchases_CellDoubleClick!;
        }

        private async void DataGridViewPurchases_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var purchase = (Purchase)dataGridViewPurchases.Rows[e.RowIndex].DataBoundItem;

                var purchaseDetailsForm = new PurchaseDetailsForm(purchase);
                var result = purchaseDetailsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    allPurchases = await FetchPurchasesAsync();
                    BindPurchases(allPurchases);
                }
            }
        }

        private async void buttonAddPurchase_Click(object sender, EventArgs e)
        {
            var purchaseDetailsForm = new PurchaseDetailsForm();
            var result = purchaseDetailsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                allPurchases = await FetchPurchasesAsync();
                BindPurchases(allPurchases);
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            selectedFilter = textBoxFilter.Text;
            ApplyFilterAndSort();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort.SelectedValue != null)
            {
                selectedSortKey = comboBoxSort.SelectedValue.ToString();
                ApplyFilterAndSort();
            }
        }

        private void ApplyFilterAndSort()
        {
            IEnumerable<Purchase> result = allPurchases;

            if (!string.IsNullOrWhiteSpace(selectedFilter))
            {
                string keyword = selectedFilter.Trim().ToLower();
                result = result.Where(p =>
                    (p.Supply?.Name ?? "").ToLower().Contains(keyword) ||
                    (p.Supply?.Manufacturer ?? "").ToLower().Contains(keyword) ||
                    (p.InvoiceNo ?? "").ToLower().Contains(keyword) ||
                    (p.Comment ?? "").ToLower().Contains(keyword)
                );
            }

            switch (selectedSortKey)
            {
                case "Supply":
                    result = result.OrderBy(p => p.Supply?.Name);
                    break;
                case "Manufacturer":
                    result = result.OrderBy(p => p.Supply?.Manufacturer);
                    break;
                case "Amount":
                    result = result.OrderBy(p => p.Amount);
                    break;
                case "Price":
                    result = result.OrderBy(p => p.Price);
                    break;
                case "Date":
                    result = result.OrderBy(p => p.Date);
                    break;
                case "InvoiceNo":
                    result = result.OrderBy(p => p.InvoiceNo);
                    break;
                case "Comment":
                    result = result.OrderBy(p => p.Comment);
                    break;
                default:
                    break;
            }

            BindPurchases(result.ToList());
        }
    }
}
