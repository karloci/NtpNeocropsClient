using ClassLibrary;
using CredentialManagement;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using NtpNeocropsClient.Modules.ForecastModule.Entity;
using NtpNeocropsClient.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NtpNeocropsClient
{
    public partial class ForecastForm : AuthAbstractForm
    {
        public ForecastForm() : base()
        {
            InitializeComponent();
        }

        private void ForecastForm_Load(object sender, EventArgs e)
        {
            InitCharts();
        }

        private async void InitCharts()
        {
            try
            {
                List<Forecast> data = await GetForecastAsync();

                var layout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 2
                };

                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
                layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
                layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

                var tempChart = CreateSingleChart(data, $"{Strings.Temperature} (°C)", "Temp");
                layout.Controls.Add(tempChart, 0, 0);

                var humidityChart = CreateSingleChart(data, $"{Strings.Humidity} (%)", "Humidity");
                layout.Controls.Add(humidityChart, 0, 1);

                var windChart = CreateSingleChart(data, $"{Strings.WindSpeed} (m/s)", "WindSpeed");
                layout.Controls.Add(windChart, 1, 1);

                var weatherInformation = new Label
                {
                    Dock = DockStyle.Fill,
                    AutoSize = false,
                    TextAlign = ContentAlignment.TopLeft,
                    Font = new Font("Segoe UI", 10),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };

                var lines = data.Select(f => $"{f.Time:HH:mm} - {f.Weather}");
                weatherInformation.Text = string.Join(Environment.NewLine, lines);
                layout.Controls.Add(weatherInformation, 1, 0);

                this.Controls.Add(layout);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Chart CreateSingleChart(List<Forecast> data, string title, string valueType)
        {
            var chart = new Chart { Dock = DockStyle.Fill };

            var chartArea = new ChartArea("ForecastChartArea")
            {
                AxisX = {
                    Title = Strings.Time,
                    LabelStyle = {
                        Format = "HH:mm",
                    },
                    MajorGrid = { LineColor = Color.LightGray },
                    IntervalAutoMode = IntervalAutoMode.VariableCount,
                    IntervalType = DateTimeIntervalType.Hours
                },
                AxisY = {
                    Title = title,
                    MajorGrid = { LineColor = Color.LightGray }
                }
            };

            chart.ChartAreas.Add(chartArea);

            var series = new Series(title)
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                XValueType = ChartValueType.DateTime,
                ToolTip = "#VALX{dd.MM.yyyy HH:mm} - #VALY"
            };

            var sortedData = data.OrderBy(d => d.Time).ToList();
            foreach (var entry in sortedData)
            {
                double yValue = 0;
                switch (valueType)
                {
                    case "Temp":
                        yValue = entry.Temp;
                        break;
                    case "Humidity":
                        yValue = entry.Humidity;
                        break;
                    case "WindSpeed":
                        yValue = entry.WindSpeed;
                        break;
                }
                series.Points.AddXY(entry.Time, yValue);
            }

            chart.Series.Add(series);

            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart.ChartAreas[0].RecalculateAxesScale();

            return chart;
        }

        private async Task<List<Forecast>> GetForecastAsync()
        {
            var result = new List<Forecast>();

            string preferedLanguage = "en";
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\NeocropsApp\Language"))
            {
                preferedLanguage = key?.GetValue("Language") as string ?? "en";
            }
            string? postalCode = NeocropsState.LoggedInUser?.UserFarm.PostalCode;
            string? countryIsoCode = NeocropsState.LoggedInUser?.UserFarm.CountryIsoCode;
            if (postalCode == null || countryIsoCode == null)
            {
                return result;
            }

            string cacheDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");
            Directory.CreateDirectory(cacheDir);
            string forecastFile = Path.Combine(cacheDir, $"forecast_{postalCode}_{countryIsoCode}_{preferedLanguage}.xml");
            if (File.Exists(forecastFile) && (DateTime.Now - File.GetLastWriteTime(forecastFile)).TotalMinutes <= 60)
            {
                result = LoadWeatherDataFromXml(forecastFile);
                return result;
            }

            var json = await FetchWeatherApiAsync();
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

        public List<Forecast> LoadWeatherDataFromXml(string path)
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

        public async Task<string?> FetchWeatherApiAsync()
        {
            string preferedLanguage = "en";
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\NeocropsApp\Language"))
            {
                preferedLanguage = key?.GetValue("Language") as string ?? "en";
            }
            string? postalCode = NeocropsState.LoggedInUser?.UserFarm.PostalCode;
            string? countryIsoCode = NeocropsState.LoggedInUser?.UserFarm.CountryIsoCode;

            if (postalCode != null && countryIsoCode != null)
            {
                try
                {
                    var url = $"https://api.openweathermap.org/data/2.5/forecast?zip={postalCode},{countryIsoCode}&units=metric&cnt=11&lang={preferedLanguage}&appid=3dbce27eb39a328186906ad65265e65f";

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
