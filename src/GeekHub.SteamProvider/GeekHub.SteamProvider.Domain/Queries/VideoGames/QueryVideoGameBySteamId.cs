using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.VideoGames
{
    public class QueryVideoGameBySteamId : IRequest<VideoGame>
    {
        public string SteamId { get; }

        public QueryVideoGameBySteamId(string steamId)
        {
            SteamId = steamId;
        }
    }
}