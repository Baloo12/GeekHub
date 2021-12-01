using System.Threading;
using System.Threading.Tasks;
using GeekHub.VideoGames.Domain.Entities;
using GeekHub.VideoGames.Domain.Interfaces;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries.Handlers
{
    public class GetVideoGameToSynchronizeQueryHandler : IRequestHandler<GetVideoGameToSynchronizeQuery, VideoGame>
    {
        private readonly IVideoGamesRepository _videoGamesRepository;

        public GetVideoGameToSynchronizeQueryHandler(
            IVideoGamesRepository videoGamesRepository)
        {
            _videoGamesRepository = videoGamesRepository;
        }
        
        public async Task<VideoGame> Handle(
            GetVideoGameToSynchronizeQuery request,
            CancellationToken cancellationToken = default)
        {
            var game = await _videoGamesRepository.GetByNameAsync(request.RequestDto.Name);

            return game;
        }
    }
}