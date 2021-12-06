using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Platforms
{
    public class QueryPlatformByName : IRequest<Platform>
    {
        public string Name { get; }

        public QueryPlatformByName(string name)
        {
            Name = name;
        }
    }
}