using System;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.VideoGames.Contracts.Dtos.Steam;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.ExternalProviders;
using GeekHub.VideoGames.Domain.Interfaces;
using GeekHub.VideoGames.Domain.Queries;
using GeekHub.VideoGames.Domain.Queries.Handlers;
using GeekHub.VideoGames.Domain.Tests.TestUtils;
using Moq;
using Xunit;

namespace GeekHub.VideoGames.Domain.Tests.Queries
{
    public class QueryVideoGameExternalDetailsHandlerTests
    {
        public class Handle
        {
            private readonly QueryVideoGameExternalDetailsHandler _handler;
            
            private readonly Mock<IExternalVideoGamesProvidersFactory> _providerFactory;
            private readonly Mock<IExternalVideoGamesProvider> _provider;

            public Handle()
            {
                _providerFactory = new Mock<IExternalVideoGamesProvidersFactory>();
                _provider = new Mock<IExternalVideoGamesProvider>(); 
                
                var mapper = TestInitializer.ConfigureMapper();
                
                _handler = new QueryVideoGameExternalDetailsHandler(_providerFactory.Object, mapper);
            }

            [Fact]
            public async Task ShouldReturn_ExternalVideoGameDetails_OfResolvedProvider()
            {
                //Arrange
                var videoGameId = Guid.NewGuid();
                var providerName = "TestProvider";
                var request = new QueryVideoGameExternalDetails(videoGameId, providerName);
                var providerResult = new VideoGameDto()
                {
                    Name = "TestVideoGame"
                };
                var expectedResult = new VideoGameResponseDto()
                {
                    Name = "TestVideoGame"
                };
                
                _providerFactory
                    .Setup(r => r.ResolveProvider(providerName))
                    .Returns(_provider.Object);

                _provider
                    .Setup(p => p.GetDetailsAsync(videoGameId))
                    .ReturnsAsync(providerResult);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(expectedResult);
            }
        }
    }
}