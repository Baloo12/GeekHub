using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.SteamProvider.Domain.ExternalConsumers;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Handlers
{
    public class SynchronizeVideoGamesBatchCommandHandler : IRequestHandler<SynchronizeVideoGamesBatchCommand, IEnumerable<VideoGameToSynchronizeResponseDto>>
    {
        private readonly IExternalVideoGamesConsumer _externalVideoGamesConsumer;

        public SynchronizeVideoGamesBatchCommandHandler(IExternalVideoGamesConsumer externalVideoGamesConsumer)
        {
            _externalVideoGamesConsumer = externalVideoGamesConsumer;
        }
        
        public async Task<IEnumerable<VideoGameToSynchronizeResponseDto>> Handle(
            SynchronizeVideoGamesBatchCommand request,
            CancellationToken cancellationToken = default)
        {
            var synchronizedGames = await _externalVideoGamesConsumer.SynchronizeVideoGames(request.RequestDtos);

            return synchronizedGames;
        }
    }
}