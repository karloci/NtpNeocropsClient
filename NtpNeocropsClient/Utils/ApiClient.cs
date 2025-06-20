using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Utils;

namespace ClassLibrary
{
    internal static class ApiClient
    {
        private static readonly HttpClient httpClient;
        private static bool isRefreshingToken = false;

        static ApiClient()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:8080")
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static void AddAuthorizationHeader()
        {
            if (!string.IsNullOrEmpty(NeocropsState.AccessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", NeocropsState.AccessToken);
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        private static async Task<bool> TryRefreshToken()
        {
            if (isRefreshingToken || string.IsNullOrEmpty(NeocropsState.RefreshToken))
            {
                return false;
            }

            isRefreshingToken = true;

            try
            {
                var refreshRequest = new RefreshTokenRequestDto
                {
                    RefreshToken = NeocropsState.RefreshToken
                };

                var response = await httpClient.PostAsync("/authentication/refresh-token", new StringContent(JsonSerializer.Serialize(refreshRequest), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var authenticationResponse = JsonSerializer.Deserialize<AuthenticationResponseDto>(responseBody);

                    NeocropsState.LoggedInUser = authenticationResponse.User;
                    NeocropsState.AccessToken = authenticationResponse.AccessToken;
                    NeocropsState.RefreshToken = authenticationResponse.RefreshToken;

                    return true;
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    NeocropsState.LoggedInUser = null;
                    NeocropsState.AccessToken = null;
                    NeocropsState.RefreshToken = null;
                }

                return false;
            }
            finally
            {
                isRefreshingToken = false;
            }
        }

        private static async Task<HttpResponseMessage> SendRequestToServer(Func<Task<HttpResponseMessage>> requestFunc)
        {
            var response = await requestFunc();

            if (response.StatusCode == HttpStatusCode.Unauthorized && !string.IsNullOrEmpty(NeocropsState.RefreshToken))
            {
                if (await TryRefreshToken())
                {
                    AddAuthorizationHeader();
                    response = await requestFunc();
                }
            }

            return response;
        }

        public static async Task<T?> PostAsync<T>(string endpoint, object payload)
        {
            AddAuthorizationHeader();

            var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await SendRequestToServer(() => httpClient.PostAsync(endpoint, content));

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            throw new ApiException(response.StatusCode, $"{response.ReasonPhrase}");
        }

        public static async Task<T?> PatchAsync<T>(string endpoint, object payload)
        {
            AddAuthorizationHeader();

            var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await SendRequestToServer(() => httpClient.PatchAsync(endpoint, content));

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            throw new ApiException(response.StatusCode, $"{response.ReasonPhrase}");
        }

        public static async Task<T?> GetAsync<T>(string endpoint)
        {
            AddAuthorizationHeader();

            var response = await SendRequestToServer(() => httpClient.GetAsync(endpoint));

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            throw new ApiException(response.StatusCode, $"{response.ReasonPhrase}");
        }
    }
}