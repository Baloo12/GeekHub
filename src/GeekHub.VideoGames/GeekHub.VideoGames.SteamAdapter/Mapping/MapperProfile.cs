using AutoMapper;
using ClientVideoGameDto = GeekHub.SteamProvider.Client.VideoGameDto;
using VideoGameDto = GeekHub.VideoGames.Contracts.Dtos.Steam.VideoGameDto;
using ClientGenreDto = GeekHub.SteamProvider.Client.GenreDto;
using GenreDto = GeekHub.VideoGames.Contracts.Dtos.Steam.GenreDto;
using ClientDeveloperDto = GeekHub.SteamProvider.Client.DeveloperDto;
using DeveloperDto = GeekHub.VideoGames.Contracts.Dtos.Steam.DeveloperDto;
using ClientPublisherDto = GeekHub.SteamProvider.Client.PublisherDto;
using PublisherDto = GeekHub.VideoGames.Contracts.Dtos.Steam.PublisherDto;
using ClientPlatformDto = GeekHub.SteamProvider.Client.PlatformDto;
using PlatformDto = GeekHub.VideoGames.Contracts.Dtos.Steam.PlatformDto;

namespace GeekHub.VideoGames.SteamAdapter.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClientVideoGameDto, VideoGameDto>();
            CreateMap<ClientGenreDto, GenreDto>();
            CreateMap<ClientDeveloperDto, DeveloperDto>();
            CreateMap<ClientPublisherDto, PublisherDto>();
            CreateMap<ClientPlatformDto, PlatformDto>();
        }
    }
}