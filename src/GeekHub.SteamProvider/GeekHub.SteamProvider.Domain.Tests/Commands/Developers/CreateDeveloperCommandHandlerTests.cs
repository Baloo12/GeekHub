using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Developers;
using GeekHub.SteamProvider.Domain.Commands.Handlers.Developers;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Commands.Developers
{
    public class CreateDeveloperCommandHandlerTests
    {
        public class Handle
        {
            private readonly CreateDeveloperCommandHandler _handler;
            private readonly Mock<IDevelopersRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IDevelopersRepository>();

                _handler = new CreateDeveloperCommandHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldCreateDeveloper_FromRequest()
            {
                //Arrange
                var name = "name";
                var request = new CreateDeveloperCommand(name);
                
                _repository
                    .Setup(r => r.CreateAsync(It.Is<Developer>(d => d.Name == name)));
                
                //Act
                await _handler.Handle(request);

                //Assert
                _repository.Verify(r => r.CreateAsync(It.Is<Developer>(d => d.Name == name)), Times.Once);
            }
            
            [Fact]
            public async Task ShouldCallRepositorySaveChangesAsync()
            {
                //Arrange
                var name = "name";
                var request = new CreateDeveloperCommand(name);
                
                _repository
                    .Setup(r => r.CreateAsync(It.Is<Developer>(d => d.Name == name)));
                
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