using System;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.VideoGames.Domain.Commands;
using GeekHub.VideoGames.Domain.Commands.Handlers;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.Entities;
using GeekHub.VideoGames.Domain.Interfaces;
using GeekHub.VideoGames.Domain.Queries;
using GeekHub.VideoGames.Domain.Queries.Handlers;
using GeekHub.VideoGames.Domain.Tests.TestUtils;
using Moq;
using Xunit;

namespace GeekHub.VideoGames.Domain.Tests.Commands
{
    public class CreateVideoGameCommandHandlerTests
    {
        public class Handle
        {
            private const string VideoGameName = "TestVideoGame";
            private readonly Guid _videoGameId = Guid.Parse("E06D8307-4F1E-40EC-BD2B-6EDBA45EC69C");
            
            private readonly CreateVideoGameCommandHandler _handler;
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                var mapper = TestInitializer.ConfigureMapper();
                _repository = new Mock<IVideoGamesRepository>();

                _handler = new CreateVideoGameCommandHandler(_repository.Object, mapper);
            }

            [Fact]
            public async Task ShouldCreateVideoGame()
            {
                //Arrange
                var game = new CreateVideoGameRequestDto 
                {
                    Name = VideoGameName
                };
                
                var createdGame = new VideoGame()
                {
                    Id = _videoGameId,
                    Name = VideoGameName
                };
                
                _repository
                    .Setup(r => r.CreateAsync(It.Is<VideoGame>(g => g.Name == game.Name)))
                    .ReturnsAsync(createdGame);
                _repository.Setup(r => r.SaveChangesAsync());

                var request = new CreateVideoGameCommand(game);
                var expectedResult = new VideoGameResponseDto()
                {
                    Id = _videoGameId,
                    Name = VideoGameName
                };
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(expectedResult);
            }
            
            [Fact]
            public async Task ShouldCallOnce_RepositoryCreateAsync_WithMapperRequestData()
            {
                //Arrange
                var game = new CreateVideoGameRequestDto 
                {
                    Name = VideoGameName
                };
                
                _repository.Setup(r => r.CreateAsync(It.Is<VideoGame>(g => g.Name == game.Name)));
                _repository.Setup(r => r.SaveChangesAsync());
                
                var request = new CreateVideoGameCommand(game);
                
                //Act
                await _handler.Handle(request);

                //Assert
                _repository.Verify(
                    r => r.CreateAsync(It.Is<VideoGame>(g => g.Name == game.Name)),
                    Times.Once);
            }
            
            [Fact]
            public async Task ShouldCallOnce_RepositorySaveChangesAsync()
            {
                //Arrange
                var game = new CreateVideoGameRequestDto 
                {
                    Name = VideoGameName
                };
                
                _repository.Setup(r => r.CreateAsync(It.Is<VideoGame>(g => g.Name == game.Name)));
                _repository.Setup(r => r.SaveChangesAsync());
                
                var request = new CreateVideoGameCommand(game);
                
                //Act
                await _handler.Handle(request);

                //Assert
                _repository.Verify(r => r.SaveChangesAsync(), Times.Once);
            }
        }
    }
}