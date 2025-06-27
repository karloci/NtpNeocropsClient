using ClassLibrary;
using NtpNeocropsClient.Modules.ConsumptionModule.Entity;
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

namespace NtpNeocropsClient.Modules.ConsumptionModule.Form
{
    public partial class ConsumptionsForm : AuthAbstractForm
    {
        private List<Consumption> allConsumptions = new List<Consumption>();
        private string selectedFilter = "";
        private string selectedSortKey = "Supply";

        public ConsumptionsForm()
        {
            InitializeComponent();

            var sortOptions = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Supply", Strings.Supply),
                new KeyValuePair<string, string>("Manufacturer", Strings.Manufacturer),
                new KeyValuePair<string, string>("Amount", Strings.Amount),
                new KeyValuePair<string, string>("Date", Strings.Date),
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
                HeaderText = Strings.Date,
                DataPropertyName = "Date"
            });

            dataGridViewPurchases.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Comment,
                DataPropertyName = "Comment"
            });

            dataGridViewPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPurchases.ReadOnly = true;
            dataGridViewPurchases.AllowUserToAddRows = false;

            allConsumptions = await FetchConsumptionsAsync();
            BindConsumptions(allConsumptions);
        }

        private async Task<List<Consumption>> FetchConsumptionsAsync()
        {
            var farmId = NeocropsState.LoggedInUser?.UserFarm.Id;
            if (farmId == null)
            {
                return new List<Consumption>();
            }

            try
            {
                var data = await ApiClient.GetAsync<List<Consumption>>($"/farm/{farmId}/consumptions");
                return data ?? new List<Consumption>();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Consumption>();
            }
        }

        private void BindConsumptions(List<Consumption> consumptions)
        {
            dataGridViewPurchases.CellDoubleClick -= DataGridViewPurchases_CellDoubleClick!;

            dataGridViewPurchases.DataSource = consumptions;
            dataGridViewPurchases.ClearSelection();
            dataGridViewPurchases.CurrentCell = null;

            dataGridViewPurchases.CellDoubleClick += DataGridViewPurchases_CellDoubleClick!;
        }

        private async void DataGridViewPurchases_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var consumption = (Consumption)dataGridViewPurchases.Rows[e.RowIndex].DataBoundItem;

                var consumptionDetailsForm = new ConsumptionDetailsForm(consumption);
                var result = consumptionDetailsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    allConsumptions = await FetchConsumptionsAsync();
                    BindConsumptions(allConsumptions);
                }
            }
        }

        private async void buttonAddPurchase_Click(object sender, EventArgs e)
        {
            var purchaseDetailsForm = new ConsumptionDetailsForm();
            var result = purchaseDetailsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                allConsumptions = await FetchConsumptionsAsync();
                BindConsumptions(allConsumptions);
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
            IEnumerable<Consumption> result = allConsumptions;

            if (!string.IsNullOrWhiteSpace(selectedFilter))
            {
                string keyword = selectedFilter.Trim().ToLower();
                result = result.Where(p =>
                    (p.Supply?.Name ?? "").ToLower().Contains(keyword) ||
                    (p.Supply?.Manufacturer ?? "").ToLower().Contains(keyword) ||
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
                case "Date":
                    result = result.OrderBy(p => p.Date);
                    break;
                case "Comment":
                    result = result.OrderBy(p => p.Comment);
                    break;
                default:
                    break;
            }

            BindConsumptions(result.ToList());
        }
    }
}
