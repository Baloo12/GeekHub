namespace GeekHub.BoardGames.BggProvider.Domain.Tests
{
    using System.IO;
    using System.Net.Http;

    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.Http;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;

    using Moq;

    using Xunit;

    public class BggXmlApiClientTests
    {
        [Fact]
        public async void GetGameById_IdIsCorrect_ReturnExpectedContent()
        {
            var httpClientMock = new Mock<IHttpClientHandler>();
            const string ExpectedContent = "gameContent";
            var expectedResponse = new HttpResponseMessage()
                {
                    Content = new StringContent(ExpectedContent)
                };

            httpClientMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(expectedResponse);

            var client = new BggXmlApiClient(httpClientMock.Object);

            var actualContent = await client.GetGameContentAsync(new RequestGameParameters());

            Assert.Equal(ExpectedContent, actualContent);
        }

        [Fact]
        public void GetGameById_IdIsIncorrect_ThrowException()
        {
            var httpClientMock = new Mock<IHttpClientHandler>();
            var client = new BggXmlApiClient(httpClientMock.Object);

            Assert.ThrowsAsync<InvalidDataException>(async () => await client.GetGameContentAsync(It.IsAny<RequestGameParameters>()));
        }
    }
}
