namespace GeekHub.BoardGames.BggProvider.Domain.Tests
{
    using System.IO;
    using System.Net.Http;

    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.Http;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;

    using Moq;

    using Xunit;

    public class BggXmlApiClientTests
    {
        public class GetGameById
        {
            private readonly Mock<IHttpClientHandler> _httpClientMock = new();

            private readonly Mock<IRequestBuilderFactory> _requestBuilderFactoryMock = new();

            public GetGameById()
            {
                var builderMock = new Mock<IRequestBuilder>();
                _requestBuilderFactoryMock.Setup(x => x.GetUrlBuilder(It.IsAny<string>(), It.IsAny<IRequestParameters>())).Returns(builderMock.Object);
            }

            [Fact]
            public async void IdIsCorrect_ReturnExpectedContent()
            {
                const string ExpectedContent = "gameContent";
                var expectedResponse = new HttpResponseMessage()
                    {
                        Content = new StringContent(ExpectedContent)
                    };

                _httpClientMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(expectedResponse);

                var client = CreateClient();

                var actualContent = await client.GetGameContentAsync(
                    new RequestGameParameters()
                        {
                            BggIds = new[]
                                {
                                    1
                                }
                        });

                Assert.Equal(ExpectedContent, actualContent);
            }

            [Fact]
            public void IdIsIncorrect_ThrowException()
            {
                var client = CreateClient();

                Assert.ThrowsAsync<InvalidDataException>(async () => await client.GetGameContentAsync(It.IsAny<RequestGameParameters>()));
            }

            private BggXmlApiClient CreateClient()
            {
                return new BggXmlApiClient(_httpClientMock.Object, _requestBuilderFactoryMock.Object);
            }
        }
    }
}
