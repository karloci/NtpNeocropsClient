using NtpNeocropsClient.Modules.ConsumptionModule.Entity;
using NtpNeocropsClient.Modules.InventoryModule.Service;
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
        public StocksForm()
        {
            InitializeComponent();
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
                dataGridViewStocks.DataSource = await InventoryService.GetStocksAsync(farmId ?? 0);
                dataGridViewStocks.ClearSelection();
                dataGridViewStocks.CurrentCell = null;
            }
        }
    }
}
