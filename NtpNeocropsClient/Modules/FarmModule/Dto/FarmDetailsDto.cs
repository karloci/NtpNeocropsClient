using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Modules.FarmModule.Dto
{
    internal class FarmDetailsDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("oib")]
        public string Oib { get; set; } = string.Empty;

        [JsonPropertyName("CountryIsoCode")]
        public string CountryIsoCode { get; set; } = string.Empty;

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; } = string.Empty;
    }
}
