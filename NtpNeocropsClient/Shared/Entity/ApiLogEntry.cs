using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NtpNeocropsClient.Shared.Entity
{
    public class ApiLogEntry
    {
        public DateTime Timestamp { get; set; }
        public string HttpMethod { get; set; } = string.Empty;
        public string Endpoint { get; set; } = string.Empty;
        public object? Payload { get; set; }
        public JsonElement? ResponseContent { get; set; }
    }
}
