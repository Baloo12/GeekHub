using System;
using GeekHub.VideoGames.Contracts.Dtos.Steam;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.VideoGames
{
    public class QueryVideoGameByGeekHubId : IRequest<VideoGameDto>
    {
        public Guid GeekHubId { get; }

        public QueryVideoGameByGeekHubId(Guid geekHubId)
        {
            GeekHubId = geekHubId;
        }
    }
}