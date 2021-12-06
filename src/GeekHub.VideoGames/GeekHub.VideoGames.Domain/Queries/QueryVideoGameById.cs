using System;
using System.Collections.Generic;
using GeekHub.VideoGames.Domain.Dtos;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries
{
    public class QueryVideoGameById : IRequest<VideoGameResponseDto>
    {
        public Guid Id { get; }

        public QueryVideoGameById(Guid id)
        {
            Id = id;
        }
    }
}