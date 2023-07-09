using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.Commands.Platforms;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Platforms;
using GeekHub.SteamProvider.Domain.Queries.Handlers.Platforms;
using MediatR;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.Platforms
{
    public class QueryOrCreatePlatformByNameHandlerTests
    {
        public class Handle
        {
            private readonly QueryOrCreatePlatformByNameHandler _handler;
            private readonly Mock<IMediator> _mediator;

            public Handle()
            {
                _mediator = new Mock<IMediator>();

                _handler = new QueryOrCreatePlatformByNameHandler(_mediator.Object);
            }

            [Fact]
            public async Task ShouldCallQuery_AndReturn_PlatformByName()
            {
                //Arrange
                var name = "test";
                var request = new QueryOrCreatePlatformByName(name);
                var entity = new Platform();
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryPlatformByName>(q => q.Name == name), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
            
            [Fact]
            public async Task ShouldCreatePlatform_AndReturn_IfMissed()
            {
                //Arrange
                var name = "test";
                var request = new QueryOrCreatePlatformByName(name);
                var entity = new Platform();
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryPlatformByName>(q => q.Name == name), It.IsAny<CancellationToken>()));
                
                _mediator
                    .Setup(r => r.Send(It.Is<CreatePlatformCommand>(q => q.Name == name), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
        }
    }
}