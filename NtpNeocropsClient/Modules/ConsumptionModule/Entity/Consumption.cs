using NtpNeocropsClient.Modules.FarmModule.Entity;
using NtpNeocropsClient.Modules.SupplyModule.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Modules.ConsumptionModule.Entity
{
    [Serializable]
    public class Consumption
    {
        public int Id { get; set; }
        public Supply Supply { get; set; } = new Supply();
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }

        public string? SupplyName => Supply?.Name;
        public string? ManufacturerName => Supply?.Manufacturer;
        public string AmountWithUnit => $"{Amount} {Supply?.MeasureUnit}";
    }
}
