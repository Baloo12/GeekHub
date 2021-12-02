namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System.Threading.Tasks;

    using GeekHub.BoardGames.BggProvider.Domain.Api.Http;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;
    using GeekHub.BoardGames.BggProvider.Domain.Constants;

    public class BggXmlApiClient : IBggApiClient
    {
        private readonly IHttpClientHandler _httpClient;

        private readonly IRequestBuilderFactory _requestBuilderFactory;

        public BggXmlApiClient(IHttpClientHandler httpClient, IRequestBuilderFactory requestBuilderFactory)
        {
            _httpClient = httpClient;
            _requestBuilderFactory = requestBuilderFactory;
        }

        public async Task<string> GetGameContentAsync(RequestGameParameters requestParameters)
        {
            var urlBuilder = _requestBuilderFactory.GetUrlBuilder(BggUrls.XmlApi, requestParameters);
            var url = urlBuilder.Build();

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
