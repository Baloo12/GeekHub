using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Developers;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.Developers
{
    public class QueryDeveloperByNameHandler : IRequestHandler<QueryDeveloperByName, Developer>
    {
        private readonly IDevelopersRepository _repository;

        public QueryDeveloperByNameHandler(
            IDevelopersRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Developer> Handle(
            QueryDeveloperByName request,
            CancellationToken cancellationToken = default)
        {
            var developer = await _repository.GetByName(request.Name);

            return developer;
        }
    }
}