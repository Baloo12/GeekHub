using System.Collections.Generic;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands
{
    public class UpdateVideoGamesBatchAfterSynchronizationCommand : IRequest<IEnumerable<VideoGame>>
    {
        public IEnumerable<VideoGameToSynchronizeResponseDto> VideoGamesToUpdate { get; }

        public UpdateVideoGamesBatchAfterSynchronizationCommand(IEnumerable<VideoGameToSynchronizeResponseDto> videoGamesToUpdate)
        {
            VideoGamesToUpdate = videoGamesToUpdate;
        }
    }
}