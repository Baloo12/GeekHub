using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.VideoGames
{
    public class QueryAllVideoGamesSteamIdsHandler : IRequestHandler<QueryAllVideoGamesSteamIds, IEnumerable<string>>
    {
        private readonly IVideoGamesRepository _repository;

        public QueryAllVideoGamesSteamIdsHandler(
            IVideoGamesRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<string>> Handle(
            QueryAllVideoGamesSteamIds request,
            CancellationToken cancellationToken = default)
        {
            var games = await _repository.GetAllSteamIdsAsync();

            return games;
        }
    }
}