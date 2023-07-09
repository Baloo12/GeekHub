using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Platforms;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.Platforms
{
    public class QueryPlatformByNameHandler : IRequestHandler<QueryPlatformByName, Platform>
    {
        private readonly IPlatformsRepository _repository;

        public QueryPlatformByNameHandler(
            IPlatformsRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Platform> Handle(
            QueryPlatformByName request,
            CancellationToken cancellationToken = default)
        {
            var platform = await _repository.GetByName(request.Name);

            return platform;
        }
    }
}