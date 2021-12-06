using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Developers;
using GeekHub.SteamProvider.Domain.Queries.Handlers.Developers;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.Developers
{
    public class QueryDeveloperByNameHandlerTests
    {
        public class Handle
        {
            private readonly QueryDeveloperByNameHandler _handler;
            private readonly Mock<IDevelopersRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IDevelopersRepository>();

                _handler = new QueryDeveloperByNameHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldReturnDeveloper_FromRepository_ByName()
            {
                //Arrange
                var name = "test";
                var request = new QueryDeveloperByName(name);
                var entity = new Developer();
                
                _repository.Setup(r => r.GetByName(name)).ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
        }
    }
}