using CredentialManagement;
using NtpNeocropsClient.Modules.Authentication.Dto;
using NtpNeocropsClient.Shared.Dto;
using NtpNeocropsClient.Shared.Entity;
using NtpNeocropsClient.Utils;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
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
                    var data = JsonSerializer.Deserialize<AuthenticationResponseDto>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (data != null)
                    {
                        NeocropsState.SaveCredentials(data.LoggedInUser.Email, data.RefreshToken);
                        NeocropsState.LoggedInUser = data.LoggedInUser;
                        NeocropsState.LoggedInUser.UserFarm = data.LoggedInUser.UserFarm;
                        NeocropsState.AccessToken = data.AccessToken;
                        NeocropsState.RefreshToken = data.RefreshToken;
                        return true;
                    }

                    return false;
                } 
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
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

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions
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

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            await HandleErrorResponse(response);
            return default;
        }

        public static async Task<T?> PutAsync<T>(string endpoint, object payload)
        {
            AddAuthorizationHeader();

            var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await SendRequestToServer(() => httpClient.PutAsync(endpoint, content));

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions
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

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            await HandleErrorResponse(response);
            return default;
        }

        public static async Task<T?> DeleteAsync<T>(string endpoint)
        {
            AddAuthorizationHeader();

            var response = await SendRequestToServer(() => httpClient.DeleteAsync(endpoint));

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return default;
            }

            await HandleErrorResponse(response);
            return default;
        }

        public static async Task<Image?> GetUserAvatarAsync()
        {
            AddAuthorizationHeader();

            var response = await httpClient.GetAsync("/profile/avatar");

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return null;
            }

            if (response.IsSuccessStatusCode)
            {
                var imageStream = await response.Content.ReadAsStreamAsync();
                return Image.FromStream(imageStream);
            }

            return null;
        }

        public static async Task<T?> UploadUserAvatarAsync<T>(Image image)
        {
            AddAuthorizationHeader();

            using var memoryStream = new MemoryStream();

            image.Save(memoryStream, ImageFormat.Jpeg);
            var content = new ByteArrayContent(memoryStream.ToArray());
            content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            var response = await httpClient.PostAsync("/profile/avatar", content);

            if (response.IsSuccessStatusCode)
            {
                return default;
            }

            await HandleErrorResponse(response);
            return default;
        }
    }
}