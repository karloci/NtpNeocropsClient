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

namespace NtpNeocropsClient.Modules.PurchasesModule.Form
{
    public partial class PurchasesForm : AuthAbstractForm
    {
        public PurchasesForm()
        {
            InitializeComponent();
        }

        private async void FetchPurchases()
        {
            dataGridViewPurchases.CellDoubleClick -= DataGridViewPurchases_CellDoubleClick!;

            dataGridViewPurchases.ClearSelection();
            dataGridViewPurchases.CurrentCell = null;

            var farmId = NeocropsState.LoggedInUser?.UserFarm.Id;
            if (farmId != null)
            {
                try
                {
                    var data = await ApiClient.GetAsync<List<Purchase>>($"/farm/{farmId}/purchases");

                    if (data != null)
                    {
                        dataGridViewPurchases.DataSource = data;

                        dataGridViewPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridViewPurchases.CellDoubleClick += DataGridViewPurchases_CellDoubleClick!;
                        dataGridViewPurchases.ReadOnly = true;

                        dataGridViewPurchases.Columns["Id"].Visible = false;
                    }
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PurchasesForm_Load(object sender, EventArgs e)
        {
            FetchPurchases();
        }

        private void DataGridViewPurchases_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var purchase = (Purchase)dataGridViewPurchases.Rows[e.RowIndex].DataBoundItem;

                var purchaseDetailsForm = new PurchaseDetailsForm(purchase);
                var result = purchaseDetailsForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    FetchPurchases();
                }
            }
        }

        private void buttonAddPurchase_Click(object sender, EventArgs e)
        {
            var purchaseDetailsForm = new PurchaseDetailsForm();
            var result = purchaseDetailsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                FetchPurchases();
            }
        }
    }
}
