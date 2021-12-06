using System.Collections.Generic;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.VideoGames
{
    public class SynchronizeVideoGamesCommand : IRequest<IEnumerable<VideoGame>>
    {
        public IEnumerable<SynchronizedVideoGameDto> VideoGamesToUpdate { get; }

        public SynchronizeVideoGamesCommand(IEnumerable<SynchronizedVideoGameDto> videoGamesToUpdate)
        {
            VideoGamesToUpdate = videoGamesToUpdate;
        }
    }
}