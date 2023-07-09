using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Genres
{
    public class QueryGenreByName : IRequest<Genre>
    {
        public string Name { get; }

        public QueryGenreByName(string name)
        {
            Name = name;
        }
    }
}