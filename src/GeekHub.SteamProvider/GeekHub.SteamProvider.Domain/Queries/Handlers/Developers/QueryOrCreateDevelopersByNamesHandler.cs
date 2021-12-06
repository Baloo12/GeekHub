using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Developers;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.Developers
{
    public class QueryOrCreateDevelopersByNamesHandler : IRequestHandler<QueryOrCreateDevelopersByNames, IEnumerable<Developer>>
    {
        private readonly IMediator _mediator;

        public QueryOrCreateDevelopersByNamesHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<IEnumerable<Developer>> Handle(
            QueryOrCreateDevelopersByNames request,
            CancellationToken cancellationToken = default)
        {
            var developers = new List<Developer>();
            
            foreach (var developerName in request.Names)
            {
                var queryOrCreateDeveloper = new QueryOrCreateDeveloperByName(developerName);
                var developer = await _mediator.Send(queryOrCreateDeveloper, cancellationToken);
                developers.Add(developer);
            }
            
            return developers;
        }
    }
}