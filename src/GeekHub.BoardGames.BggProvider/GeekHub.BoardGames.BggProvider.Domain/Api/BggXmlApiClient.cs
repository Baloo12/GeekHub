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

        public BggXmlApiClient(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetGameContentAsync(RequestGameParameters requestParameters)
        {
            var url = BuildUrl(requestParameters);

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        private static string BuildUrl(IRequestParameters requestParameters)
        {
            return $"{BggUrls.XmlApi}{requestParameters.ItemType}{requestParameters.BuildParametersString()}";
        }
    }
}
