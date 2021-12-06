using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.VideoGames
{
    public class UpdateVideoGameCommand : IRequest<VideoGame>
    {
        public VideoGame VideoGameToUpdate { get; }

        public UpdateVideoGameCommand(VideoGame videoGameToUpdate)
        {
            VideoGameToUpdate = videoGameToUpdate;
        }
    }
}