namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;

    public class RequestBuilderFactory : IRequestBuilderFactory
    {
        private readonly IRequestParameterConstructor _requestParameterConstructor;

        public RequestBuilderFactory(IRequestParameterConstructor requestParameterConstructor)
        {
            _requestParameterConstructor = requestParameterConstructor;
        }

        public IRequestBuilder GetUrlBuilder(string baseUrl, IRequestParameters parameters)
        {
            return new UrlRequestBuilder(baseUrl, parameters, _requestParameterConstructor);
        }
    }
}
