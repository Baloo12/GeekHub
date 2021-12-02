using System.Collections.Generic;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries
{
    public class ExternalVideoGamesToSynchronizeQuery : IRequest<IEnumerable<UnsynchronizedVideoGameDto>>
    {
        public string Provider { get; }
        public int Count { get; }

        public ExternalVideoGamesToSynchronizeQuery(string provider, int count)
        {
            Provider = provider;
            Count = count;
        }
    }
}