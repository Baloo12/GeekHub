namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System.Threading.Tasks;

    using GeekHub.BoardGames.BggProvider.Domain.Api.Http;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;
    using GeekHub.BoardGames.BggProvider.Domain.Constants;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public class BggXmlApiClient : IBggApiClient
    {
        private readonly IContentParser _contentParser;

        private readonly IHttpClientHandler _httpClient;

        private readonly IRequestBuilderFactory _requestBuilderFactory;

        public BggXmlApiClient(IHttpClientHandler httpClient, IRequestBuilderFactory requestBuilderFactory, IContentParser contentParser)
        {
            _httpClient = httpClient;
            _requestBuilderFactory = requestBuilderFactory;
            _contentParser = contentParser;
        }

        public async Task<BoardGame> GetGameAsync(RequestGameParameters parameters)
        {
            var content = await SendGetRequestAsync(parameters);

            var entity = _contentParser.ParseGame(content);
            return entity;
        }

        public async Task<PlayRecordsResponse> GetPlayRecordsAsync(RequestPlaysParameters parameters)
        {
            var content = await SendGetRequestAsync(parameters);

            var entity = _contentParser.ParsePlayRecords(content);
            var metadata = _contentParser.ParsePlayRecordsMetadata(content);
            var response = new PlayRecordsResponse()
                {
                    Plays = entity,
                    TotalPlays = metadata.TotalPlays,
                    PageNumber = metadata.PageNumber
                };
            return response;
        }

        private async Task<string> SendGetRequestAsync(IRequestParameters requestParameters)
        {
            var urlBuilder = _requestBuilderFactory.GetUrlBuilder(BggUrls.XmlApi, requestParameters);
            var url = urlBuilder.Build();

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
