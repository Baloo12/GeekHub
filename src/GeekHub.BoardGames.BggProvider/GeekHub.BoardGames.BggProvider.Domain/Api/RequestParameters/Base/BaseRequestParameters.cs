namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base
{
    public abstract class BaseRequestParameters : IRequestParameters
    {
        public abstract string ItemType { get; }

        public string BuildParametersString()
        {
            var result = InternalBuildParameters();

            return string.IsNullOrEmpty(result)
                ? string.Empty
                : $"?{result}";
        }

        protected abstract string InternalBuildParameters();
    }
}
