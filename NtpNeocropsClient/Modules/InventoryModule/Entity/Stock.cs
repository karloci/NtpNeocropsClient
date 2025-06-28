using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Modules.InventoryModule.Entity
{
    [Serializable]
    public class Stock
    {
        public int SupplyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MeasureUnit { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public float TotalPrice { get; set; }
        public float PurchasedAmount { get; set; }
        public float ConsumedAmount { get; set; }
        public float StockAmount { get; set; }

        public string TotalPriceInEuros => $"{TotalPrice:F2} €";
        public string PurchasedAmountWithUnit => $"{PurchasedAmount} {MeasureUnit}";
        public string ConsumedAmountWithUnit => $"{ConsumedAmount} {MeasureUnit}";
        public string StockAmountWithUnit => $"{StockAmount} {MeasureUnit}";
    }
}
