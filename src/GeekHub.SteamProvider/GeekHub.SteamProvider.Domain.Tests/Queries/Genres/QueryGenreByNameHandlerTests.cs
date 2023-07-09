using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Genres;
using GeekHub.SteamProvider.Domain.Queries.Handlers.Genres;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.Genres
{
    public class QueryGenreByNameHandlerTests
    {
        public class Handle
        {
            private readonly QueryGenreByNameHandler _handler;
            private readonly Mock<IGenresRepository> _repository;

            public Handle()
            {
                _repository = new Mock<IGenresRepository>();

                _handler = new QueryGenreByNameHandler(_repository.Object);
            }

            [Fact]
            public async Task ShouldReturnGenre_FromRepository_ByName()
            {
                //Arrange
                var name = "test";
                var request = new QueryGenreByName(name);
                var entity = new Genre();
                
                _repository.Setup(r => r.GetByName(name)).ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
        }
    }
}