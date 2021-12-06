using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Queries.Handlers.VideoGames;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.VideoGames
{
    public class QueryAllVideoGamesSteamIdsHandlerTests
    {
        public class Handle
        {
            private readonly QueryAllVideoGamesSteamIdsHandler _handler;
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IVideoGamesRepository>();

                _handler = new QueryAllVideoGamesSteamIdsHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldReturnAllVideoGamesSteamIds()
            {
                //Arrange
                var request = new QueryAllVideoGamesSteamIds();
                var ids = new List<string>();
                
                _repository.Setup(r => r.GetAllSteamIdsAsync()).ReturnsAsync(ids);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(ids);
            }
        }
    }
}