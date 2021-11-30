namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base
{
    using System.Collections.Generic;
    using System.Linq;

    public struct RequestParameter<T>
    {
        public RequestParameter(string key, T value = default)
        {
            _key = key;
            _value = value;
        }

        public void Set(T value)
        {
            _value = value;
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
                    result = booleanValue
                        ? 1.ToString()
                        : string.Empty;
                    break;
                case IEnumerable<string> enumerableValue:
                    result = GetStringFromEnumerable(enumerableValue);
                    break;

                case IEnumerable<int> enumerableValue:
                    result = GetStringFromEnumerable(enumerableValue);
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
    }
}
