using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Handlers.VideoGames;
using GeekHub.SteamProvider.Domain.Commands.VideoGames;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Exceptions;
using GeekHub.SteamProvider.Domain.Models.Internal;
using GeekHub.SteamProvider.Domain.Queries.Developers;
using GeekHub.SteamProvider.Domain.Queries.SteamApi;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using GeekHub.SteamProvider.Domain.Tests.TestUtils;
using GeekHub.SteamProvider.Domain.Utils;
using MediatR;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Commands.VideoGames
{
    public class EnrichVideoGameWithDetailsCommandHandlerTests
    {
        public class Handle
        {
            private readonly EnrichVideoGameWithDetailsCommandHandler _handler;
            private readonly Mock<IMediator> _mediator;
            private readonly Mock<IVideoGameEntityBuilderFactory> _factory;

            public Handle()
            {
                _mediator = new Mock<IMediator>();
                _factory = new Mock<IVideoGameEntityBuilderFactory>();
                _factory
                    .Setup(f => f.GetVideoGameEntityBuilder(It.IsAny<VideoGame>()))
                    .Returns(new TestInitializer.TestVideoGameEntityBuilder());

                _handler = new EnrichVideoGameWithDetailsCommandHandler(_mediator.Object, _factory.Object);
            }
            
            [Fact]
            public async Task ShouldQueryVideoGameBySteamId()
            {
                //Arrange
                var steamId = "123";
                var request = new EnrichVideoGameWithDetailsCommand(steamId);
                var game = new VideoGame();
                var details = new SteamGameDetails();
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryVideoGameBySteamId>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(game);
                
                _mediator
                    .Setup(r => r.Send(
                        It.IsAny<QueryVideoGameDetailsFromSteamApi>(),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(details);
                
                //Act
                await _handler.Handle(request);
                
                //Assert
                _mediator.Verify(
                    m => m.Send(
                        It.Is<QueryVideoGameBySteamId>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()),
                    Times.Once);
            }

            [Fact]
            public async Task ShouldThrowVideoGameNotExistsException_IfQueryVideoGameBySteamId_ReturnsNull()
            {
                //Arrange
                var steamId = "123";
                var request = new EnrichVideoGameWithDetailsCommand(steamId);
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryVideoGameBySteamId>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()));
                
                // Act & Assert
                await Assert.ThrowsAsync<VideoGameNotExistsException>(async () => await _handler.Handle(request));
            }
            
            [Fact]
            public async Task ShouldQueryVideoGameDetailsFromSteamApi()
            {
                //Arrange
                var steamId = "123";
                var request = new EnrichVideoGameWithDetailsCommand(steamId);
                var game = new VideoGame();
                var details = new SteamGameDetails();
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryVideoGameBySteamId>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(game);
                
                _mediator
                    .Setup(r => r.Send(
                        It.IsAny<QueryVideoGameDetailsFromSteamApi>(),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(details);
                
                //Act
                await _handler.Handle(request);
                
                //Assert
                _mediator.Verify(
                    m => m.Send(
                        It.Is<QueryVideoGameDetailsFromSteamApi>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()),
                    Times.Once);
            }
            
            [Fact]
            public async Task ShouldThrowVideoGameNotExistsInSteamException_IfQueryVideoGameDetailsFromSteamApi_ReturnsNull()
            {
                //Arrange
                var steamId = "123";
                var request = new EnrichVideoGameWithDetailsCommand(steamId);
                var game = new VideoGame();
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryVideoGameBySteamId>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(game);
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryVideoGameDetailsFromSteamApi>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()));
                
                // Act & Assert
                await Assert.ThrowsAsync<VideoGameNotExistsInSteamException>(async () => await _handler.Handle(request));
            }
            
            [Fact]
            public async Task ShouldQueryOrCreateDevelopers_ForCurrentVideoGame()
            {
                //Arrange
                var steamId = "123";
                var request = new EnrichVideoGameWithDetailsCommand(steamId);
                var game = new VideoGame();
                var details = new SteamGameDetails()
                {
                    Data = new GameDetailsData()
                    {
                        Developers = new List<string>()
                    }
                };
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryVideoGameBySteamId>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(game);
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryVideoGameDetailsFromSteamApi>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(details);
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryOrCreateDevelopersByNames>(q => Equals(q.Names, details.Data.Developers)),
                        It.IsAny<CancellationToken>()));
                
                //Act
                await _handler.Handle(request);
                
                //Assert
                _mediator.Verify(
                    m => m.Send(
                        It.Is<QueryOrCreateDevelopersByNames>(q => Equals(q.Names, details.Data.Developers)),
                        It.IsAny<CancellationToken>()),
                    Times.Once);
            }
            
            [Fact]
            public async Task ShouldUpdateVideoGameWithDetails()
            {
                //Arrange
                var steamId = "123";
                var request = new EnrichVideoGameWithDetailsCommand(steamId);
                var game = new VideoGame();
                var details = new SteamGameDetails()
                {
                    Data = new GameDetailsData()
                    {
                        Developers = new List<string>()
                    }
                };
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryVideoGameBySteamId>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(game);
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryVideoGameDetailsFromSteamApi>(q => q.SteamId == steamId),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(details);
                
                _mediator
                    .Setup(r => r.Send(
                        It.Is<QueryOrCreateDevelopersByNames>(q => Equals(q.Names, details.Data.Developers)),
                        It.IsAny<CancellationToken>()));
                
                _mediator
                    .Setup(r => r.Send(
                        It.IsAny<UpdateVideoGameCommand>(),
                        It.IsAny<CancellationToken>()));
                
                //Act
                await _handler.Handle(request);
                
                //Assert
                _mediator.Verify(
                    m => m.Send(
                        It.IsAny<UpdateVideoGameCommand>(),
                        It.IsAny<CancellationToken>()),
                    Times.Once);
            }
        }
    }
}