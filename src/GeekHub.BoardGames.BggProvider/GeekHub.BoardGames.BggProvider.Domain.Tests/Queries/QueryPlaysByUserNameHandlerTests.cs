namespace GeekHub.BoardGames.BggProvider.Domain.Tests.Queries
{
    using System;
    using System.Linq;

    using AutoMapper;

    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Domain.Dtos;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;
    using GeekHub.BoardGames.BggProvider.Domain.Mapping;
    using GeekHub.BoardGames.BggProvider.Domain.Queries;
    using GeekHub.BoardGames.BggProvider.Domain.Queries.Handlers;

    using Moq;

    using Xunit;

    public class QueryPlaysByUserNameHandlerTests
    {
        private const int DefaultPageSize = 100;

        private readonly Mock<IBggApiClient> _bggApiClientMock;
        private readonly IMapper _mapper;

        public QueryPlaysByUserNameHandlerTests()
        {
            _bggApiClientMock = new Mock<IBggApiClient>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            _mapper = config.CreateMapper();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void ReturnCorrectAmountOfPlays(int pageCount)
        {
            var existingPlaysCount = SetupGetPlayRecords(pageCount);

            var handler = CreateHandler();
            var result = await handler.Handle(new QueryPlaysByUserNameRequest(It.IsAny<string>()));
            Assert.Equal(existingPlaysCount, result.Count());
        }

        private int SetupGetPlayRecords(int existingPageCount)
        {
            var existingPlaysCount = (int)Math.Round(DefaultPageSize * (existingPageCount - 0.5));
            _bggApiClientMock.Setup(x => x.GetPlayRecordsAsync(It.IsAny<RequestPlaysParameters>()))
                .ReturnsAsync(
                    (RequestPlaysParameters x) =>
                        {
                            var plays = x.Page < existingPageCount
                                ? DefaultPageSize
                                : (int)Math.Round(DefaultPageSize * 0.5);

                            return new PlayRecordsResponse()
                                {
                                    Plays = new PlayRecord[plays],
                                    TotalPlays = existingPlaysCount,
                                    PageNumber = x.Page
                                };
                        });
            return existingPlaysCount;
        }

        private QueryPlaysByUserNameHandler CreateHandler()
        {
            return new QueryPlaysByUserNameHandler(_bggApiClientMock.Object, _mapper);
        }
    }
}
