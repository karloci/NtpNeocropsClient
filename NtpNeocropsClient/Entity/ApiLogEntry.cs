using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Entity
{
    public class ApiLogEntry
    {
        public DateTime Timestamp { get; set; }
        public string HttpMethod { get; set; }
        public string Endpoint { get; set; }
        public object? Payload { get; set; }
        public JsonElement ResponseContent { get; set; }
    }
}
