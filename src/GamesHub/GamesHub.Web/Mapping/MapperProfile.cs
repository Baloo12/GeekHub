namespace GamesHub.Web.Mapping
{
    using AutoMapper;

    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.Web.Models;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Game, GameModel>().ReverseMap();
            CreateMap<Game, TopGamesEntry>()
                .ForMember(x => x.OverallRank, o => o.MapFrom(x => x.Rank.Overall))
                .ReverseMap();
        }
    }
}