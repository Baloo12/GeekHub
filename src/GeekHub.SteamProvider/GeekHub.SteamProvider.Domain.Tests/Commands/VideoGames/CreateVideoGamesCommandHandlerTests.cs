using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Handlers.VideoGames;
using GeekHub.SteamProvider.Domain.Commands.VideoGames;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Commands.VideoGames
{
    public class CreateVideoGamesCommandHandlerTests
    {
        public class Handle
        {
            private readonly CreateVideoGamesCommandHandler _handler;
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IVideoGamesRepository>();

                _handler = new CreateVideoGamesCommandHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldAddRangeOfVideoGames_FromRequest()
            {
                //Arrange
                var videoGamesToCreate = new List<VideoGame>();
                var request = new CreateVideoGamesCommand(videoGamesToCreate);
                
                _repository
                    .Setup(r => r.CreateAsync(videoGamesToCreate));
                
                //Act
                await _handler.Handle(request);

                //Assert
                _repository.Verify(r => r.CreateAsync(videoGamesToCreate), Times.Once);
            }
            
            [Fact]
            public async Task ShouldCallRepositorySaveChangesAsync()
            {
                //Arrange
                var videoGamesToCreate = new List<VideoGame>();
                var request = new CreateVideoGamesCommand(videoGamesToCreate);
                
                _repository
                    .Setup(r => r.CreateAsync(videoGamesToCreate));
                
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