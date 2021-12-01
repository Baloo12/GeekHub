namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RequestParameter<T>
    {
        public RequestParameter(string key, T value = default)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new RequestParameterKeyIsEmptyException();
            }
            
            _key = key;
            _value = value;
        }

        public void Set(T value)
        {
            _value = value;
        }

        public T Get()
        {
            return _value;
        }

        private T _value;

        private readonly string _key;

        public override string ToString()
        {
            if (_value == null)
            {
                return string.Empty;
            }

            var stringValue = GetStringValue();

            return string.IsNullOrEmpty(stringValue)
                ? string.Empty
                : $"{_key}={stringValue}";
        }

        private string GetStringValue()
        {
            string result;
            switch (_value)
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
                    result = _value.ToString();
                    break;
            }

            return result;
        }

        private string GetStringFromEnumerable<TItem>(IEnumerable<TItem> enumerableValue)
        {
            var enumerable = enumerableValue as TItem[] ?? enumerableValue.ToArray();
            return enumerable.Any() == false
                ? string.Empty
                : string.Join(',', enumerable);
        }
        
        private string GetStringFromBoolean(bool booleanValue)
        {
            return booleanValue
                ? 1.ToString()
                : string.Empty;
        }
    }

    public class RequestParameterKeyIsEmptyException : Exception
    {
    }
}
