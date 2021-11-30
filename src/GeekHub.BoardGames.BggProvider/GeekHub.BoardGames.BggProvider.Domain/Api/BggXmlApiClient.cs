namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System.Threading.Tasks;

    using GeekHub.BoardGames.BggProvider.Domain.Api.Http;
    using GeekHub.BoardGames.BggProvider.Domain.Constants;

    public class BggXmlApiClient : IBggApiClient
    {
        private readonly IHttpClientHandler _httpClient;

        public BggXmlApiClient(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetGameContentAsync(int bggId)
        {
            var url = $"{BggUrls.XmlApi}thing?id={bggId}&stats=1";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
