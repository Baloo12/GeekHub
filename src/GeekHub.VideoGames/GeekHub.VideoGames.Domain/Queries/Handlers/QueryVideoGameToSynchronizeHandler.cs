using System.Threading;
using System.Threading.Tasks;
using GeekHub.VideoGames.Domain.Entities;
using GeekHub.VideoGames.Domain.Interfaces;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries.Handlers
{
    public class QueryVideoGameToSynchronizeHandler : IRequestHandler<QueryVideoGameToSynchronize, VideoGame>
    {
        private readonly IVideoGamesRepository _videoGamesRepository;

        public QueryVideoGameToSynchronizeHandler(
            IVideoGamesRepository videoGamesRepository)
        {
            _videoGamesRepository = videoGamesRepository;
        }
        
        public async Task<VideoGame> Handle(
            QueryVideoGameToSynchronize request,
            CancellationToken cancellationToken = default)
        {
            var game = await _videoGamesRepository.GetByNameAsync(request.VideoGameToSynchronize.Name);

            return game;
        }
    }
}