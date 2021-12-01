namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base
{
    public interface IRequestBuilderFactory
    {
        IRequestBuilder GetUrlBuilder(string baseUrl, IRequestParameters parameters);
    }
}
