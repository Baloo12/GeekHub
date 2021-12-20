namespace GeekHub.BoardGames.BggProvider.Domain.Tests
{
    using System.IO;
    using System.Linq;
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
        private readonly Mock<IContentParser> _contentParserMock = new();

        private readonly Mock<IHttpClientHandler> _httpClientMock = new();

        private readonly Mock<IRequestBuilderFactory> _requestBuilderFactoryMock = new();

        public BggXmlApiClientTests()
        {
            var builderMock = new Mock<IRequestBuilder>();
            _requestBuilderFactoryMock.Setup(x => x.GetUrlBuilder(It.IsAny<string>(), It.IsAny<IRequestParameters>())).Returns(builderMock.Object);

            var expectedResponse = new HttpResponseMessage()
                {
                    Content = new StringContent("somestring")
                };

            _httpClientMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(expectedResponse);
        }

        private BggXmlApiClient CreateClient()
        {
            return new BggXmlApiClient(_httpClientMock.Object, _requestBuilderFactoryMock.Object, _contentParserMock.Object);
        }

        public class GetGameById : BggXmlApiClientTests
        {
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
        }

        public class GetPlaysByUserName : BggXmlApiClientTests
        {
            [Fact]
            public async void UserHasPlays_ReturnCorrectPageNumber()
            {
                var expectedPageNumber = 10;

                _contentParserMock.Setup(x => x.ParsePlayRecordsMetadata(It.IsAny<string>()))
                    .Returns(
                        new PlayRecordsMetadata()
                            {
                                PageNumber = expectedPageNumber
                            });

                var client = CreateClient();
                var response = await client.GetPlayRecordsAsync(new RequestPlaysParameters());

                Assert.Equal(expectedPageNumber, response.PageNumber);
            }

            [Fact]
            public async void UserHasPlays_ReturnCorrectPlaysCount()
            {
                var expectedPlaysCount = 10;

                _contentParserMock.Setup(x => x.ParsePlayRecords(It.IsAny<string>())).Returns(new PlayRecord[10]);
                _contentParserMock.Setup(x => x.ParsePlayRecordsMetadata(It.IsAny<string>())).Returns(new PlayRecordsMetadata());

                var client = CreateClient();
                var response = await client.GetPlayRecordsAsync(
                    new RequestPlaysParameters()
                        {
                            UserName = It.IsAny<string>()
                        });

                Assert.Equal(expectedPlaysCount, response.Plays.Count());
            }

            [Fact]
            public async void UserHasPlays_ReturnCorrectTotalPlaysCount()
            {
                var expectedTotalPlaysCount = 10;

                _contentParserMock.Setup(x => x.ParsePlayRecordsMetadata(It.IsAny<string>()))
                    .Returns(
                        new PlayRecordsMetadata()
                            {
                                TotalPlays = expectedTotalPlaysCount
                            });

                var client = CreateClient();
                var response = await client.GetPlayRecordsAsync(new RequestPlaysParameters());

                Assert.Equal(expectedTotalPlaysCount, response.TotalPlays);
            }
        }
    }
}
