using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.Entities;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries
{
    public class QueryVideoGameToSynchronize : IRequest<VideoGame>
    {
        public UnsynchronizedVideoGameDto VideoGameToSynchronize { get; }

        public QueryVideoGameToSynchronize(UnsynchronizedVideoGameDto videoGameToSynchronize)
        {
            VideoGameToSynchronize = videoGameToSynchronize;
        }
    }
}