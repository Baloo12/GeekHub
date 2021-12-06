using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.VideoGames
{
    public class EnrichVideoGameWithDetailsCommand : IRequest<VideoGame>
    {
        public string SteamId { get; }

        public EnrichVideoGameWithDetailsCommand(string steamId)
        {
            SteamId = steamId;
        }
    }
}