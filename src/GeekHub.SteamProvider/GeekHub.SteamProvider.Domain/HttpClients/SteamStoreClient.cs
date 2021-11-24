using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Constants;
using GeekHub.SteamProvider.Domain.Models.Internal;

namespace GeekHub.SteamProvider.Domain.HttpClients
{
    public class SteamStoreClient
    {
        private readonly HttpClient _httpClient;

        public SteamStoreClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
            _httpClient.BaseAddress = new Uri(SteamUrls.Store);
        }

        public async Task<SteamGameDetails> GetGameDetails(string steamId)
        {
            var url = SteamUrls.GameDetails + steamId;
            var game = await _httpClient.GetAsync<Dictionary<string, SteamGameDetails>>(url);
            var details = game[steamId];

            return details;
        }
    }
}