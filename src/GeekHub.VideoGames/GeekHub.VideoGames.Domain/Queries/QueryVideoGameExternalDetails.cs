using System;
using GeekHub.VideoGames.Domain.Dtos;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries
{
    public class QueryVideoGameExternalDetails : IRequest<VideoGameResponseDto>
    {
        public Guid Id { get; }
        public string ExternalSource { get; }

        public QueryVideoGameExternalDetails(Guid id, string externalSource)
        {
            Id = id;
            ExternalSource = externalSource;
        }
    }
}