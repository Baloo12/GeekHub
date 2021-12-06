using System;
using System.Net.Http;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Constants;
using GeekHub.SteamProvider.Domain.Models.Internal;

namespace GeekHub.SteamProvider.Domain.HttpClients
{
    public class SteamApiClient : ISteamApiClient
    {
        private readonly HttpClient _httpClient;

        public SteamApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
            _httpClient.BaseAddress = new Uri(SteamUrls.Api);
        }

        public async Task<SteamGames> GetAllGames()
        {
            var games = await _httpClient.GetAsync<SteamGames>(SteamUrls.GetAllGames);

            return games;
        }
    }
}