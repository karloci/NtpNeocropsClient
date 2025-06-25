using ClassLibrary;
using NtpNeocropsClient.Modules.CountryModule.Entity;
using NtpNeocropsClient.Modules.FarmModule.Entity;
using NtpNeocropsClient.Modules.PurchasesModule.Entity;
using NtpNeocropsClient.Modules.SupplyModule.Entity;
using ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Modules.SupplyModule.Service
{
    public class SupplyService
    {
        public static async Task<List<Supply>> GetSuppliesAsync()
        {
            var supplies = new List<Supply>();

            string cacheDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");
            Directory.CreateDirectory(cacheDir);

            string suppliesFile = Path.Combine(cacheDir, "supplies.json");
            if (File.Exists(suppliesFile) && (DateTime.Now - File.GetLastWriteTime(suppliesFile)).TotalMinutes <= 5)
            {
                supplies = LoadSuppliesFromFile(suppliesFile);
            }
            else
            {
                try
                {
                    var data = await ApiClient.GetAsync<List<Supply>>("/supplies");

                    if (data != null)
                    {
                        supplies = data;

                        var json = JsonSerializer.Serialize(supplies, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(suppliesFile, json);
                    }
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message);
                    return supplies;
                }
            }

            return supplies;
        }


        private static List<Supply> LoadSuppliesFromFile(string suppliesFile)
        {
            try
            {
                string json = File.ReadAllText(suppliesFile);
                var supplies = JsonSerializer.Deserialize<List<Supply>>(json);
                return supplies ?? new List<Supply>();
            }
            catch
            {
                return new List<Supply>();
            }
        }
    }
}
