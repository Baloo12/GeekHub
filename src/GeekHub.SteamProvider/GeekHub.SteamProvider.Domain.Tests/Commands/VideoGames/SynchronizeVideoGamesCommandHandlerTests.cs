using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.Commands.Handlers.VideoGames;
using GeekHub.SteamProvider.Domain.Commands.VideoGames;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Commands.VideoGames
{
    public class SynchronizeVideoGamesCommandHandlerTests
    {
        public class Handle
        {
            private readonly SynchronizeVideoGamesCommandHandler _handler;
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IVideoGamesRepository>();

                _handler = new SynchronizeVideoGamesCommandHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldReturnVideoGames_EnrichedByGeekHubId_FromRequestDtos()
            {
                //Arrange
                var id = Guid.NewGuid();
                var geekHubId = Guid.NewGuid();
                
                var existingVideoGame = new VideoGame()
                {
                    Id = id
                };
                var videoGamesToUpdate = new List<SynchronizedVideoGameDto>()
                {
                    new SynchronizedVideoGameDto()
                    {
                        Id = id,
                        GeekHubId = geekHubId
                    }
                };
                
                var updatedVideoGame = new VideoGame()
                {
                    Id = id,
                    GeekHubId = geekHubId
                };
                var expectedResult = new List<VideoGame>()
                {
                    updatedVideoGame
                };
                var request = new SynchronizeVideoGamesCommand(videoGamesToUpdate);
                
                _repository
                    .Setup(r => r.GetAsync(id))
                    .ReturnsAsync(existingVideoGame);
                
                _repository
                    .Setup(r => r.Update(existingVideoGame))
                    .Returns(updatedVideoGame);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(expectedResult);
            }
            
            [Fact]
            public async Task ShouldCallSaveChangesAsync_Once()
            {
                //Arrange
                var videoGamesToUpdate = new List<SynchronizedVideoGameDto>();
                
                var request = new SynchronizeVideoGamesCommand(videoGamesToUpdate);
                
                _repository.Setup(r => r.SaveChangesAsync());
                
                //Act
                await _handler.Handle(request);

                //Assert
                _repository.Verify(r => r.SaveChangesAsync(), Times.Once);
            }
            
            [Fact]
            public async Task ShouldThrowException_IfGameMissedInRepository()
            {
                //Arrange
                var id = Guid.NewGuid();
                var geekHubId = Guid.NewGuid();
                
                var videoGamesToUpdate = new List<SynchronizedVideoGameDto>()
                {
                    new SynchronizedVideoGameDto()
                    {
                        Id = id,
                        GeekHubId = geekHubId
                    }
                };
                
                var request = new SynchronizeVideoGamesCommand(videoGamesToUpdate);
                
                _repository
                    .Setup(r => r.GetAsync(id));
                
                //Act & Assert
                await Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(request));
            }
        }
    }
}