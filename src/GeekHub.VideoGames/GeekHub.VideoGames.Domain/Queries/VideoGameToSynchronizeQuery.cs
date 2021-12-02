using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.Entities;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries
{
    public class VideoGameToSynchronizeQuery : IRequest<VideoGame>
    {
        public UnsynchronizedVideoGameDto VideoGameToSynchronize { get; }

        public VideoGameToSynchronizeQuery(UnsynchronizedVideoGameDto videoGameToSynchronize)
        {
            VideoGameToSynchronize = videoGameToSynchronize;
        }
    }
}