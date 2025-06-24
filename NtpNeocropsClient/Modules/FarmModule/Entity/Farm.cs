using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Modules.FarmModule.Entity
{
    [Serializable]
    public class Farm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Oib { get; set; } = string.Empty;
        public string CountryIsoCode { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}
