using System;
using System.Collections.Generic;

namespace GeekHub.SteamProvider.Web.Client
{
    public class ApiClientException : HttpResponseException
    {
        protected ApiClientException(
            string message,
            int statusCode,
            string response,
            Dictionary<string,
                IEnumerable<string>> headers,
            Exception innerException,
            string type = null)
            : base(new ExceptionResponse { Message = message, StatusCode = statusCode, Type = type })
        {
            ResponseData = response;
            Headers = headers;
        }

        private string ResponseData { get; }

        private Dictionary<string, IEnumerable<string>> Headers { get; }
 
        public override string ToString()
        {
            return $"HTTP Response: \n\n{ResponseData}\n\n{base.ToString()}";
        }
    }
}