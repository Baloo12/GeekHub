using System.Collections.Generic;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries
{
    public class GetAllVideoGamesQuery : IRequest<IEnumerable<VideoGameToSynchronizeRequestDto>>
    {
    }
}