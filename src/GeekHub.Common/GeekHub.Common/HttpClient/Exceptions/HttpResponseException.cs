using System;

namespace GeekHub.Common.HttpClient.Exceptions
{
    public class HttpResponseException : Exception
    {
        protected HttpResponseException(ExceptionResponse response, Exception innerException)
            : base(response?.Message, innerException)
        {
            Response = response;
        }

        private ExceptionResponse Response { get; }
    }
}