using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;

namespace GeekHub.SteamProvider.Domain.ExternalConsumers
{
    public interface IExternalVideoGamesConsumer
    {
        Task<IEnumerable<VideoGameToSynchronizeResponseDto>> SynchronizeVideoGames(IEnumerable<VideoGameToSynchronizeRequestDto> requestDtos);
    }
}