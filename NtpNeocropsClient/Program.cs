using ClassLibrary;
using CredentialManagement;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Utils;
using System.Diagnostics;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NtpNeocropsClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            Credential? cred = NeocropsState.GetCredentials();

            if (cred.Password == null)
            {
                Application.Run(new LoginForm());
            }
            else
            {
                try
                {
                    var data = await ApiClient.PostAsync<AuthenticationResponseDto>("/authentication/refresh-token", new RefreshTokenRequestDto
                    {
                        RefreshToken = cred.Password
                    });

                    if (data != null)
                    {
                        NeocropsState.SaveCredentials(data.User.Email, data.RefreshToken);
                        NeocropsState.LoggedInUser = data.User;
                        NeocropsState.AccessToken = data.AccessToken;
                        NeocropsState.RefreshToken = data.RefreshToken;

                        Application.Run(new ForecastForm());
                        return;
                    }
                }
                catch (ApiException)
                {
                    Application.Run(new LoginForm());
                }
            }
        }
    }
}