using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Genres;
using GeekHub.SteamProvider.Domain.Commands.Handlers.Genres;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Commands.Genres
{
    public class CreateGenreCommandHandlerTests
    {
        public class Handle
        {
            private readonly CreateGenreCommandHandler _handler;
            private readonly Mock<IGenresRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IGenresRepository>();

                _handler = new CreateGenreCommandHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldCreateGenre_FromRequest()
            {
                //Arrange
                var name = "name";
                var request = new CreateGenreCommand(name);
                
                _repository
                    .Setup(r => r.CreateAsync(It.Is<Genre>(d => d.Name == name)));
                
                //Act
                await _handler.Handle(request);

                //Assert
                _repository.Verify(r => r.CreateAsync(It.Is<Genre>(d => d.Name == name)), Times.Once);
            }
            
            [Fact]
            public async Task ShouldCallRepositorySaveChangesAsync()
            {
                //Arrange
                var name = "name";
                var request = new CreateGenreCommand(name);
                
                _repository
                    .Setup(r => r.CreateAsync(It.Is<Genre>(d => d.Name == name)));
                
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