using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace NtpNeocropsClient.Dto
{
    internal class AuthenticationResponseDto
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; } = string.Empty;

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; } = string.Empty;

        [JsonPropertyName("user")]
        public NtpNeocropsClient.Entity.User User { get; set; } = new NtpNeocropsClient.Entity.User();
    }
}
