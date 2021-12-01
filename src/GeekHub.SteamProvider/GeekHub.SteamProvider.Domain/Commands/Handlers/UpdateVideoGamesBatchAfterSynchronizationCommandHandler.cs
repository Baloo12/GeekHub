using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Handlers
{
    public class UpdateVideoGamesBatchAfterSynchronizationCommandHandler : IRequestHandler<UpdateVideoGamesBatchAfterSynchronizationCommand, IEnumerable<VideoGame>>
    {
        private readonly IVideoGamesRepository _repository;

        public UpdateVideoGamesBatchAfterSynchronizationCommandHandler(
            IVideoGamesRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<VideoGame>> Handle(
            UpdateVideoGamesBatchAfterSynchronizationCommand request,
            CancellationToken cancellationToken = default)
        {
            var updatedGames = new List<VideoGame>();
            foreach (var videoGame in request.VideoGamesToUpdate)
            {
                var existedGame = await _repository.GetAsync(videoGame.Id);
                existedGame.GeekHubId = videoGame.GeekHubId;
                var updated = _repository.Update(existedGame);
                updatedGames.Add(updated);
            }

            await _repository.SaveChangesAsync();

            return updatedGames;
        }
    }
}