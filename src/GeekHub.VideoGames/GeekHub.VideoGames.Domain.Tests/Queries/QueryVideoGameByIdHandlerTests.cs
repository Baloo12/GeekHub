using System;
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
    public class QueryVideoGameByIdHandlerTests
    {
        public class Handle
        {
            private readonly Guid _videoGameId = Guid.Parse("E06D8307-4F1E-40EC-BD2B-6EDBA45EC69C");
            
            private readonly QueryVideoGameByIdHandler _handler;
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                var entity = CreateRepositoryTestData();

                _repository = new Mock<IVideoGamesRepository>();
                _repository.Setup(r => r.GetAsync(_videoGameId)).ReturnsAsync(entity);

                var mapper = TestInitializer.ConfigureMapper();

                _handler = new QueryVideoGameByIdHandler(_repository.Object, mapper);
            }

            [Fact]
            public async Task ShouldReturnVideoGameById()
            {
                //Arrange
                var request = new QueryVideoGameById(_videoGameId);
                var expectedResult = CreateExpectedResponse();
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(expectedResult);
            }
            
            private VideoGame CreateRepositoryTestData()
            {
                var result = new VideoGame()
                {
                    Id = _videoGameId,
                    Name = "TestVideoGame"
                };

                return result;
            }
            
            private VideoGameResponseDto CreateExpectedResponse()
            {
                var result = new VideoGameResponseDto()
                {
                    Id = _videoGameId,
                    Name = "TestVideoGame"
                };

                return result;
            }
        }
    }
}