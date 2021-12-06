using System.Collections.Generic;
using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.VideoGames
{
    public class CreateVideoGamesCommand : IRequest
    {
        public IEnumerable<VideoGame> VideoGamesToCreate { get; }

        public CreateVideoGamesCommand(IEnumerable<VideoGame> videoGamesToCreate)
        {
            VideoGamesToCreate = videoGamesToCreate;
        }
    }
}