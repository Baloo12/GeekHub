namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base
{
    using System;

    public class RequestParameterAttribute : Attribute
    {
        public RequestParameterAttribute(string key)
        {
            Key = key;
        }

        public string Key { get; }
    }
}
