using ClassLibrary;
using CredentialManagement;
using Newtonsoft.Json.Linq;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Entity;
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
                List<ForecastModel> data = await GetForecastAsync();

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

                var tempChart = CreateSingleChart(data, "Temperatura (°C)", "Temp");
                layout.Controls.Add(tempChart, 0, 0);

                var pressureChart = CreateSingleChart(data, "Tlak (hPa)", "Pressure");
                layout.Controls.Add(pressureChart, 1, 0);

                var humidityChart = CreateSingleChart(data, "Vlažnost (%)", "Humidity");
                layout.Controls.Add(humidityChart, 0, 1);

                var windChart = CreateSingleChart(data, "Brzina vjetra (m/s)", "WindSpeed");
                layout.Controls.Add(windChart, 1, 1);

                this.Controls.Add(layout);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Chart CreateSingleChart(List<ForecastModel> data, string title, string valueType)
        {
            var chart = new Chart { Dock = DockStyle.Fill };

            var chartArea = new ChartArea("MainArea")
            {
                AxisX = {
                    Title = "Time (HH:mm)",
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
                    case "Pressure":
                        yValue = entry.Pressure;
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

        private async Task<List<ForecastModel>> GetForecastAsync()
        {
            var result = new List<ForecastModel>();

            string cacheDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");
            Directory.CreateDirectory(cacheDir);

            string postalCode = NeocropsState.LoggedInUser.UserFarm.PostalCode;
            string countryIsoCode = NeocropsState.LoggedInUser.UserFarm.CountryIsoCode;
            string forecastFile = Path.Combine(cacheDir, $"forecast_{postalCode}_{countryIsoCode}.xml");
            if (!(File.Exists(forecastFile) && (DateTime.Now - File.GetLastWriteTime(forecastFile)).TotalMinutes <= 60))
            {
                var json = await FetchWeatherApiAsync();

                var root = new XElement("WeatherData");
                foreach (var item in JObject.Parse(json)["list"])
                {
                    var entry = new XElement("Entry",
                        new XElement("dt", (long)item["dt"]),
                        new XElement("temp", (double)item["main"]["temp"]),
                        new XElement("pressure", (int)item["main"]["pressure"]),
                        new XElement("humidity", (int)item["main"]["humidity"]),
                        new XElement("wind_speed", (double)item["wind"]["speed"])
                    );

                    root.Add(entry);
                }

                var xDocument = new XDocument(root);
                xDocument.Save(forecastFile);
            }

            result = LoadWeatherDataFromXml(forecastFile);
            return result;
        }

        public List<ForecastModel> LoadWeatherDataFromXml(string path)
        {
            var data = new List<ForecastModel>();
            var xDocument = XDocument.Load(path);

            foreach (var entry in xDocument.Descendants("Entry"))
            {
                var unixTime = long.Parse(entry.Element("dt").Value);
                var dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;

                data.Add(new ForecastModel
                {
                    Time = dateTime,
                    Temp = double.Parse(entry.Element("temp").Value, CultureInfo.InvariantCulture),
                    Pressure = int.Parse(entry.Element("pressure").Value),
                    Humidity = int.Parse(entry.Element("humidity").Value),
                    WindSpeed = double.Parse(entry.Element("wind_speed").Value, CultureInfo.InvariantCulture)
                });
            }

            return data;
        }

        public async Task<string> FetchWeatherApiAsync()
        {
            try
            {
                string postalCode = NeocropsState.LoggedInUser.UserFarm.PostalCode;
                string countryIsoCode = NeocropsState.LoggedInUser.UserFarm.CountryIsoCode;
                var url = $"https://api.openweathermap.org/data/2.5/forecast?zip={postalCode},{countryIsoCode}&units=metric&cnt=12&appid=3dbce27eb39a328186906ad65265e65f";

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
                throw;
            }
        }

        public class ForecastModel
        {
            public DateTime Time { get; set; }
            public double Temp { get; set; }
            public int Pressure { get; set; }
            public int Humidity { get; set; }
            public double WindSpeed { get; set; }
        }
    }
}
