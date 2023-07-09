using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Genres;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.Genres
{
    public class QueryGenreByNameHandler : IRequestHandler<QueryGenreByName, Genre>
    {
        private readonly IGenresRepository _repository;

        public QueryGenreByNameHandler(
            IGenresRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Genre> Handle(
            QueryGenreByName request,
            CancellationToken cancellationToken = default)
        {
            var genre = await _repository.GetByName(request.Name);

            return genre;
        }
    }
}