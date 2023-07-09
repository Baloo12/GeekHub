using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Platforms;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Platforms;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.Platforms
{
    public class QueryOrCreatePlatformByNameHandler : IRequestHandler<QueryOrCreatePlatformByName, Platform>
    {
        private readonly IMediator _mediator;

        public QueryOrCreatePlatformByNameHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<Platform> Handle(
            QueryOrCreatePlatformByName request,
            CancellationToken cancellationToken = default)
        {
            var query = new QueryPlatformByName(request.Name);
            var platform = await _mediator.Send(query, cancellationToken);

            if (platform == null)
            {
                var command = new CreatePlatformCommand(request.Name);
                var created = await _mediator.Send(command, cancellationToken);

                return created;
            }

            return platform;
        }
    }
}