using AutoMapper;
using GeekHub.VideoGames.Domain.Entities;
using GeekHub.VideoGames.Web.Models;

namespace GeekHub.VideoGames.Web.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VideoGame, VideoGameModel>()
                .ReverseMap();
        }
    }
}