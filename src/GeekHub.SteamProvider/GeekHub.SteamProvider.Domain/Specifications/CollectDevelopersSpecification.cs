using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.Common.Extensions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Specifications.Interfaces;
using Microsoft.Extensions.Logging;

namespace GeekHub.SteamProvider.Domain.Specifications
{
    public class CollectDevelopersSpecification : ICollectDevelopersSpecification
    {
        private readonly IDevelopersRepository _repository;
        private readonly ILogger<CollectDevelopersSpecification> _logger;

        public CollectDevelopersSpecification(
            IDevelopersRepository repository,
            ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger<CollectDevelopersSpecification>();
        }
        
        public async Task<IEnumerable<Developer>> ExecuteAsync(List<string> developersNames)
        {
            var developers = new List<Developer>();

            if (!developers.IsNullOrEmpty())
            {
                foreach (var developerName in developersNames)
                {
                    var developer = await _repository.GetByName(developerName) ?? await CreateDeveloper(developerName);

                    developers.Add(developer);
                }
            }

            return developers;
        }

        private async Task<Developer> CreateDeveloper(string developerName)
        {
            var developerToCreate = new Developer
            {
                Name = developerName
            };

            var developer = await _repository.CreateAndReturnAsync(developerToCreate);
            await _repository.SaveChangesAsync();
            
            return developer;
        }
    }
}