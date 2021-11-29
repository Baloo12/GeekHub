using System;
using System.Collections.Generic;
using AutoMapper;
using GeekHub.VideoGames.Domain.Entities;
using GeekHub.VideoGames.Domain.Interfaces;
using GeekHub.VideoGames.Domain.Mapping;
using Moq;

namespace GeekHub.VideoGames.Domain.Tests.TestUtils
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