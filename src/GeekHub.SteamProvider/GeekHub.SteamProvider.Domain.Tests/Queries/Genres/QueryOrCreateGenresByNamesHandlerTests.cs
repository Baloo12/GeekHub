using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Genres;
using GeekHub.SteamProvider.Domain.Queries.Handlers.Genres;
using MediatR;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.Genres
{
    public class QueryOrCreateGenresByNamesHandlerTests
    {
        public class Handle
        {
            private readonly QueryOrCreateGenresByNamesHandler _handler;
            private readonly Mock<IMediator> _mediator;

            public Handle()
            {
                _mediator = new Mock<IMediator>();

                _handler = new QueryOrCreateGenresByNamesHandler(_mediator.Object);
            }

            [Fact]
            public async Task ShouldCallQuery_AndReturn_ListOfGenres_ByEachNames()
            {
                //Arrange
                var firstName = "first";
                var secondName = "second";
                var names = new List<string>()
                {
                    firstName,
                    secondName
                };
                var request = new QueryOrCreateGenresByNames(names);
                var firstGenre = new Genre();
                var secondGenre = new Genre();
                var genres = new List<Genre>()
                {
                    firstGenre,
                    secondGenre
                };
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryOrCreateGenreByName>(q => q.Name == firstName), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(firstGenre);
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryOrCreateGenreByName>(q => q.Name == secondName), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(secondGenre);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(genres);
            }
            
            [Fact]
            public async Task ShouldReturnEmptyList_IfGenresNamesAreMissed()
            {
                //Arrange
                var names = new List<string>();
                var request = new QueryOrCreateGenresByNames(names);
                var emptyList = new List<Genre>();
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(emptyList);
            }
        }
    }
}