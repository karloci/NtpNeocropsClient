using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using NtpNeocropsClient.Modules.ForecastModule.Entity;
using NtpNeocropsClient.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NtpNeocropsClient.Modules.ForecastModule.Service
{
    public class ForecastService
    {
        public static async Task<List<Forecast>> GetForecastAsync(string language, string postalCode, string countryIsoCode)
        {
            var result = new List<Forecast>();

            if (language == null || postalCode == null || countryIsoCode == null)
            {
                return result;
            }

            string cacheDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");
            Directory.CreateDirectory(cacheDir);
            string forecastFile = Path.Combine(cacheDir, $"forecast_{postalCode}_{countryIsoCode}_{language}.xml");
            if (File.Exists(forecastFile) && (DateTime.Now - File.GetLastWriteTime(forecastFile)).TotalMinutes <= 5)
            {
                return LoadWeatherDataFromXml(forecastFile);
            }

            var json = await FetchWeatherApiAsync(language, postalCode, countryIsoCode);
            if (json == null)
            {
                return result;
            }

            var root = new XElement("WeatherData");
            foreach (var item in JObject.Parse(json)!["list"]!)
            {
                var entry = new XElement("Entry",
                    new XElement("dt", (long)item["dt"]),
                    new XElement("temp", (double)item["main"]["temp"]),
                    new XElement("weather", (string)item["weather"][0]["description"]),
                    new XElement("humidity", (int)item["main"]["humidity"]),
                    new XElement("wind_speed", (double)item["wind"]["speed"])
                );

                root.Add(entry);
            }

            var xDocument = new XDocument(root);
            xDocument.Save(forecastFile);
            result = LoadWeatherDataFromXml(forecastFile);

            return result;
        }

        private static List<Forecast> LoadWeatherDataFromXml(string path)
        {
            var data = new List<Forecast>();
            var xDocument = XDocument.Load(path);

            foreach (var entry in xDocument.Descendants("Entry"))
            {
                var unixTime = long.Parse(entry.Element("dt")?.Value!);
                var dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;

                data.Add(new Forecast
                {
                    Time = dateTime,
                    Temp = double.Parse(entry.Element("temp")?.Value!, CultureInfo.InvariantCulture),
                    Weather = entry.Element("weather")?.Value!,
                    Humidity = int.Parse(entry.Element("humidity")?.Value!),
                    WindSpeed = double.Parse(entry.Element("wind_speed")?.Value!, CultureInfo.InvariantCulture)
                });
            }

            return data;
        }

        private static async Task<string?> FetchWeatherApiAsync(string language, string postalCode, string countryIsoCode)
        {
            if (language != null && postalCode != null && countryIsoCode != null)
            {
                try
                {
                    var url = $"https://api.openweathermap.org/data/2.5/forecast?zip={postalCode},{countryIsoCode}&units=metric&cnt=11&lang={language}&appid=3dbce27eb39a328186906ad65265e65f";

                    using (var client = new HttpClient())
                    {
                        var response = await client.GetStringAsync(url);
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }

            return default;
        }
    }
}
