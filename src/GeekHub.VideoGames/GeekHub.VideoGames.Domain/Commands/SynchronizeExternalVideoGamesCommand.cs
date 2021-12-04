using System.Collections.Generic;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.Dtos;
using MediatR;

namespace GeekHub.VideoGames.Domain.Commands
{
    public class SynchronizeExternalVideoGamesCommand : IRequest<Unit>
    {
        public string Provider { get; }
        public IEnumerable<SynchronizedVideoGameDto> VideoGameToSynchronize { get; }

        public SynchronizeExternalVideoGamesCommand(string provider, IEnumerable<SynchronizedVideoGameDto> videoGameToSynchronize)
        {
            Provider = provider;
            VideoGameToSynchronize = videoGameToSynchronize;
        }
    }
}