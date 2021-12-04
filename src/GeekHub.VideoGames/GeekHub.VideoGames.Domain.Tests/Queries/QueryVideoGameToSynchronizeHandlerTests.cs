using System;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.Entities;
using GeekHub.VideoGames.Domain.Interfaces;
using GeekHub.VideoGames.Domain.Queries;
using GeekHub.VideoGames.Domain.Queries.Handlers;
using Moq;
using Xunit;

namespace GeekHub.VideoGames.Domain.Tests.Queries
{
    public class QueryVideoGameToSynchronizeHandlerTests
    {
        public class Handle
        {
            private readonly QueryVideoGameToSynchronizeHandler _handler;
            
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IVideoGamesRepository>();
                _handler = new QueryVideoGameToSynchronizeHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldReturn_VideoGameFromRepository_ByRequestDtoName()
            {
                //Arrange
                var unsynchronizedVideoGame = new UnsynchronizedVideoGameDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "TestVideoGame"
                };
                var request = new QueryVideoGameToSynchronize(unsynchronizedVideoGame);
                var entity = new VideoGame();
                
                _repository
                    .Setup(r => r.GetByNameAsync(unsynchronizedVideoGame.Name))
                    .ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
        }
    }
}