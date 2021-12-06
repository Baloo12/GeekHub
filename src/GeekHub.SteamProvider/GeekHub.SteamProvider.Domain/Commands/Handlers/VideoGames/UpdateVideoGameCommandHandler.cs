using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.VideoGames;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Handlers.VideoGames
{
    public class UpdateVideoGameCommandHandler : IRequestHandler<UpdateVideoGameCommand, VideoGame>
    {
        private readonly IVideoGamesRepository _repository;

        public UpdateVideoGameCommandHandler(
            IVideoGamesRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<VideoGame> Handle(
            UpdateVideoGameCommand request,
            CancellationToken cancellationToken = default)
        {
            var updated = _repository.Update(request.VideoGameToUpdate);
            await _repository.SaveChangesAsync();

            return updated;
        }
    }
}