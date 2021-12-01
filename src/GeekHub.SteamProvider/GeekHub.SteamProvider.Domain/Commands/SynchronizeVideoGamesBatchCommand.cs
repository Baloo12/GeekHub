using System.Collections.Generic;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands
{
    public class SynchronizeVideoGamesBatchCommand : IRequest<IEnumerable<VideoGameToSynchronizeResponseDto>>
    {
        public IEnumerable<VideoGameToSynchronizeRequestDto> RequestDtos { get; }

        public SynchronizeVideoGamesBatchCommand(IEnumerable<VideoGameToSynchronizeRequestDto> requestDtos)
        {
            RequestDtos = requestDtos;
        }
    }
}