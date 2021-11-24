using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.Common.Extensions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Specifications.Interfaces;
using Microsoft.Extensions.Logging;

namespace GeekHub.SteamProvider.Domain.Specifications
{
    public class CollectGenresSpecification : ICollectGenresSpecification
    {
        private readonly IGenresRepository _repository;
        private readonly ILogger<CollectGenresSpecification> _logger;

        public CollectGenresSpecification(
            IGenresRepository repository,
            ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger<CollectGenresSpecification>();
        }
        
        public async Task<IEnumerable<Genre>> ExecuteAsync(List<string> genresNames)
        {
            var genres = new List<Genre>();

            if (!genresNames.IsNullOrEmpty())
            {
                foreach (var genreName in genresNames)
                {
                    var genre = await _repository.GetByName(genreName) ?? await CreateGenre(genreName);

                    genres.Add(genre);
                }
            }

            return genres;
        }

        private async Task<Genre> CreateGenre(string genreName)
        {
            var genreToCreate = new Genre
            {
                Name = genreName
            };

            var genre = await _repository.CreateAndReturnAsync(genreToCreate);
            await _repository.SaveChangesAsync();
            
            return genre;
        }
    }
}