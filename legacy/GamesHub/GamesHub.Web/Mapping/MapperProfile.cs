namespace GamesHub.Web.Mapping
{
    using AutoMapper;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.Web.Models;
    using System.Linq;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Game, GameModel>()
                .ForMember(x => x.Developers, o => o.MapFrom(x => x.GameDevelopers.Select(gd => gd.Developer)))
                .ReverseMap();
            CreateMap<Developer, DeveloperModel>()
                .ForMember(x => x.Games, o => o.MapFrom(x => x.GameDevelopers.Select(gd => gd.Game)))
                .ReverseMap();
            CreateMap<Game, TopGamesEntry>()
                .ForMember(x => x.OverallRank, o => o.MapFrom(x => x.Rank.Overall))
                .ReverseMap()
                .ForMember(x => x.SteamAppId, o => o.Ignore());
            CreateMap<Game, GameOverviewModel>()
                .ForMember(x => x.OverallRank, o => o.MapFrom(x => x.Rank.Overall))
                .ReverseMap()
                .ForMember(x => x.SteamAppId, o => o.Ignore());
        }
    }
}