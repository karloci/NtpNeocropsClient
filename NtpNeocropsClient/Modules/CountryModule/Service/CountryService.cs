using NtpNeocropsClient.Modules.CountryModule.Entity;
using ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Modules.CountryModule.Service
{
    internal class CountryService
    {
        public static async Task<List<Country>> GetCountriesAsync()
        {
            var countries = new List<Country>();

            string cacheDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");
            Directory.CreateDirectory(cacheDir);

            string countriesFile = Path.Combine(cacheDir, "countries.bin");
            if (File.Exists(countriesFile) && (DateTime.Now - File.GetLastWriteTime(countriesFile)).TotalMinutes <= 5)
            {
                countries = LoadCountriesFromFile(countriesFile);
            }
            else
            {
                var client = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
                var result = await client.ListOfCountryNamesByNameAsync();

                countries = result.Body.ListOfCountryNamesByNameResult
                    .Select(c => new Country { Name = c.sName, Code = c.sISOCode })
                    .ToList();

                using (var fs = new FileStream(countriesFile, FileMode.Create, FileAccess.Write))
                using (var writer = new BinaryWriter(fs))
                {
                    writer.Write(countries.Count);
                    foreach (var country in countries)
                    {
                        writer.Write(country.Name);
                        writer.Write(country.Code);
                    }
                }
            }

            return countries;
        }

        private static List<Country> LoadCountriesFromFile(string countriesFile)
        {
            var countries = new List<Country>();

            using (var fs = new FileStream(countriesFile, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs))
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string name = reader.ReadString();
                    string code = reader.ReadString();
                    countries.Add(new Country { Name = name, Code = code });
                }
            }

            return countries;
        }
    }
}
