using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Handlers
{
    public class SynchronizeVideoGamesCommandHandler : IRequestHandler<SynchronizeVideoGamesCommand, IEnumerable<VideoGame>>
    {
        private readonly IVideoGamesRepository _repository;

        public SynchronizeVideoGamesCommandHandler(
            IVideoGamesRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<VideoGame>> Handle(
            SynchronizeVideoGamesCommand request,
            CancellationToken cancellationToken = default)
        {
            var updatedGames = new List<VideoGame>();
            
            foreach (var videoGame in request.VideoGamesToUpdate)
            {
                var updated = await EnrichVideoGameWithGeekHubId(videoGame);
                updatedGames.Add(updated);
            }

            await _repository.SaveChangesAsync();

            return updatedGames;
        }

        private async Task<VideoGame> EnrichVideoGameWithGeekHubId(SynchronizedVideoGameDto videoGame)
        {
            var existedGame = await _repository.GetAsync(videoGame.Id);

            if (existedGame == null)
            {
                //Custom exception
                throw new Exception();
            }
            
            existedGame.GeekHubId = videoGame.GeekHubId;
            
            var updated = _repository.Update(existedGame);
            
            return updated;
        }
    }
}