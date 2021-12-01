namespace GeekHub.BoardGames.BggProvider.Domain.Tests
{
    using System.Collections.Generic;

    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;
    using GeekHub.BoardGames.BggProvider.Domain.Tests.Common.DataClasses;

    using Xunit;

    public class BaseRequestParametersTests
    {
        [Theory]
        [ClassData(typeof(EmptyStringsData))]
        public void CreateWithEmptyParameters_ReturnEmptyString(string emptyValue)
        {
            var instance = new StubRequestParameters(emptyValue);
            var actual = instance.BuildParametersString();
            
            Assert.Empty(actual);
        }

        [Fact]
        public void CreateWithSomeValue_ReturnAppropriateString()
        {
            var value = "somevalue";
            
            var instance = new StubRequestParameters(value);
            var actual = instance.BuildParametersString();
            
            Assert.Equal($"?{value}", actual);
        }
    }

    class StubRequestParameters : BaseRequestParameters
    {
        private readonly string[] _parametersValue;

        public StubRequestParameters(params string[] parametersValue)
        {
            _parametersValue = parametersValue;
        }

        public override string ItemType => "example";

        protected override IEnumerable<string> GetStringParameters()
        {
            return _parametersValue;
        }
    }
}
