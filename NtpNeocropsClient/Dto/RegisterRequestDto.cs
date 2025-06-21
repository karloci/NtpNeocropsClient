using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Dto
{
    internal class RegisterRequestDto
    {
        [JsonPropertyName("fullName")]
        public string FullName { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("repeatPassword")]
        public string RepeatPassword { get; set; } = string.Empty;

        [JsonPropertyName("farmName")]
        public string FarmName { get; set; } = string.Empty;

        [JsonPropertyName("farmOib")]
        public string FarmOib { get; set; } = string.Empty;

        [JsonPropertyName("farmCountryIsoCode")]
        public string FarmCountryIsoCode { get; set; } = string.Empty;
    }
}
