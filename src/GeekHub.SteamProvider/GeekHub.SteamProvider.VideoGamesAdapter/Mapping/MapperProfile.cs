using AutoMapper;
using VideoGameToSynchronizeRequestDto = GeekHub.VideoGames.Contracts.Dtos.Synchronization.VideoGameToSynchronizeRequestDto;
using ClientVideoGameToSynchronizeRequestDto = GeekHub.VideoGames.Web.Client.VideoGameToSynchronizeRequestDto;
using VideoGameToSynchronizeResponseDto = GeekHub.VideoGames.Contracts.Dtos.Synchronization.VideoGameToSynchronizeResponseDto;
using ClientVideoGameToSynchronizeResponseDto = GeekHub.VideoGames.Web.Client.VideoGameToSynchronizeResponseDto;

namespace GeekHub.SteamProvider.VideoGamesAdapter.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VideoGameToSynchronizeRequestDto, ClientVideoGameToSynchronizeRequestDto>();
            CreateMap<ClientVideoGameToSynchronizeResponseDto, VideoGameToSynchronizeResponseDto>();
        }
    }
}