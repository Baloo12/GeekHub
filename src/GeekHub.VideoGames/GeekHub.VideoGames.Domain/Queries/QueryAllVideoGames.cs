using System.Collections.Generic;
using GeekHub.VideoGames.Domain.Dtos;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries
{
    public class QueryAllVideoGames : IRequest<IEnumerable<VideoGameResponseDto>>
    {
    }
}