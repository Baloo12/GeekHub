using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Platforms;
using GeekHub.SteamProvider.Domain.Queries.Handlers.Platforms;
using MediatR;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.Platforms
{
    public class QueryOrCreatePlatformsByNamesHandlerTests
    {
        public class Handle
        {
            private readonly QueryOrCreatePlatformsByNamesHandler _handler;
            private readonly Mock<IMediator> _mediator;

            public Handle()
            {
                _mediator = new Mock<IMediator>();

                _handler = new QueryOrCreatePlatformsByNamesHandler(_mediator.Object);
            }

            [Fact]
            public async Task ShouldCallQuery_AndReturn_ListOfPlatforms_ByEachNames()
            {
                //Arrange
                var firstName = "first";
                var secondName = "second";
                var names = new List<string>()
                {
                    firstName,
                    secondName
                };
                var request = new QueryOrCreatePlatformsByNames(names);
                var firstPlatform = new Platform();
                var secondPlatform = new Platform();
                var platforms = new List<Platform>()
                {
                    firstPlatform,
                    secondPlatform
                };
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryOrCreatePlatformByName>(q => q.Name == firstName), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(firstPlatform);
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryOrCreatePlatformByName>(q => q.Name == secondName), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(secondPlatform);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(platforms);
            }
            
            [Fact]
            public async Task ShouldReturnEmptyList_IfPlatformsNamesAreMissed()
            {
                //Arrange
                var names = new List<string>();
                var request = new QueryOrCreatePlatformsByNames(names);
                var emptyList = new List<Platform>();
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(emptyList);
            }
        }
    }
}