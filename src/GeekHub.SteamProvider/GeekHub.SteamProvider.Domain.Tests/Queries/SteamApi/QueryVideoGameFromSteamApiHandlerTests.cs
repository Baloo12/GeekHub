using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.HttpClients;
using GeekHub.SteamProvider.Domain.Models.Internal;
using GeekHub.SteamProvider.Domain.Queries.Handlers.SteamApi;
using GeekHub.SteamProvider.Domain.Queries.SteamApi;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.SteamApi
{
    public class QueryVideoGameFromSteamApiHandlerTests
    {
        public class Handle
        {
            private readonly QueryVideoGameDetailsFromSteamApiHandler _handler;
            private readonly Mock<ISteamStoreClient> _steamClient;

            public Handle()
            {
                _steamClient = new Mock<ISteamStoreClient>();
                _handler = new QueryVideoGameDetailsFromSteamApiHandler(_steamClient.Object);
            }

            [Fact]
            public async Task ShouldReturnVideoGameDetailsBySteamId_IfSuccessField_IsTrue()
            {
                //Arrange
                var steamId = "123";
                var request = new QueryVideoGameDetailsFromSteamApi(steamId);
                var steamGameDetails = new SteamGameDetails()
                {
                    Success = true
                };
                _steamClient.Setup(r => r.GetGameDetails(steamId)).ReturnsAsync(steamGameDetails);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(steamGameDetails);
            }
            
            [Fact]
            public async Task ShouldReturnNull_IfSuccessField_IsFalse()
            {
                //Arrange
                var steamId = "123";
                var request = new QueryVideoGameDetailsFromSteamApi(steamId);
                var steamGameDetails = new SteamGameDetails()
                {
                    Success = false
                };
                _steamClient.Setup(r => r.GetGameDetails(steamId)).ReturnsAsync(steamGameDetails);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeNull();
            }
            
            [Fact]
            public async Task ShouldReturnNull_IfSuccessField_IsNull()
            {
                //Arrange
                var steamId = "123";
                var request = new QueryVideoGameDetailsFromSteamApi(steamId);
                var steamGameDetails = new SteamGameDetails();
                _steamClient.Setup(r => r.GetGameDetails(steamId)).ReturnsAsync(steamGameDetails);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeNull();
            }
        }
    }
}