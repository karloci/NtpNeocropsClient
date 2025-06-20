using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Validator
    {
        public static bool IsRequired(string? value)
        {
            return !string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(value);
        }

        public static bool HasMinLength(string? value, int minLength)
        {
            return value?.Length >= minLength;
        }

        public static bool HasMaxLength(string? value, int maxLength)
        {
            return value?.Length <= maxLength;
        }

        public static bool IsValidEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(email))
            {
                return false;
            }

            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        public static bool IsValidOib(string? oib)
        {
            //https://github.com/domagojpa/oib-validation/blob/main/CSharp/oib-validation.cs

            if (string.IsNullOrEmpty(oib) || !Regex.IsMatch(oib, "^[0-9]{11}$"))
                return false;

            var oibSpan = oib.AsSpan();
            var a = 10;
            for (var i = 0; i < 10; i++)
            {
                a += int.Parse(oibSpan.Slice(i, 1));
                a %= 10;

                if (a == 0)
                    a = 10;

                a *= 2;
                a %= 11;
            }

            var kontrolni = 11 - a;

            if (kontrolni == 10)
                kontrolni = 0;

            return kontrolni == int.Parse(oibSpan.Slice(10, 1));
        }
    }
}
