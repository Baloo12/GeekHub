using AutoMapper;
using GeekHub.SteamProvider.Domain.Mapping;

namespace GeekHub.SteamProvider.Domain.Tests.TestUtils
{
    public static class TestInitializer
    {
        public static IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            var mapper = config.CreateMapper();
            
            return mapper;
        }
    }
}