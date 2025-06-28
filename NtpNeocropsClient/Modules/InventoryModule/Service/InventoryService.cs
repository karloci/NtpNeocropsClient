using ClassLibrary;
using NtpNeocropsClient.Modules.InventoryModule.Entity;
using NtpNeocropsClient.Modules.SupplyModule.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Modules.InventoryModule.Service
{
    public class InventoryService
    {
        public static async Task<List<Supply>> GetSuppliesAsync(int farmId)
        {
            try
            {
                var data = await ApiClient.GetAsync<List<Supply>>($"/farm/{farmId}/inventory/supplies");
                return data ?? new List<Supply>();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Supply>();
            }
        }

        public static async Task<List<Stock>> GetStocksAsync(int farmId)
        {
            try
            {
                var data = await ApiClient.GetAsync<List<Stock>>($"/farm/{farmId}/inventory/stocks");
                return data ?? new List<Stock>();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Stock>();
            }
        }
    }
}
