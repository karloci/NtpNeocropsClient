using ClassLibrary;
using CredentialManagement;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Utils;
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
            var cred = new Credential { Target = "Neocrops" };
            if (cred.Load())
            {
                try
                {
                    var data = await ApiClient.PostAsync<AuthenticationResponseDto>(
                        "/authentication/refresh-token",
                        new RefreshTokenRequestDto
                        {
                            RefreshToken = cred.Password
                        });

                    if (data != null)
                    {
                        cred.Username = data.User.Email;
                        cred.Password = data.RefreshToken;
                        cred.Save();

                        NeocropsState.LoggedInUser = data.User;
                        NeocropsState.AccessToken = data.AccessToken;

                        Application.Run(new ForecastForm());
                        return;
                    }
                }
                catch (ApiException)
                {
                    cred.Delete();
                }
            }

            Application.Run(new LoginForm());
        }
    }
}