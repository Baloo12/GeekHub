using System.Collections.Generic;
using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Developers
{
    public class QueryOrCreateDevelopersByNames : IRequest<IEnumerable<Developer>>
    {
        public IEnumerable<string> Names { get; }

        public QueryOrCreateDevelopersByNames(IEnumerable<string> names)
        {
            Names = names;
        }
    }
}