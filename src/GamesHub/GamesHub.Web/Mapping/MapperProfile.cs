namespace GamesHub.Web.Mapping
{
    using AutoMapper;

    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.Web.Models;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Game, GameModel>().ReverseMap()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.Rating, o => o.Ignore())
                .ForMember(x => x.RankId, o => o.Ignore())
                .ForMember(x => x.Rank, o => o.Ignore())
                .ForMember(x => x.SteamAppId, o => o.Ignore())
                .ForMember(x => x.GameDevelopers, o => o.MapFrom(x => x.Developers))
                .AfterMap((model, entity) =>
                {
                    foreach (var entityGameDeveloper in entity.GameDevelopers)
                    {
                        entityGameDeveloper.Game = entity;
                    }
                });
            CreateMap<GameDeveloper, DeveloperModel>().ReverseMap()
                .ForMember(entity => entity.Developer, opt => opt.MapFrom(model => model));
            CreateMap<Developer, DeveloperModel>().ReverseMap();
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