using AutoMapper;
using GamesHub.DataAccess.Contracts.Models;
using GamesHub.Web.Models;

namespace GamesHub.Web.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Game, GameModel>().ReverseMap();
        }
    }
}
