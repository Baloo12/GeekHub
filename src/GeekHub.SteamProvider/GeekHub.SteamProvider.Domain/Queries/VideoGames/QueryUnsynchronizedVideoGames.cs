using System.Collections.Generic;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.VideoGames
{
    public class QueryUnsynchronizedVideoGames : IRequest<IEnumerable<UnsynchronizedVideoGameDto>>
    {
        public int Count { get; }

        public QueryUnsynchronizedVideoGames(int count)
        {
            Count = count;
        }
    }
}