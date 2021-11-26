namespace GeekHub.BoardGames.BggProvider.Web.Mapping
{
    using AutoMapper;

    using GeekHub.BoardGames.BggProvider.Domain.Entities;
    using GeekHub.BoardGames.BggProvider.Web.Models;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BoardGame, BoardGameModel>().ReverseMap();
        }
    }
}
