using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Specifications.Interfaces;
using Microsoft.Extensions.Logging;

namespace GeekHub.SteamProvider.Domain.Specifications
{
    public class CollectAllVideoGamesFromSteamApiSpecification : ICollectAllVideoGamesFromSteamApiSpecification
    {
        private readonly IVideoGamesRepository _repository;
        private readonly ICollectVideoGameFromSteamApiSpecification _collectVideoGameFromSteamApiSpecification;
        private readonly ILogger<CollectAllVideoGamesFromSteamApiSpecification> _logger;

        public CollectAllVideoGamesFromSteamApiSpecification(
            IVideoGamesRepository repository,
            ICollectVideoGameFromSteamApiSpecification collectVideoGameFromSteamApiSpecification,
            ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _collectVideoGameFromSteamApiSpecification = collectVideoGameFromSteamApiSpecification;
            _logger = loggerFactory.CreateLogger<CollectAllVideoGamesFromSteamApiSpecification>();
        }
        
        public async Task ExecuteAsync()
        {
            var ids = await _repository.GetAllSteamIdsAsync();
            
            foreach (var gameId in ids)
            {
                await _collectVideoGameFromSteamApiSpecification.ExecuteAsync(gameId);
            }
        }
    }
}