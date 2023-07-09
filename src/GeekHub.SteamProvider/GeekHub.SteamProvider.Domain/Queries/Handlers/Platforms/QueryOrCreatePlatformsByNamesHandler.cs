using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Platforms;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.Platforms
{
    public class QueryOrCreatePlatformsByNamesHandler : IRequestHandler<QueryOrCreatePlatformsByNames, IEnumerable<Platform>>
    {
        private readonly IMediator _mediator;

        public QueryOrCreatePlatformsByNamesHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<IEnumerable<Platform>> Handle(
            QueryOrCreatePlatformsByNames request,
            CancellationToken cancellationToken = default)
        {
            var platforms = new List<Platform>();
            
            foreach (var platformName in request.Names)
            {
                var queryOrCreatePlatform = new QueryOrCreatePlatformByName(platformName);
                var platform = await _mediator.Send(queryOrCreatePlatform, cancellationToken);
                platforms.Add(platform);
            }
            
            return platforms;
        }
    }
}