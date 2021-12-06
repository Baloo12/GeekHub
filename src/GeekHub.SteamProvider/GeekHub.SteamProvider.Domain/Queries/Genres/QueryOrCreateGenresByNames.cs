using System.Collections.Generic;
using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Genres
{
    public class QueryOrCreateGenresByNames : IRequest<IEnumerable<Genre>>
    {
        public IEnumerable<string> Names { get; }

        public QueryOrCreateGenresByNames(IEnumerable<string> names)
        {
            Names = names;
        }
    }
}