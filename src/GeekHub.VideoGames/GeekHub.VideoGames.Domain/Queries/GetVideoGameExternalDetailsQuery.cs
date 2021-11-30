using System;
using System.Collections.Generic;
using GeekHub.VideoGames.Domain.Dtos;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries
{
    public class GetVideoGameExternalDetailsQuery : IRequest<VideoGameResponseDto>
    {
        public string ExternalId { get; }
        
        public string ExternalSource { get; }

        public GetVideoGameExternalDetailsQuery(string externalId, string externalSource)
        {
            ExternalId = externalId;
            ExternalSource = externalSource;
        }
    }
}