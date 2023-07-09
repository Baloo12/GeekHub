using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Genres;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Genres;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.Genres
{
    public class QueryOrCreateGenreByNameHandler : IRequestHandler<QueryOrCreateGenreByName, Genre>
    {
        private readonly IMediator _mediator;

        public QueryOrCreateGenreByNameHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<Genre> Handle(
            QueryOrCreateGenreByName request,
            CancellationToken cancellationToken = default)
        {
            var query = new QueryGenreByName(request.Name);
            var genre = await _mediator.Send(query, cancellationToken);

            if (genre == null)
            {
                var command = new CreateGenreCommand(request.Name);
                var created = await _mediator.Send(command, cancellationToken);

                return created;
            }

            return genre;
        }
    }
}