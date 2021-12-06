using System.Collections.Generic;
using AutoMapper;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Mapping;
using GeekHub.SteamProvider.Domain.Models.Internal;
using GeekHub.SteamProvider.Domain.Utils;
using Genre = GeekHub.SteamProvider.Domain.Entities.Genre;

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

        public class TestVideoGameEntityBuilder : IVideoGameEntityBuilder
        {
            public IVideoGameEntityBuilder WithDetails(GameDetailsData details)
            {
                return this;
            }

            public IVideoGameEntityBuilder WithSourceId(string steamId)
            {
                return this;
            }

            public IVideoGameEntityBuilder WithDevelopers(List<Developer> developers)
            {
                return this;
            }

            public IVideoGameEntityBuilder WithPublishers(List<Publisher> publishers)
            {
                return this;
            }

            public IVideoGameEntityBuilder WithGenres(List<Genre> genres)
            {
                return this;
            }

            public IVideoGameEntityBuilder WithPlatforms(List<Platform> platforms)
            {
                return this;
            }

            public VideoGame Build()
            {
                return null;
            }
        }
    }
}