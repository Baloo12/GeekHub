using System;
using System.Collections.Generic;
using GeekHub.Common.HttpClient.Exceptions;

namespace GeekHub.SteamProvider.Web.Client
{
    public class SteamProviderClientException : ApiClientException
    {
        public SteamProviderClientException(
            string message,
            int statusCode,
            string response,
            IReadOnlyDictionary<string, IEnumerable<string>> headers,
            Exception innerException)
            : base(
                message,
                statusCode,
                response,
                (Dictionary<string, IEnumerable<string>>)headers,
                innerException)
        {
        }
    }
}