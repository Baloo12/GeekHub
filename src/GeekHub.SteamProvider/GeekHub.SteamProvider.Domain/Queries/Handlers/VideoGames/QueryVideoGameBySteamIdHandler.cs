using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.VideoGames
{
    public class QueryVideoGameBySteamIdHandler : IRequestHandler<QueryVideoGameBySteamId, VideoGame>
    {
        private readonly IVideoGamesRepository _repository;

        public QueryVideoGameBySteamIdHandler(
            IVideoGamesRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<VideoGame> Handle(
            QueryVideoGameBySteamId request,
            CancellationToken cancellationToken = default)
        {
            var game = await _repository.GetBySteamIdAsync(request.SteamId);

            return game;
        }
    }
}