using System;
using System.Collections.Generic;

namespace GeekHub.Common.HttpClient.Exceptions
{
    public class ApiClientException : HttpResponseException
    {
        protected ApiClientException(
            string message,
            int statusCode,
            string response,
            Dictionary<string, IEnumerable<string>> headers,
            Exception innerException)
            : base(new ExceptionResponse { Message = message, StatusCode = statusCode }, innerException)
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