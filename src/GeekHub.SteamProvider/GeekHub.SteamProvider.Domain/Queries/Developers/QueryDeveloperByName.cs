using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Developers
{
    public class QueryDeveloperByName : IRequest<Developer>
    {
        public string Name { get; }

        public QueryDeveloperByName(string name)
        {
            Name = name;
        }
    }
}