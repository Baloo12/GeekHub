using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.Entities;
using GeekHub.VideoGames.Domain.Interfaces;
using GeekHub.VideoGames.Domain.Queries;
using GeekHub.VideoGames.Domain.Queries.Handlers;
using GeekHub.VideoGames.Domain.Tests.TestUtils;
using Moq;
using Xunit;

namespace GeekHub.VideoGames.Domain.Tests.Queries
{
    public class QueryAllVideoGamesHandlerTests
    {
        public class Handle
        {
            private readonly QueryAllVideoGamesHandler _handler;
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                var entities = CreateRepositoryTestData();

                _repository = new Mock<IVideoGamesRepository>();
                _repository.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);

                var mapper = TestInitializer.ConfigureMapper();

                _handler = new QueryAllVideoGamesHandler(_repository.Object, mapper);
            }

            [Fact]
            public async Task ShouldReturnAllVideoGames()
            {
                //Arrange
                var request = new QueryAllVideoGames();
                var expectedResult = CreateExpectedResponse();
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(expectedResult);
            }
            
            private IEnumerable<VideoGame> CreateRepositoryTestData()
            {
                var result = new List<VideoGame>()
                {
                    new VideoGame()
                    {
                        Id = Guid.Parse("E06D8307-4F1E-40EC-BD2B-6EDBA45EC69C"),
                        Name = "TestVideoGame"
                    }
                };

                return result;
            }
            
            private IEnumerable<VideoGameResponseDto> CreateExpectedResponse()
            {
                var result = new List<VideoGameResponseDto>()
                {
                    new VideoGameResponseDto()
                    {
                        Id = Guid.Parse("E06D8307-4F1E-40EC-BD2B-6EDBA45EC69C"),
                        Name = "TestVideoGame"
                    }
                };

                return result;
            }
        }
    }
}