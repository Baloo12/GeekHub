using GamesHub.GamesProvider.Contracts.Interfaces;
using GamesHub.GamesProvider.Contracts.Models;
using GamesHub.SteamGamesProvider.Constants;
using GamesHub.SteamGamesProvider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GamesHub.SteamGamesProvider.Services
{
    public class SteamGamesProvider : ISteamGamesProvider
    {
        private readonly HttpClient _apiClient;
        private readonly HttpClient _storeClient;

        public SteamGamesProvider()
        {
            var apiClient = new HttpClient
            {
                BaseAddress = new Uri(SteamUrls.Api)
            };
            var storeClient = new HttpClient
            {
                BaseAddress = new Uri(SteamUrls.Store)
            };

            _apiClient = apiClient;
            _storeClient = storeClient;            
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            var url = SteamUrls.AllGames;
            var games = await Request<SteamGames>(_apiClient, url);

            return games.AppList.Apps.Select(a => new Game()
            {
                Id = a.AppId.ToString(),
                Name = a.Name
            });
        }

        public async Task<GameDetails> GetDetails(string id)
        {
            var url = SteamUrls.GameDetails + id;
            var game = await Request<Dictionary<string, SteamGameDetails>>(_storeClient, url);

            var details = game[id];
            if (!details.Success)
            {
                return null;
            }

            return new GameDetails()
            {
                Description = details.Data.ShortDescription,
                Name = details.Data.Name,
                Website = details.Data.Website,
                Developers = details.Data.Developers,
                Publishers = details.Data.Publishers,
                IsFree = details.Data.IsFree,
                RequiredAge = details.Data.RequiredAge,
                Type = details.Data.Type,
                Genres = details.Data.Genres.Select(g => g.Description).ToList(),
                Image = details.Data.Image,
                Platforms = details.Data.Platforms.Where(p => p.Value).Select(p => p.Key).ToList(),
                ReleaseDate = details.Data.ReleaseDate.Date ?? "Coming Soon"
            };
        }

        private async Task<TResponse> Request<TResponse>(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject
                <TResponse>(responseContent);
        }
    }
}
