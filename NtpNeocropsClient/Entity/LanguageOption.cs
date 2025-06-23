using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Entity
{
    public class LanguageOption
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public override string ToString() => DisplayName;
    }
}
