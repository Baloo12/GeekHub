namespace GamesHub.GamesProvider.Steam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using GamesHub.GamesProvider.Contracts.Models;

    public class SteamGamesProvider : BaseGamesProvider
    {
        private readonly HttpClient _apiClient;

        private readonly HttpClient _storeClient;

        public SteamGamesProvider()
        {
            var apiClient = new HttpClient { BaseAddress = new Uri(SteamUrls.Api) };
            var storeClient = new HttpClient { BaseAddress = new Uri(SteamUrls.Store) };

            _apiClient = apiClient;
            _storeClient = storeClient;
        }

        protected override GameSource Source => GameSource.Steam;

        public override async Task<IEnumerable<string>> GetAllIds()
        {
            var url = SteamUrls.AllGames;
            var games = await Request<SteamGames>(_apiClient, url);

            return games.AppList.Apps.Select(a => a.AppId.ToString());
        }

        protected override async Task<GameDetails> RequestDetails(string id)
        {
            var url = SteamUrls.GameDetails + id;
            var game = await Request<Dictionary<string, SteamGameDetails>>(_storeClient, url);

            var details = game[id];
            if (!details.Success)
            {
                return null;
            }

            var result = new GameDetails
                             {
                                 Description = details.Data.ShortDescription,
                                 Name = details.Data.Name,
                                 Website = details.Data.Website,
                                 Developers = details.Data.Developers,
                                 Publishers = details.Data.Publishers,
                                 IsFree = details.Data.IsFree,
                                 RequiredAge = details.Data.RequiredAge,
                                 Type = details.Data.Type,
                                 Genres = details.Data.Genres?.Select(g => g.Description).ToList(),
                                 Image = details.Data.Image,
                                 Platforms = details.Data.Platforms?.Where(p => p.Value).Select(p => p.Key).ToList(),
                                 ReleaseDate = details.Data.ReleaseDate?.Date ?? "Coming Soon"
                             };
            return result;
        }
    }
}