using System;
using AutoMapper;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.VideoGames.Contracts.Dtos.Steam;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;

namespace GeekHub.SteamProvider.Domain.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VideoGame, UnsynchronizedVideoGameDto>(MemberList.Destination);
            
            CreateMap<VideoGame, VideoGameDto>()
                .ForMember(
                    dest => dest.ExternalId,
                    opt => opt.MapFrom(src => src.SteamId))
                .ForMember(
                    dest => dest.ReleaseDate,
                    opt => opt.MapFrom(src => new DateTime()));//persistedVideoGame.ReleaseDate
            
            CreateMap<Developer, DeveloperDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Publisher, PublisherDto>();
            CreateMap<Platform, PlatformDto>();
        }
    }
}