using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.Commands.Genres;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Genres;
using GeekHub.SteamProvider.Domain.Queries.Handlers.Genres;
using MediatR;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.Genres
{
    public class QueryOrCreateGenreByNameHandlerTests
    {
        public class Handle
        {
            private readonly QueryOrCreateGenreByNameHandler _handler;
            private readonly Mock<IMediator> _mediator;

            public Handle()
            {
                _mediator = new Mock<IMediator>();

                _handler = new QueryOrCreateGenreByNameHandler(_mediator.Object);
            }

            [Fact]
            public async Task ShouldCallQuery_AndReturn_GenreByName()
            {
                //Arrange
                var name = "test";
                var request = new QueryOrCreateGenreByName(name);
                var entity = new Genre();
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryGenreByName>(q => q.Name == name), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
            
            [Fact]
            public async Task ShouldCreateGenre_AndReturn_IfMissed()
            {
                //Arrange
                var name = "test";
                var request = new QueryOrCreateGenreByName(name);
                var entity = new Genre();
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryGenreByName>(q => q.Name == name), It.IsAny<CancellationToken>()));
                
                _mediator
                    .Setup(r => r.Send(It.Is<CreateGenreCommand>(q => q.Name == name), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
        }
    }
}