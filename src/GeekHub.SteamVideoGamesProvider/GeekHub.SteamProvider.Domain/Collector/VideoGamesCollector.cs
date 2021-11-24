using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Constants;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Models.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GeekHub.SteamProvider.Domain.Collector
{
    public class VideoGamesCollector : IVideoGamesCollector
    {
        private readonly IVideoGamesRepository _repository;
        private readonly ILogger<VideoGamesCollector> _logger;
        private readonly HttpClient _apiClient;

        private readonly HttpClient _storeClient;

        public VideoGamesCollector(IVideoGamesRepository repository, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger<VideoGamesCollector>();
            var apiClient = new HttpClient { BaseAddress = new Uri(SteamUrls.Api) };
            var storeClient = new HttpClient { BaseAddress = new Uri(SteamUrls.Store) };

            _apiClient = apiClient;
            _storeClient = storeClient;
        }

        public async Task<IEnumerable<string>> GetAllIds()
        {
            var url = SteamUrls.AllGames;
            var games = await Request<SteamGames>(_apiClient, url);

            return games.AppList.Apps.Select(a => a.AppId.ToString());
        }

        public async Task<VideoGameDetails> GetDetails(string id)
        {
            var url = SteamUrls.GameDetails + id;
            var game = await Request<Dictionary<string, SteamGameDetails>>(_storeClient, url);

            var details = game[id];
            if (!details.Success)
            {
                return null;
            }

            var result = new VideoGameDetails
            {
                Description = details.Data.ShortDescription,
                Name = details.Data.Name,
                Website = details.Data.Website,
                // Developers = details.Data.Developers,
                // Publishers = details.Data.Publishers,
                IsFree = details.Data.IsFree,
                RequiredAge = details.Data.RequiredAge,
                Type = details.Data.Type,
                // Genres = details.Data.Genres?.Select(g => g.Description).ToList(),
                Image = details.Data.Image,
                // Platforms = details.Data.Platforms?.Where(p => p.Value).Select(p => p.Key).ToList(),
                ReleaseDate = details.Data.ReleaseDate?.Date ?? "Coming Soon"
            };
            
            return result;
        }

        public async Task BeginCollect()
        {
            _logger.LogInformation("Request for Ids");
            
            var ids = await GetAllIds();
            
            _logger.LogInformation("Ids received");
            
            foreach (var gameId in ids)
            {
                _logger.LogInformation("Request for game ${gameId}", gameId);
                var gameDetails = await GetDetails(gameId);
                _logger.LogInformation("Response for game ${gameId}", gameId);

                if (gameDetails != null)
                {
                    var game = new VideoGameEntityBuilder()
                        .WithDetails(gameDetails)
                        .WithSource(gameId)
                        // .WithDevelopers(developersIds)
                        .Build();
                    
                    _logger.LogInformation("Mapped game ${gameId}", gameId);

                    await _repository.CreateAsync(game);
                    _logger.LogInformation("Added game ${gameId}", gameId);
                    await _repository.SaveChangesAsync();
                    _logger.LogInformation("Saved game ${gameId}", gameId);
                }
            }
        }
        
        private async Task<TResponse> Request<TResponse>(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
    }
}