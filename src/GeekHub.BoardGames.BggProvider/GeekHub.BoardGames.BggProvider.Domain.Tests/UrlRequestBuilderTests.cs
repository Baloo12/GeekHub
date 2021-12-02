namespace GeekHub.BoardGames.BggProvider.Domain.Tests
{
    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;
    using GeekHub.BoardGames.BggProvider.Domain.Tests.Common.DataClasses;

    using Moq;

    using Xunit;

    public class UrlRequestBuilderTests
    {
        private const string ExampleBaseUrl = "url/";

        public static string ExampleItemType = "sometype";

        public static string Param1Key = "Param1Key";

        public static string Param2Key = "Param2Key";

        private readonly Mock<IRequestParameterConstructor> _parameterConstructorMock = new();

        public UrlRequestBuilderTests()
        {
            _parameterConstructorMock.Setup(x => x.Construct(It.IsAny<string>(), It.IsAny<It.IsAnyType>())).Returns((string x, string y) => $"{x}={y}");
        }

        [Fact]
        public void Build_EmptyParameters_ReturnBaseUrlWithItemType()
        {
            var parameters = new EmptyParameters();
            var builder = new UrlRequestBuilder(ExampleBaseUrl, parameters, _parameterConstructorMock.Object);

            var actual = builder.Build();
            var expected = $"{ExampleBaseUrl}{ExampleItemType}";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Build_ManyParameters_ReturnCorrectUrl()
        {
            var param1 = _parameterConstructorMock.Object.Construct<string>(Param1Key, null);
            var param2 = _parameterConstructorMock.Object.Construct<string>(Param2Key, null);

            var builder = new UrlRequestBuilder(ExampleBaseUrl, new ManyParameters(), _parameterConstructorMock.Object);

            var actual = builder.Build();
            var expected = $"{ExampleBaseUrl}{ExampleItemType}?{param1}&{param2}";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Build_OneParameter_ReturnCorrectUrl()
        {
            var param = _parameterConstructorMock.Object.Construct<string>(Param1Key, null);
            var builder = new UrlRequestBuilder(ExampleBaseUrl, new SingleParameter(), _parameterConstructorMock.Object);

            var actual = builder.Build();
            var expected = $"{ExampleBaseUrl}{ExampleItemType}?{param}";
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(EmptyStringsData))]
        public void Create_EmptyBaseUrl_ThrowEmptyBaseUrlException(string emptyUrl)
        {
            Assert.Throws<EmptyBaseUrlException>(() => new UrlRequestBuilder(emptyUrl, null, _parameterConstructorMock.Object));
        }

        [Fact]
        public void Create_ParameterItemTypeIsEmpty_ThrowEmptyParametersItemTypeException()
        {
            Assert.Throws<EmptyParametersItemTypeException>(() => new UrlRequestBuilder(ExampleBaseUrl, new EmptyItemTypeParameters(), _parameterConstructorMock.Object));
        }

        [Fact]
        public void Create_ParametersIsNull_ThrowEmptyRequestParametersException()
        {
            Assert.Throws<EmptyRequestParametersException>(() => new UrlRequestBuilder(ExampleBaseUrl, null, _parameterConstructorMock.Object));
        }
    }

    class EmptyItemTypeParameters : IRequestParameters
    {
        public string ItemType { get; }
    }

    class EmptyParameters : IRequestParameters
    {
        public string ItemType => UrlRequestBuilderTests.ExampleItemType;
    }

    class SingleParameter : IRequestParameters
    {
        public string ItemType => UrlRequestBuilderTests.ExampleItemType;

        [RequestParameter("Param1Key")]
        public string Param { get; set; }
    }

    class ManyParameters : IRequestParameters
    {
        public string ItemType => UrlRequestBuilderTests.ExampleItemType;

        [RequestParameter("Param1Key")]
        public string Param1 { get; set; }

        [RequestParameter("Param2Key")]
        public string Param2 { get; set; }
    }
}
