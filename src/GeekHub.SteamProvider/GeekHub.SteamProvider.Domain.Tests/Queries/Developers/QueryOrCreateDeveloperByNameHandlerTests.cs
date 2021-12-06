using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GeekHub.SteamProvider.Domain.Commands.Developers;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Queries.Developers;
using GeekHub.SteamProvider.Domain.Queries.Handlers.Developers;
using MediatR;
using Moq;
using Xunit;

namespace GeekHub.SteamProvider.Domain.Tests.Queries.Developers
{
    public class QueryOrCreateDeveloperByNameHandlerTests
    {
        public class Handle
        {
            private readonly QueryOrCreateDeveloperByNameHandler _handler;
            private readonly Mock<IMediator> _mediator;

            public Handle()
            {
                _mediator = new Mock<IMediator>();

                _handler = new QueryOrCreateDeveloperByNameHandler(_mediator.Object);
            }

            [Fact]
            public async Task ShouldCallQuery_AndReturn_DeveloperByName()
            {
                //Arrange
                var name = "test";
                var request = new QueryOrCreateDeveloperByName(name);
                var entity = new Developer();
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryDeveloperByName>(q => q.Name == name), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
            
            [Fact]
            public async Task ShouldCreateDeveloper_AndReturn_IfMissed()
            {
                //Arrange
                var name = "test";
                var request = new QueryOrCreateDeveloperByName(name);
                var entity = new Developer();
                
                _mediator
                    .Setup(r => r.Send(It.Is<QueryDeveloperByName>(q => q.Name == name), It.IsAny<CancellationToken>()));
                
                _mediator
                    .Setup(r => r.Send(It.Is<CreateDeveloperCommand>(q => q.Name == name), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(entity);
                
                //Act
                var response = await _handler.Handle(request);

                //Assert
                response.Should().BeEquivalentTo(entity);
            }
        }
    }
}