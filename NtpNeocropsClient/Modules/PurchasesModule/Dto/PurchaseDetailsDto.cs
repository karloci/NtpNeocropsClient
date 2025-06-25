using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Modules.PurchasesModule.Dto
{
    internal class PurchaseDetailsDto
    {
        [JsonPropertyName("supply")]
        public int Supply { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;
        [JsonPropertyName("invoiceNo")]
        public string InvoiceNo { get; set; } = string.Empty;
        [JsonPropertyName("comment")]
        public string Comment { get; set; } = string.Empty;
    }
}
