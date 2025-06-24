using Microsoft.VisualBasic.ApplicationServices;
using NtpNeocropsClient.Modules.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace NtpNeocropsClient.Modules.Authentication.Dto
{
    internal class AuthenticationResponseDto
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; } = string.Empty;

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; } = string.Empty;

        [JsonPropertyName("user")]
        public AppUser LoggedInUser { get; set; } = new AppUser();
    }
}
