using AutoMapper;

namespace GamesHub.DataAccess.EntityFramework.Mapping
{
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.EntityFramework.Entities;

    public class MappingBuidler
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(Register);

            mapperConfiguration.AssertConfigurationIsValid();
            mapperConfiguration.CompileMappings();

            return mapperConfiguration.CreateMapper();
        }

        private static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Game, GameEntity>().ReverseMap();
        }
    }
}