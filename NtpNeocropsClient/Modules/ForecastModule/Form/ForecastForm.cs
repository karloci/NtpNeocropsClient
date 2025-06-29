using ClassLibrary;
using CredentialManagement;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using NtpNeocropsClient.Modules.ForecastModule.Entity;
using NtpNeocropsClient.Modules.ForecastModule.Service;
using NtpNeocropsClient.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
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
                string preferedLanguage = "en";
                using (var key = Registry.CurrentUser.OpenSubKey(@"Software\NeocropsApp\Language"))
                {
                    preferedLanguage = key?.GetValue("Language") as string ?? "en";
                }
                string? postalCode = NeocropsState.LoggedInUser?.UserFarm.PostalCode;
                string? countryIsoCode = NeocropsState.LoggedInUser?.UserFarm.CountryIsoCode;

                List<Forecast> data = await ForecastService.GetForecastAsync(preferedLanguage, postalCode, countryIsoCode);

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

                var stringBuilder = new StringBuilder();
                foreach (Forecast forecast in data)
                {
                    stringBuilder.AppendLine($"{forecast.Time:HH:mm} - {forecast.Weather}");
                }
                weatherInformation.Text = stringBuilder.ToString();

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
    }
}
