using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Genres
{
    public class QueryOrCreateGenreByName : IRequest<Genre>
    {
        public string Name { get; }

        public QueryOrCreateGenreByName(string name)
        {
            Name = name;
        }
    }
}