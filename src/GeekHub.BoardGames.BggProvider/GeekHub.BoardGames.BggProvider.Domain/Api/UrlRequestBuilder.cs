namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;

    public class UrlRequestBuilder : IRequestBuilder
    {
        private readonly string _baseUrl;

        private readonly IRequestParameterConstructor _parameterConstructor;

        private readonly IRequestParameters _parameters;

        public UrlRequestBuilder(string baseUrl, IRequestParameters parameters, IRequestParameterConstructor parameterConstructor)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new EmptyBaseUrlException();
            }

            if (parameters is null)
            {
                throw new EmptyRequestParametersException();
            }

            if (string.IsNullOrEmpty(parameters.ItemType))
            {
                throw new EmptyParametersItemTypeException();
            }

            _baseUrl = baseUrl;
            _parameters = parameters;
            _parameterConstructor = parameterConstructor;
        }

        public string Build()
        {
            var parametersSection = GenerateParametersSection(_parameters);
            if (string.IsNullOrEmpty(parametersSection) == false)
            {
                parametersSection = $"?{parametersSection}";
            }

            return $"{_baseUrl}{_parameters.ItemType}{parametersSection}";
        }

        private IEnumerable<string> ExtractParametersKeyValuePairs(IRequestParameters parameters)
        {
            var properties = parameters.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(RequestParameterAttribute), false));
            var keyValues = new List<string>();
            foreach (var property in properties)
            {
                var key = ((RequestParameterAttribute[])property.GetCustomAttributes(typeof(RequestParameterAttribute), false)).First().Key;
                var value = property.GetValue(parameters);
                var parameter = _parameterConstructor.Construct(key, value);
                keyValues.Add(parameter);
            }

            return keyValues;
        }

        private string GenerateParametersSection(IRequestParameters parameters)
        {
            var parametersKeyValues = ExtractParametersKeyValuePairs(parameters);

            var result = parametersKeyValues.Any()
                ? string.Join('&', parametersKeyValues)
                : string.Empty;

            return result;
        }
    }

    public class EmptyRequestParametersException : Exception
    {
    }

    public class EmptyParametersItemTypeException : Exception
    {
    }

    public class EmptyBaseUrlException : Exception
    {
    }
}
