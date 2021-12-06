using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.Commands;
using GeekHub.VideoGames.Domain.Commands.Handlers;
using GeekHub.VideoGames.Domain.ExternalProviders;
using GeekHub.VideoGames.Domain.Interfaces;
using Moq;
using Xunit;

namespace GeekHub.VideoGames.Domain.Tests.Commands
{
    public class SynchronizeExternalVideoGamesCommandHandlerTests
    {
        public class Handle
        {
            private readonly SynchronizeExternalVideoGamesCommandHandler _handler;
            
            private readonly Mock<IExternalVideoGamesProvidersFactory> _providerFactory;
            private readonly Mock<IExternalVideoGamesProvider> _provider;

            public Handle()
            {
                _providerFactory = new Mock<IExternalVideoGamesProvidersFactory>();
                _provider = new Mock<IExternalVideoGamesProvider>(); 

                _handler = new SynchronizeExternalVideoGamesCommandHandler(_providerFactory.Object);
            }

            [Fact]
            public async Task ShouldSynchronizeVideoGame_WithExternalProvider()
            {
                //Arrange
                var providerName = "TestProvider";
                var videoGamesToSynchronize = new List<SynchronizedVideoGameDto>();
                
                _providerFactory
                    .Setup(r => r.ResolveProvider(providerName))
                    .Returns(_provider.Object);
                
                _provider
                    .Setup(p => p.SynchronizeAsync(videoGamesToSynchronize));

                var request = new SynchronizeExternalVideoGamesCommand(providerName, videoGamesToSynchronize);
                
                //Act
                await _handler.Handle(request);

                //Assert
                _provider.Verify(p => p.SynchronizeAsync(videoGamesToSynchronize), Times.Once);
            }
        }
    }
}