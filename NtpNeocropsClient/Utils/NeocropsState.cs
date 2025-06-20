using CredentialManagement;
using NtpNeocropsClient.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NtpNeocropsClient.Utils
{
    internal class NeocropsState
    {
        public static User? LoggedInUser { get; set; }
        public static string? RefreshToken { get; set; }
        public static string? AccessToken { get; set; }

        private const string CredentialTarget = "Neocrops";

        public static void SaveCredentials(string username, string password)
        {
            DeleteCredentials();

            var cred = new Credential
            {
                Target = CredentialTarget,
                Username = username,
                Password = password,
                Type = CredentialType.Generic,
                PersistanceType = PersistanceType.LocalComputer
            };

            cred.Save();

            Debug.WriteLine($"New credentials: {cred.Password}");
        }

        public static Credential? GetCredentials()
        {
            var cred = new Credential { Target = CredentialTarget };
            if (cred.Load())
            {
                return cred;
            }

            return null;
        }

        public static void DeleteCredentials()
        {
            var cred = new Credential { Target = CredentialTarget };
            if (cred.Exists())
            {
                cred.Delete();
                Debug.WriteLine("Credentials deleted!");
            }
        }
    }
}
