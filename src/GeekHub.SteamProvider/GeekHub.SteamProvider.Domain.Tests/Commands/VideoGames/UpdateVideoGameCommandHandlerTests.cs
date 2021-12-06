using System;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Handlers.VideoGames;
using GeekHub.SteamProvider.Domain.Commands.VideoGames;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Commands.VideoGames
{
    public class UpdateVideoGameCommandHandlerTests
    {
        public class Handle
        {
            private readonly UpdateVideoGameCommandHandler _handler;
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IVideoGamesRepository>();

                _handler = new UpdateVideoGameCommandHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldUpdateVideoGame_FromRequest()
            {
                //Arrange
                var videoGameToUpdate = new VideoGame();
                var updated = new VideoGame()
                {
                    Id = Guid.NewGuid()
                };
                var request = new UpdateVideoGameCommand(videoGameToUpdate);
                
                _repository
                    .Setup(r => r.Update(videoGameToUpdate))
                    .Returns(updated);
                
                //Act
                await _handler.Handle(request);

                //Assert
                _repository.Verify(r => r.Update(videoGameToUpdate), Times.Once);
            }
            
            [Fact]
            public async Task ShouldCallRepositorySaveChangesAsync()
            {
                //Arrange
                var videoGameToUpdate = new VideoGame();
                var updated = new VideoGame()
                {
                    Id = Guid.NewGuid()
                };
                var request = new UpdateVideoGameCommand(videoGameToUpdate);
                
                _repository
                    .Setup(r => r.Update(videoGameToUpdate))
                    .Returns(updated);
                
                _repository
                    .Setup(r => r.SaveChangesAsync());
                
                //Act
                await _handler.Handle(request);

                //Assert
                _repository.Verify(r => r.SaveChangesAsync(), Times.Once);
            }
        }
    }
}