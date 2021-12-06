using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Developers;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Developers;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.Developers
{
    public class QueryOrCreateDeveloperByNameHandler : IRequestHandler<QueryOrCreateDeveloperByName, Developer>
    {
        private readonly IMediator _mediator;

        public QueryOrCreateDeveloperByNameHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<Developer> Handle(
            QueryOrCreateDeveloperByName request,
            CancellationToken cancellationToken = default)
        {
            var query = new QueryDeveloperByName(request.Name);
            var developer = await _mediator.Send(query, cancellationToken);

            if (developer == null)
            {
                var command = new CreateDeveloperCommand(request.Name);
                var created = await _mediator.Send(command, cancellationToken);

                return created;
            }

            return developer;
        }
    }
}