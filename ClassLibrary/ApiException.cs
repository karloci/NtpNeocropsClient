using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ApiException: HttpRequestException
    {
        public HttpStatusCode StatusCode { get; }
        public string ServerMessage { get; }

        public ApiException(HttpStatusCode statusCode, string message, string serverMessage = null) : base(serverMessage)
        {
            StatusCode = statusCode;
            ServerMessage = serverMessage;
        }
    }
}
