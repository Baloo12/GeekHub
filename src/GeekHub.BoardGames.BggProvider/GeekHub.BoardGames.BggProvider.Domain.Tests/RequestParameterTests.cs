namespace GeekHub.BoardGames.BggProvider.Domain.Tests
{
    using System.Collections.Generic;

    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;
    using GeekHub.BoardGames.BggProvider.Domain.Tests.Common.DataClasses;

    using Moq;

    using Xunit;

    public class RequestParameterTests
    {
        private const string KeyExample = "Key";

        [Fact]
        public void CreateAnyType_SetValue_ValueUpdated()
        {
            var initialValue = "1";
            var parameter = new RequestParameter<string>(KeyExample, initialValue);
            Assert.Equal(initialValue, parameter.Get());

            var newValue = "2";
            parameter.Set(newValue);
            Assert.Equal(newValue, parameter.Get());
        }

        [Fact]
        public void CreateBoolean_False_ToString_ExpectEmpty()
        {
            var parameter = new RequestParameter<bool>(KeyExample, false);
            
            var actualResult = parameter.ToString();
            
            Assert.Empty(actualResult);
        }

        [Fact]
        public void CreateBoolean_True_ToString_Expect1()
        {
            var parameter = new RequestParameter<bool>(KeyExample, true);
            
            var actualResult = parameter.ToString();
            var expectedResult = GenerateKeyValueExample(KeyExample, 1.ToString());
            
            Assert.Equal(expectedResult, actualResult);
        }
        
        [Fact]
        public void CreateIEnumerable_Empty_ToString_ExpectEmpty()
        {
            var parameter = new RequestParameter<IEnumerable<It.IsAnyType>>(KeyExample);
            
            var actualResult = parameter.ToString();
            
            Assert.Empty(actualResult);
        }
        
        [Fact]
        public void CreateIEnumerable_SingleElement_ToString_ExpectSingleValue()
        {
            var singleValue = "a";
            var parameter = new RequestParameter<IEnumerable<string>>(KeyExample, new List<string>()
                {
                    singleValue
                });
            
            var actual = parameter.ToString();
            var expected = GenerateKeyValueExample(KeyExample, singleValue);
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void CreateIEnumerable_MultipleElements_ToString_ExpectComaSeparatedValues()
        {
            var values = new List<int>()
                {
                    1,2
                };
            var parameter = new RequestParameter<IEnumerable<int>>(KeyExample, values);
            
            var actual = parameter.ToString();
            var expected = GenerateKeyValueExample(KeyExample, "1,2");
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void CreateAnyType_ValueIsNull_ToString_ExpectEmpty()
        {
            var parameter = new RequestParameter<It.IsAnyType>(KeyExample, null);
            
            var actual = parameter.ToString();
            Assert.Empty(actual);
        }
        
        [Fact]
        public void CreateInt_ToString_ExpectInternalToString()
        {
            var fakeObjectMock = new Mock<FakeType>();
            fakeObjectMock.Setup(x => x.ToString());
            var parameter = new RequestParameter<FakeType>(KeyExample, fakeObjectMock.Object);
            
            _ = parameter.ToString();
            
            fakeObjectMock.Verify(x => x.ToString(),Times.Once);
        }

        [Theory]
        [ClassData(typeof(EmptyStringsData))]
        public void CreateWithEmptyKey_ThrowRequestParameterKeyIsEmptyException(string emptyKey)
        {
            Assert.Throws<RequestParameterKeyIsEmptyException>(() => new RequestParameter<It.IsAnyType>(emptyKey));
        }

        private string GenerateKeyValueExample(string key, string value)
        {
            return $"{key}={value}";
        }
    }

    public class FakeType
    {
    }
}
