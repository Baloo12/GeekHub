﻿using AutoMapper;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.Entities;

namespace GeekHub.VideoGames.Domain.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VideoGame, VideoGameResponseDto>();
            CreateMap<CreateVideoGameRequestDto, VideoGame>();
        }
    }
}