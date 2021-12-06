using System.Collections.Generic;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries
{
    public class QueryExternalVideoGamesToSynchronize : IRequest<IEnumerable<UnsynchronizedVideoGameDto>>
    {
        public string Provider { get; }
        public int Count { get; }

        public QueryExternalVideoGamesToSynchronize(string provider, int count)
        {
            Provider = provider;
            Count = count;
        }
    }
}