using AutoMapper;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;

namespace GeekHub.SteamProvider.Domain.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VideoGame, VideoGameToSynchronizeRequestDto>(MemberList.Destination);
        }
    }
}