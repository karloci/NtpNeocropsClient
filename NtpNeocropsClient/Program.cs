using ClassLibrary;
using CredentialManagement;
using Microsoft.Win32;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Utils;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NtpNeocropsClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\NeocropsApp\Language"))
            {
                var preferedLanguage = key?.GetValue("Language") as string ?? "en";
                var culture = new CultureInfo(preferedLanguage);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            Credential? cred = NeocropsState.GetCredentials();

            if (cred?.Password == null)
            {
                Application.Run(new LoginForm());
            }
            else
            {
                try
                {
                    var data = Task.Run(() => ApiClient.PostAsync<AuthenticationResponseDto>("/authentication/refresh-token", new RefreshTokenRequestDto
                    {
                        RefreshToken = cred.Password
                    })).GetAwaiter().GetResult();

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