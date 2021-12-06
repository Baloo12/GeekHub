using System.Collections.Generic;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.VideoGames
{
    public class QueryAllVideoGamesSteamIds : IRequest<IEnumerable<string>>
    {
    }
}