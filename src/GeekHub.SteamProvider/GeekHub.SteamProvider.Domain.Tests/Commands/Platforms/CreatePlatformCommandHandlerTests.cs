using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Platforms;
using GeekHub.SteamProvider.Domain.Commands.Handlers.Platforms;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Commands.Platforms
{
    public class CreatePlatformCommandHandlerTests
    {
        public class Handle
        {
            private readonly CreatePlatformCommandHandler _handler;
            private readonly Mock<IPlatformsRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IPlatformsRepository>();

                _handler = new CreatePlatformCommandHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldCreatePlatform_FromRequest()
            {
                //Arrange
                var name = "name";
                var request = new CreatePlatformCommand(name);
                
                _repository
                    .Setup(r => r.CreateAsync(It.Is<Platform>(d => d.Name == name)));
                
                //Act
                await _handler.Handle(request);

                //Assert
                _repository.Verify(r => r.CreateAsync(It.Is<Platform>(d => d.Name == name)), Times.Once);
            }
            
            [Fact]
            public async Task ShouldCallRepositorySaveChangesAsync()
            {
                //Arrange
                var name = "name";
                var request = new CreatePlatformCommand(name);
                
                _repository
                    .Setup(r => r.CreateAsync(It.Is<Platform>(d => d.Name == name)));
                
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