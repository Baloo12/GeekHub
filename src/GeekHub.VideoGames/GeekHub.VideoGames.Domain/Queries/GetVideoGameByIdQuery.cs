using System;
using System.Collections.Generic;
using GeekHub.VideoGames.Domain.Dtos;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries
{
    public class GetVideoGameByIdQuery : IRequest<VideoGameResponseDto>
    {
        public Guid Id { get; }

        public GetVideoGameByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}