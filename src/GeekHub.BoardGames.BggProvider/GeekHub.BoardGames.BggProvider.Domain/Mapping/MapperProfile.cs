namespace GeekHub.BoardGames.BggProvider.Domain.Mapping
{
    using AutoMapper;

    using GeekHub.BoardGames.BggProvider.Domain.Dtos;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BoardGame, BoardGameModel>().ReverseMap();
        }
    }
}
