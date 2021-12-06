using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.HttpClients;
using GeekHub.SteamProvider.Domain.Models.Internal;
using GeekHub.SteamProvider.Domain.Queries.Handlers.SteamApi;
using GeekHub.SteamProvider.Domain.Queries.SteamApi;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.SteamApi
{
    public class QueryAllVideoGamesBaseInfoFromSteamApiHandlerTests
    {
        public class Handle
        {
            private readonly QueryAllVideoGamesBaseInfoFromSteamApiHandler _handler;
            private readonly Mock<ISteamApiClient> _steamClient;

            public Handle()
            {
                _steamClient = new Mock<ISteamApiClient>();
                _handler = new QueryAllVideoGamesBaseInfoFromSteamApiHandler(_steamClient.Object);
            }

            [Fact]
            public async Task ShouldReturnVideoGamesBaseInfo()
            {
                //Arrange
                var request = new QueryAllVideoGamesBaseInfoFromSteamApi();
                var steamGames = new SteamGames()
                {
                    AppList = new AppList()
                    {
                        Apps = new List<App>()
                        {
                            new App()
                            {
                                AppId = 1,
                                Name = "game_1"
                            },
                            new App()
                            {
                                AppId = 2,
                                Name = "game_2"
                            },
                        }
                    }
                };
                var expectedVideoGames = new List<VideoGame>()
                {
                    new VideoGame()
                    {
                        SteamId = "1",
                        Name = "game_1"
                    },
                    new VideoGame()
                    {
                        SteamId = "2",
                        Name = "game_2"
                    },
                };
                _steamClient.Setup(r => r.GetAllGames()).ReturnsAsync(steamGames);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(expectedVideoGames);
            }
        }
    }
}