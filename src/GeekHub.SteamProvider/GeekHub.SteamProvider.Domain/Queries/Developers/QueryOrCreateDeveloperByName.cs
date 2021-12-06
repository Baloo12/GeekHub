using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Developers
{
    public class QueryOrCreateDeveloperByName : IRequest<Developer>
    {
        public string Name { get; }

        public QueryOrCreateDeveloperByName(string name)
        {
            Name = name;
        }
    }
}