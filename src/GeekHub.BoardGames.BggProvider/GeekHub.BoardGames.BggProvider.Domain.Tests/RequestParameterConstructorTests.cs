namespace GeekHub.BoardGames.BggProvider.Domain.Tests
{
    using System.Collections.Generic;

    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Tests.Common.DataClasses;

    using Moq;

    using Xunit;

    public class RequestParameterConstructorTests
    {
        public class Construct
        {
            private const string KeyExample = "Key";

            [Fact]
            public void CreateAnyType_ValueIsNull_ToString_ExpectEmpty()
            {
                var constructor = new RequestParameterConstructor();
                var parameter = constructor.Construct<It.IsAnyType>(KeyExample, null);

                var actual = parameter;
                Assert.Empty(actual);
            }

            [Fact]
            public void CreateBoolean_False_ToString_ExpectEmpty()
            {
                var constructor = new RequestParameterConstructor();
                var actualResult = constructor.Construct(KeyExample, false);

                Assert.Empty(actualResult);
            }

            [Fact]
            public void CreateBoolean_True_ToString_Expect1()
            {
                var constructor = new RequestParameterConstructor();
                var actualResult = constructor.Construct(KeyExample, true);
                var expectedResult = GenerateKeyValue(KeyExample, 1.ToString());

                Assert.Equal(expectedResult, actualResult);
            }

            [Fact]
            public void CreateIEnumerable_Empty_ToString_ExpectEmpty()
            {
                var constructor = new RequestParameterConstructor();
                var actualResult = constructor.Construct(KeyExample, It.IsAny<It.IsAnyType>());

                Assert.Empty(actualResult);
            }

            [Fact]
            public void CreateIEnumerable_MultipleElements_ToString_ExpectComaSeparatedValues()
            {
                var values = new List<int>()
                    {
                        1,
                        2
                    };

                var constructor = new RequestParameterConstructor();
                var actual = constructor.Construct(KeyExample, values);

                var expected = GenerateKeyValue(KeyExample, "1,2");
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void CreateIEnumerable_SingleElement_ToString_ExpectSingleValue()
            {
                var singleValue = "a";

                var constructor = new RequestParameterConstructor();
                var actual = constructor.Construct(
                    KeyExample,
                    new List<string>()
                        {
                            singleValue
                        });

                var expected = GenerateKeyValue(KeyExample, singleValue);
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void CreateInt_ToString_ExpectInternalToString()
            {
                var fakeObjectMock = new Mock<FakeType>();
                fakeObjectMock.Setup(x => x.ToString());

                var constructor = CreateConstructor();
                var result = constructor.Construct(KeyExample, fakeObjectMock.Object);

                _ = result;

                fakeObjectMock.Verify(x => x.ToString(), Times.Once);
            }

            [Theory]
            [ClassData(typeof(EmptyStringsData))]
            public void CreateWithEmptyKey_ThrowRequestParameterKeyIsEmptyException(string emptyKey)
            {
                var constructor = CreateConstructor();
                Assert.Throws<RequestParameterKeyIsEmptyException>(() => constructor.Construct(emptyKey, It.IsAny<It.IsAnyType>()));
            }

            private static RequestParameterConstructor CreateConstructor()
            {
                return new RequestParameterConstructor();
            }

            private string GenerateKeyValue(string key, string value)
            {
                return $"{key}={value}";
            }
        }
    }

    public class FakeType
    {
    }
}
