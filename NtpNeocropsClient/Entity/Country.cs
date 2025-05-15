using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Entity
{
    [Serializable]
    public class Country
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
    }

}
