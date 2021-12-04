using System;
using System.Collections.Generic;
using GeekHub.Common.HttpClient.Exceptions;

namespace GeekHub.VideoGames.Web.Client
{
    public class VideoGamesClientException : ApiClientException
    {
        public VideoGamesClientException(
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