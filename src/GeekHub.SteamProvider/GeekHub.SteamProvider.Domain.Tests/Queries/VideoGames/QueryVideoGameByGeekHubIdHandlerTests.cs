using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Handlers.VideoGames;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using GeekHub.SteamProvider.Domain.Tests.TestUtils;
using GeekHub.VideoGames.Contracts.Dtos.Steam;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.VideoGames
{
    public class QueryVideoGameByGeekHubIdHandlerTests
    {
        public class Handle
        {
            private readonly QueryVideoGameByGeekHubIdHandler _handler;
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IVideoGamesRepository>();
                var mapper = TestInitializer.ConfigureMapper();

                _handler = new QueryVideoGameByGeekHubIdHandler(_repository.Object, mapper);
            }

            [Fact]
            public async Task ShouldReturnVideoGameByGeekHubId()
            {
                //Arrange
                var geekHubId = Guid.NewGuid();
                var request = new QueryVideoGameByGeekHubId(geekHubId);
                var entity = new VideoGame
                {
                    Name = "TestVideoGame"
                };
                var expectedDto = new VideoGameDto
                {
                    Name = "TestVideoGame",
                    Developers = new List<DeveloperDto>(),
                    Genres = new List<GenreDto>(),
                    Platforms = new List<PlatformDto>(),
                    Publishers = new List<PublisherDto>()
                };
                
                _repository.Setup(r => r.GetByGeekHubIdAsync(geekHubId)).ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(expectedDto);
            }
            
            [Fact]
            public async Task ShouldReturnNull_IfVideoGameMissed()
            {
                //Arrange
                var geekHubId = Guid.NewGuid();
                var request = new QueryVideoGameByGeekHubId(geekHubId);

                _repository.Setup(r => r.GetByGeekHubIdAsync(geekHubId));
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeNull();
            }
        }
    }
}