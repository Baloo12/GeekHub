using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace GeekHub.VideoGames.SteamAdapter
{
    public class SteamProviderClient
    {
        public HttpClient HttpClient { get; }

        public SteamProviderClient(HttpClient httpClient, IConfiguration configuration)
        {
            var url = configuration["SteamProviderUrl"];
            
            HttpClient = httpClient;
            HttpClient.BaseAddress = new Uri(url);
        }
    }
}