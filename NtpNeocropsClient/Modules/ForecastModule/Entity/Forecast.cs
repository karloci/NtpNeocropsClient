using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Modules.ForecastModule.Entity
{
    public class Forecast
    {
        public DateTime Time { get; set; }
        public double Temp { get; set; }
        public string Weather { get; set; } = string.Empty;
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
    }
}
