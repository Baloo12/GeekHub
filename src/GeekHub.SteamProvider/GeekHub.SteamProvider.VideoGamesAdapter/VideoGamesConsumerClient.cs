using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace GeekHub.SteamProvider.VideoGamesAdapter
{
    public class VideoGamesConsumerClient
    {
        public HttpClient HttpClient { get; }

        public VideoGamesConsumerClient(HttpClient httpClient, IConfiguration configuration)
        {
            var url = configuration["VideoGamesServiceUrl"];
            
            HttpClient = httpClient;
            HttpClient.BaseAddress = new Uri(url);
        }
    }
}