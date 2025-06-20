using NtpNeocropsClient.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Utils
{
    internal class NeocropsState
    {
        public static User? LoggedInUser { get; set; }
        public static string? RefreshToken { get; set; }
        public static string? AccessToken { get; set; }
    }
}
