using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Handlers.VideoGames;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.VideoGames
{
    public class QueryVideoGameBySteamIdHandlerTests
    {
        public class Handle
        {
            private readonly QueryVideoGameBySteamIdHandler _handler;
            private readonly Mock<IVideoGamesRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IVideoGamesRepository>();

                _handler = new QueryVideoGameBySteamIdHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldReturnVideoGameBySteamId()
            {
                //Arrange
                var steamId = "123";
                var request = new QueryVideoGameBySteamId(steamId);
                var entity = new VideoGame();
                
                _repository.Setup(r => r.GetBySteamIdAsync(steamId)).ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
            
            [Fact]
            public async Task ShouldReturnNull_IfVideoGameMissed()
            {
                //Arrange
                var steamId = "123";
                var request = new QueryVideoGameBySteamId(steamId);

                _repository.Setup(r => r.GetBySteamIdAsync(steamId));
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeNull();
            }
        }
    }
}