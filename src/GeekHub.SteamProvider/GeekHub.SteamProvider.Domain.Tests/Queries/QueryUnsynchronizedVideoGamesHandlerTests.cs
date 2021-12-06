using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries;
using GeekHub.SteamProvider.Domain.Queries.Handlers;
using GeekHub.SteamProvider.Domain.Tests.TestUtils;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries
{
    public class QueryUnsynchronizedVideoGamesHandlerTests
    {
        public class Handle
        {
            private readonly QueryUnsynchronizedVideoGamesHandler _handler;
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IVideoGamesRepository>();
                var mapper = TestInitializer.ConfigureMapper();

                _handler = new QueryUnsynchronizedVideoGamesHandler(_repository.Object, mapper);
            }

            [Fact]
            public async Task ShouldReturnVideoGames_WithEmptyGeekHubIds()
            {
                //Arrange
                var count = 100;
                var request = new QueryUnsynchronizedVideoGames(count);
                var entities = new List<VideoGame>();
                var resultDtos = new List<UnsynchronizedVideoGameDto>();
                
                _repository
                    .Setup(r => r.GetManyAsync(g => g.GeekHubId == Guid.Empty, count))
                    .ReturnsAsync(entities);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(resultDtos);
            }
        }
    }
}