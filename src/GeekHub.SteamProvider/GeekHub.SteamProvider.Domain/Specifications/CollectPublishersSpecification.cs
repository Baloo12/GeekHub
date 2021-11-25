using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.Common.Extensions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Specifications.Interfaces;
using Microsoft.Extensions.Logging;

namespace GeekHub.SteamProvider.Domain.Specifications
{
    public class CollectPublishersSpecification : ICollectPublishersSpecification
    {
        private readonly IPublishersRepository _repository;
        private readonly ILogger<CollectPublishersSpecification> _logger;

        public CollectPublishersSpecification(
            IPublishersRepository repository,
            ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger<CollectPublishersSpecification>();
        }
        
        public async Task<IEnumerable<Publisher>> ExecuteAsync(List<string> publishersNames)
        {
            var publishers = new List<Publisher>();

            if (!publishersNames.IsNullOrEmpty())
            {
                foreach (var publisherName in publishersNames)
                {
                    var publisher = await _repository.GetByName(publisherName) ?? await CreatePublisher(publisherName);

                    publishers.Add(publisher);
                }
            }

            return publishers;
        }

        private async Task<Publisher> CreatePublisher(string publisherName)
        {
            var publisherToCreate = new Publisher
            {
                Name = publisherName
            };

            var publisher = await _repository.CreateAndReturnAsync(publisherToCreate);
            await _repository.SaveChangesAsync();
            
            return publisher;
        }
    }
}