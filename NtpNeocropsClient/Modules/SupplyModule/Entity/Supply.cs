using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Modules.SupplyModule.Entity
{
    [Serializable]
    public class Supply
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MeasureUnit { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;

        public string DisplayText => $"{Name} ({Manufacturer}) - [{MeasureUnit}]";

        public override string ToString()
        {
            return Name;
        }
    }
}
