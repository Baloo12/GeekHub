using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Platforms;
using GeekHub.SteamProvider.Domain.Queries.Handlers.Platforms;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.Platforms
{
    public class QueryPlatformByNameHandlerTests
    {
        public class Handle
        {
            private readonly QueryPlatformByNameHandler _handler;
            private readonly Mock<IPlatformsRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IPlatformsRepository>();

                _handler = new QueryPlatformByNameHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldReturnPlatform_FromRepository_ByName()
            {
                //Arrange
                var name = "test";
                var request = new QueryPlatformByName(name);
                var entity = new Platform();
                
                _repository.Setup(r => r.GetByName(name)).ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
        }
    }
}