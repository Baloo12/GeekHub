namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class BaseRequestParameters : IRequestParameters
    {
        public abstract string ItemType { get; }

        public string BuildParametersString()
        {
            var parameters = GetStringParameters();

            return parameters.Any(x => string.IsNullOrEmpty(x) == false)
                ? JoinParameters(parameters)
                : string.Empty;
        }

        protected abstract IEnumerable<string> GetStringParameters();

        private static string JoinParameters(IEnumerable<string> parameters)
        {
            return $"?{string.Join('&', parameters)}";
        }
    }
}
