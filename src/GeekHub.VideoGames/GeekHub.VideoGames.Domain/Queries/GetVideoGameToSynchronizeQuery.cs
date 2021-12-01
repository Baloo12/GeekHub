using System.Collections.Generic;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.Entities;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries
{
    public class GetVideoGameToSynchronizeQuery : IRequest<VideoGame>
    {
        public VideoGameToSynchronizeRequestDto RequestDto { get; }

        public GetVideoGameToSynchronizeQuery(VideoGameToSynchronizeRequestDto requestDto)
        {
            RequestDto = requestDto;
        }
    }
}