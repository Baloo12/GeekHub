using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Platforms
{
    public class QueryOrCreatePlatformByName : IRequest<Platform>
    {
        public string Name { get; }

        public QueryOrCreatePlatformByName(string name)
        {
            Name = name;
        }
    }
}