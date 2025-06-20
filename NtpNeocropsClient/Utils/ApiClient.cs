using CredentialManagement;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Utils;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                BaseAddress = new Uri("http://127.0.0.1:8081")
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
                    var data = JsonSerializer.Deserialize<AuthenticationResponseDto>(responseBody);

                    NeocropsState.SaveCredentials(data.User.Email, data.RefreshToken);
                    NeocropsState.LoggedInUser = data.User;
                    NeocropsState.AccessToken = data.AccessToken;
                    NeocropsState.RefreshToken = data.RefreshToken;

                    return true;
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    NeocropsState.DeleteCredentials();
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

        private static async Task HandleErrorResponse(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            string serverMessage = string.Empty;

            try
            {
                var errorResponse = JsonSerializer.Deserialize<MessageResponseDto>(responseBody);
                Debug.WriteLine($"{errorResponse.Message} - {errorResponse.Detail}");
                serverMessage = errorResponse?.Message ?? errorResponse?.Detail ?? "Server error!";
            }
            catch
            {
                serverMessage = responseBody;
            }

            throw new ApiException(response.StatusCode, $"{response.ReasonPhrase}", serverMessage);
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

            await HandleErrorResponse(response);
            return default;
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

            await HandleErrorResponse(response);
            return default;
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

            await HandleErrorResponse(response);
            return default;
        }
    }
}