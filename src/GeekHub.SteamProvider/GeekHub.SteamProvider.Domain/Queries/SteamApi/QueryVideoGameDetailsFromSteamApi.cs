using GeekHub.SteamProvider.Domain.Models.Internal;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.SteamApi
{
    public class QueryVideoGameDetailsFromSteamApi : IRequest<SteamGameDetails>
    {
        public string SteamId { get; }

        public QueryVideoGameDetailsFromSteamApi(string steamId)
        {
            SteamId = steamId;
        }
    }
}