using System.Collections.Generic;
using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Platforms
{
    public class QueryOrCreatePlatformsByNames : IRequest<IEnumerable<Platform>>
    {
        public IEnumerable<string> Names { get; }

        public QueryOrCreatePlatformsByNames(IEnumerable<string> names)
        {
            Names = names;
        }
    }
}