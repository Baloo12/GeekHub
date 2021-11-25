using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Constants;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.HttpClients;
using GeekHub.SteamProvider.Domain.Models.Internal;
using GeekHub.SteamProvider.Domain.Specifications.Interfaces;
using Microsoft.Extensions.Logging;

namespace GeekHub.SteamProvider.Domain.Specifications
{
    public class CollectIdsFromSteamApiSpecification : ICollectIdsFromSteamApiSpecification
    {
        private readonly IVideoGamesRepository _repository;
        private readonly SteamApiClient _steamApiClient;
        private readonly ILogger<CollectIdsFromSteamApiSpecification> _logger;

        public CollectIdsFromSteamApiSpecification(
            IVideoGamesRepository repository,
            ILoggerFactory loggerFactory,
            SteamApiClient steamApiClient)
        {
            _repository = repository;
            _steamApiClient = steamApiClient;
            _logger = loggerFactory.CreateLogger<CollectIdsFromSteamApiSpecification>();
        }

        public async Task ExecuteAsync()
        {
            var games = await _steamApiClient.GetAllGames();

            var gamesPersisted =  games.AppList.Apps.Select(a => new VideoGame
            {
                SteamId = a.AppId.ToString(),
                Name = a.Name,
                ModifiedAt = DateTime.Now
            });

            await _repository.CreateAsync(gamesPersisted);
            await _repository.SaveChangesAsync();
        }
    }
}