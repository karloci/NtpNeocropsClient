using NtpNeocropsClient.Modules.ConsumptionModule.Entity;
using NtpNeocropsClient.Modules.FarmModule.Entity;
using NtpNeocropsClient.Modules.InventoryModule.Entity;
using NtpNeocropsClient.Modules.InventoryModule.Service;
using NtpNeocropsClient.Modules.PurchasesModule.Entity;
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

namespace NtpNeocropsClient.Modules.InventoryModule.Form
{
    public partial class StocksForm : AuthAbstractForm
    {
        private List<Stock> allStocks = new List<Stock>();
        private string selectedFilter = "";
        private string selectedSortKey = "Supply";

        public StocksForm()
        {
            InitializeComponent();

            var sortOptions = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Supply", Strings.Supply),
                new KeyValuePair<string, string>("Manufacturer", Strings.Manufacturer),
                new KeyValuePair<string, string>("TotalPrice", Strings.TotalPrice),
                new KeyValuePair<string, string>("Purchased", Strings.Purchased),
                new KeyValuePair<string, string>("Consumed", Strings.Consumed),
                new KeyValuePair<string, string>("Stock", Strings.Stock),
            };

            comboBoxSort.DataSource = sortOptions;
            comboBoxSort.DisplayMember = "Value";
            comboBoxSort.ValueMember = "Key";
        }

        private async void StocksForm_Load(object sender, EventArgs e)
        {
            dataGridViewStocks.AutoGenerateColumns = false;
            dataGridViewStocks.Columns.Clear();

            dataGridViewStocks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Supply,
                DataPropertyName = "Name"
            });

            dataGridViewStocks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Manufacturer,
                DataPropertyName = "Manufacturer"
            });

            dataGridViewStocks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.TotalPrice,
                DataPropertyName = "TotalPriceInEuros"
            });

            dataGridViewStocks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Purchased,
                DataPropertyName = "PurchasedAmountWithUnit"
            });

            dataGridViewStocks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Consumed,
                DataPropertyName = "ConsumedAmountWithUnit"
            });

            dataGridViewStocks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Strings.Stock,
                DataPropertyName = "StockAmountWithUnit"
            });

            dataGridViewStocks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStocks.ReadOnly = true;
            dataGridViewStocks.AllowUserToAddRows = false;

            int? farmId = NeocropsState.LoggedInUser?.UserFarm.Id;
            if (farmId != null)
            {
                allStocks = await InventoryService.GetStocksAsync(farmId ?? 0);
                BindStocks(allStocks);
            }
        }

        private void BindStocks(List<Stock> stocks)
        {
            dataGridViewStocks.DataSource = stocks;
            dataGridViewStocks.ClearSelection();
            dataGridViewStocks.CurrentCell = null;
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
            IEnumerable<Stock> result = allStocks;

            if (!string.IsNullOrWhiteSpace(selectedFilter))
            {
                string keyword = selectedFilter.Trim().ToLower();
                result = result.Where(p =>
                    (p.Name ?? "").ToLower().Contains(keyword) ||
                    (p.Manufacturer ?? "").ToLower().Contains(keyword) ||
                    (p.TotalPriceInEuros ?? "").ToLower().Contains(keyword) ||
                    (p.PurchasedAmountWithUnit ?? "").ToLower().Contains(keyword) ||
                    (p.ConsumedAmountWithUnit ?? "").ToLower().Contains(keyword) ||
                    (p.StockAmountWithUnit ?? "").ToLower().Contains(keyword)
                );
            }

            switch (selectedSortKey)
            {
                case "Supply":
                    result = result.OrderBy(p => p.Name);
                    break;
                case "Manufacturer":
                    result = result.OrderBy(p => p.Manufacturer);
                    break;
                case "TotalPrice":
                    result = result.OrderBy(p => p.TotalPrice);
                    break;
                case "Purchased":
                    result = result.OrderBy(p => p.PurchasedAmount);
                    break;
                case "Consumed":
                    result = result.OrderBy(p => p.ConsumedAmount);
                    break;
                case "Stock":
                    result = result.OrderBy(p => p.StockAmount);
                    break;
                default:
                    break;
            }

            BindStocks(result.ToList());
        }
    }
}
