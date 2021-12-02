using System.Collections.Generic;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries
{
    public class UnsynchronizedVideoGamesQuery : IRequest<IEnumerable<UnsynchronizedVideoGameDto>>
    {
        public int Count { get; }

        public UnsynchronizedVideoGamesQuery(int count)
        {
            Count = count;
        }
    }
}