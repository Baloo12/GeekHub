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
using GeekHub.SteamProvider.Domain.Utils;
using Microsoft.Extensions.Logging;

namespace GeekHub.SteamProvider.Domain.Specifications
{
    public class CollectVideoGameFromSteamApiSpecification : ICollectVideoGameFromSteamApiSpecification
    {
        private readonly IVideoGamesRepository _repository;
        private readonly SteamStoreClient _steamStoreClient;
        private readonly ICollectDevelopersSpecification _collectDevelopersSpecification;
        private readonly ICollectPublishersSpecification _collectPublishersSpecification;
        private readonly ICollectGenresSpecification _collectGenresSpecification;
        private readonly ICollectPlatformsSpecification _collectPlatformsSpecification;
        private readonly ILogger<CollectVideoGameFromSteamApiSpecification> _logger;

        public CollectVideoGameFromSteamApiSpecification(
            IVideoGamesRepository repository,
            ILoggerFactory loggerFactory,
            SteamStoreClient steamStoreClient,
            ICollectDevelopersSpecification collectDevelopersSpecification,
            ICollectPublishersSpecification collectPublishersSpecification,
            ICollectGenresSpecification collectGenresSpecification,
            ICollectPlatformsSpecification collectPlatformsSpecification)
        {
            _repository = repository;
            _steamStoreClient = steamStoreClient;
            _collectDevelopersSpecification = collectDevelopersSpecification;
            _collectPublishersSpecification = collectPublishersSpecification;
            _collectGenresSpecification = collectGenresSpecification;
            _collectPlatformsSpecification = collectPlatformsSpecification;
            _logger = loggerFactory.CreateLogger<CollectVideoGameFromSteamApiSpecification>();
        }

        public async Task ExecuteAsync(string steamId)
        {
            var details = await _steamStoreClient.GetGameDetails(steamId);
            if (!details.Success)
            {
                return;
            }

            var developers = await _collectDevelopersSpecification.ExecuteAsync(details.Data.Developers);
            var publishers = await _collectPublishersSpecification.ExecuteAsync(details.Data.Publishers);
            var genres = await _collectGenresSpecification.ExecuteAsync(details.Data.Genres?.Select(g => g.Description).ToList());
            var platforms = await _collectPlatformsSpecification.ExecuteAsync(details.Data.Platforms?.Where(p => p.Value).Select(p => p.Key).ToList());
            
            var game = await _repository.GetBySteamIdAsync(steamId);

            var updatedGame = new VideoGameEntityBuilder(game)
                .WithDetails(details.Data)
                .WithSourceId(steamId)
                .WithDevelopers(developers.ToList())
                .WithPublishers(publishers.ToList())
                .WithGenres(genres.ToList())
                .WithPlatforms(platforms.ToList())
                .Build();

            _repository.Update(updatedGame);
            await _repository.SaveChangesAsync();
        }
    }
}