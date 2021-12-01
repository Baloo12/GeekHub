namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;

    public class RequestParameterConstructor : IRequestParameterConstructor
    {
        private const string BooleanTrueParameterValue = "1";

        public string Construct<T>(string key, T value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new RequestParameterKeyIsEmptyException();
            }

            if (value is null)
            {
                return string.Empty;
            }

            var stringValue = GetStringValues(value);
            return string.IsNullOrEmpty(stringValue)
                ? string.Empty
                : $"{key}={stringValue}";
        }

        private string GetStringFromBoolean(bool booleanValue)
        {
            return booleanValue
                ? BooleanTrueParameterValue
                : string.Empty;
        }

        private string GetStringFromEnumerable<TItem>(IEnumerable<TItem> enumerableValue)
        {
            var enumerable = enumerableValue as TItem[] ?? enumerableValue.ToArray();
            return enumerable.Any() == false
                ? string.Empty
                : string.Join(',', enumerable);
        }

        private string GetStringValues<T>(T value)
        {
            string result;
            switch (value)
            {
                case bool booleanValue:
                    result = GetStringFromBoolean(booleanValue);
                    break;
                case IEnumerable<string> stringsCollection:
                    result = GetStringFromEnumerable(stringsCollection);
                    break;
                case IEnumerable<int> intCollection:
                    result = GetStringFromEnumerable(intCollection);
                    break;
                default:
                    result = value.ToString();
                    break;
            }

            return result;
        }
    }

    public class RequestParameterKeyIsEmptyException : Exception
    {
    }
}
