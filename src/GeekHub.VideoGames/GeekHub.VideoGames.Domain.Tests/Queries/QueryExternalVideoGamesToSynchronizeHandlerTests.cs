using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.ExternalProviders;
using GeekHub.VideoGames.Domain.Interfaces;
using GeekHub.VideoGames.Domain.Queries;
using GeekHub.VideoGames.Domain.Queries.Handlers;
using Moq;
using Xunit;

namespace GeekHub.VideoGames.Domain.Tests.Queries
{
    public class QueryExternalVideoGamesToSynchronizeHandlerTests
    {
        public class Handle
        {
            private readonly QueryExternalVideoGamesToSynchronizeHandler _handler;
            
            private readonly Mock<IExternalVideoGamesProvidersFactory> _providerFactory;
            private readonly Mock<IExternalVideoGamesProvider> _provider;

            public Handle()
            {
                _providerFactory = new Mock<IExternalVideoGamesProvidersFactory>();
                _provider = new Mock<IExternalVideoGamesProvider>(); 
                
                _handler = new QueryExternalVideoGamesToSynchronizeHandler(_providerFactory.Object);
            }

            [Fact]
            public async Task ShouldReturn_UnsynchronizedVideoGames_OfResolvedProvider()
            {
                //Arrange
                var providerName = "TestProvider";
                var count = 100;
                var request = new QueryExternalVideoGamesToSynchronize(providerName, count);
                var expectedResult = new List<UnsynchronizedVideoGameDto>();
                
                _providerFactory
                    .Setup(r => r.ResolveProvider(providerName))
                    .Returns(_provider.Object);

                _provider
                    .Setup(p => p.GetUnsynchronizedAsync(count))
                    .ReturnsAsync(expectedResult);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(expectedResult);
            }
        }
    }
}