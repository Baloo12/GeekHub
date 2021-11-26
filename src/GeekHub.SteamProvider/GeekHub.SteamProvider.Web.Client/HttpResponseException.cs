using System;

namespace GeekHub.SteamProvider.Web.Client
{
    public class HttpResponseException : Exception
    {
        protected HttpResponseException(ExceptionResponse response)
            : base(response?.Message)
        {
            Response = response;
        }

        private ExceptionResponse Response { get; }
    }
}