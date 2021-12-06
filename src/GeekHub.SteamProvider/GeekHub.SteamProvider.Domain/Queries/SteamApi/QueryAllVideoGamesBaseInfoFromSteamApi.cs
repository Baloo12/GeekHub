using System.Collections.Generic;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Models.Internal;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.SteamApi
{
    public class QueryAllVideoGamesBaseInfoFromSteamApi : IRequest<IEnumerable<VideoGame>>
    {
    }
}