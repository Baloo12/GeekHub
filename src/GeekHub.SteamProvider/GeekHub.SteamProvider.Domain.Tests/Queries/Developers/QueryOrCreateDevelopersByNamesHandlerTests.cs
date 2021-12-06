using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Developers;
using GeekHub.SteamProvider.Domain.Queries.Handlers.Developers;
using MediatR;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.Developers
{
    public class QueryOrCreateDevelopersByNamesHandlerTests
    {
        public class Handle
        {
            private readonly QueryOrCreateDevelopersByNamesHandler _handler;
            private readonly Mock<IMediator> _mediator;

            public Handle()
            {
                _mediator = new Mock<IMediator>();

                _handler = new QueryOrCreateDevelopersByNamesHandler(_mediator.Object);
            }

            [Fact]
            public async Task ShouldCallQuery_AndReturn_ListOfDevelopers_ByEachNames()
            {
                //Arrange
                var firstName = "first_developer";
                var secondName = "second_developer";
                var names = new List<string>()
                {
                    firstName,
                    secondName
                };
                var request = new QueryOrCreateDevelopersByNames(names);
                var firstDeveloper = new Developer();
                var secondDeveloper = new Developer();
                var developers = new List<Developer>()
                {
                    firstDeveloper,
                    secondDeveloper
                };
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryOrCreateDeveloperByName>(q => q.Name == firstName), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(firstDeveloper);
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryOrCreateDeveloperByName>(q => q.Name == secondName), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(secondDeveloper);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(developers);
            }
            
            [Fact]
            public async Task ShouldReturnEmptyList_IfDevelopersNamesAreMissed()
            {
                //Arrange
                var names = new List<string>();
                var request = new QueryOrCreateDevelopersByNames(names);
                var emptyList = new List<Developer>();
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(emptyList);
            }
        }
    }
}