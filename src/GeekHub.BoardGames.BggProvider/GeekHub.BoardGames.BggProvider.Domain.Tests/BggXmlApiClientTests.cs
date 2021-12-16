namespace GeekHub.BoardGames.BggProvider.Domain.Tests
{
    using System.IO;
    using System.Net.Http;

    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.Http;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    using Moq;

    using Xunit;

    public class BggXmlApiClientTests
    {
        public class GetGameById
        {
            private readonly Mock<IHttpClientHandler> _httpClientMock = new();

            private readonly Mock<IRequestBuilderFactory> _requestBuilderFactoryMock = new();
            private readonly Mock<IContentParser> _contentParserMock = new();

            public GetGameById()
            {
                var builderMock = new Mock<IRequestBuilder>();
                _requestBuilderFactoryMock.Setup(x => x.GetUrlBuilder(It.IsAny<string>(), It.IsAny<IRequestParameters>())).Returns(builderMock.Object);

                var expectedResponse = new HttpResponseMessage()
                    {
                        Content = new StringContent("somestring")
                    };

                _httpClientMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(expectedResponse);
            }

            [Fact]
            public async void IdIsCorrect_ReturnExpectedContent()
            {
                var expectedGame = new BoardGame();

                _contentParserMock.Setup(x => x.ParseGame(It.IsAny<string>())).Returns(expectedGame);

                var client = CreateClient();

                var actualContent = await client.GetGameAsync(
                    new RequestGameParameters()
                        {
                            BggIds = new[]
                                {
                                    1
                                }
                        });

                Assert.Equal(expectedGame, actualContent);
            }

            [Fact]
            public void IdIsIncorrect_ThrowException()
            {
                var client = CreateClient();

                Assert.ThrowsAsync<InvalidDataException>(async () => await client.GetGameAsync(It.IsAny<RequestGameParameters>()));
            }

            private BggXmlApiClient CreateClient()
            {
                
                return new BggXmlApiClient(_httpClientMock.Object, _requestBuilderFactoryMock.Object, _contentParserMock.Object);
            }
        }
    }
}
