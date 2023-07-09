using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Genres;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.Genres
{
    public class QueryOrCreateGenresByNamesHandler : IRequestHandler<QueryOrCreateGenresByNames, IEnumerable<Genre>>
    {
        private readonly IMediator _mediator;

        public QueryOrCreateGenresByNamesHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<IEnumerable<Genre>> Handle(
            QueryOrCreateGenresByNames request,
            CancellationToken cancellationToken = default)
        {
            var genres = new List<Genre>();
            
            foreach (var genreName in request.Names)
            {
                var queryOrCreateGenre = new QueryOrCreateGenreByName(genreName);
                var genre = await _mediator.Send(queryOrCreateGenre, cancellationToken);
                genres.Add(genre);
            }
            
            return genres;
        }
    }
}