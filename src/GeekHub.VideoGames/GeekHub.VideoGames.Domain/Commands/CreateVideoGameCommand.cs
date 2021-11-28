using System;
using GeekHub.VideoGames.Domain.Dtos;
using MediatR;

namespace GeekHub.VideoGames.Domain.Commands
{
    public class CreateVideoGameCommand : IRequest<VideoGameResponseDto>
    {
        public CreateVideoGameRequestDto RequestDto { get; }

        public CreateVideoGameCommand(CreateVideoGameRequestDto requestDto)
        {
            RequestDto = requestDto;
        }
    }
}