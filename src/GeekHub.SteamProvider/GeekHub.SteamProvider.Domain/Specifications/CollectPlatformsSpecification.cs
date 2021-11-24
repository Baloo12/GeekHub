using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.Common.Extensions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Specifications.Interfaces;
using Microsoft.Extensions.Logging;

namespace GeekHub.SteamProvider.Domain.Specifications
{
    public class CollectPlatformsSpecification : ICollectPlatformsSpecification
    {
        private readonly IPlatformsRepository _repository;
        private readonly ILogger<CollectPlatformsSpecification> _logger;

        public CollectPlatformsSpecification(
            IPlatformsRepository repository,
            ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger<CollectPlatformsSpecification>();
        }
        
        public async Task<IEnumerable<Platform>> ExecuteAsync(List<string> platformsNames)
        {
            var platforms = new List<Platform>();

            if (!platformsNames.IsNullOrEmpty())
            {
                foreach (var platformName in platformsNames)
                {
                    var platformPersisted = await _repository.GetByName(platformName) ?? await CreatePlatform(platformName);

                    platforms.Add(platformPersisted);
                }
            }

            return platforms;
        }

        private async Task<Platform> CreatePlatform(string platformName)
        {
            var platform = new Platform()
            {
                Name = platformName
            };

            var platformPersisted = await _repository.CreateAndReturnAsync(platform);
            await _repository.SaveChangesAsync();
            
            return platformPersisted;
        }
    }
}