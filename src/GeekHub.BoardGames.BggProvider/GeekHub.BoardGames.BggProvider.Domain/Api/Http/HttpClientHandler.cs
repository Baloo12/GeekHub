namespace GeekHub.BoardGames.BggProvider.Domain.Api.Http
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public class HttpClientHandler : IHttpClientHandler
    {
        private readonly HttpClient _client;

        public HttpClientHandler(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public HttpResponseMessage Get(string url)
        {
            return GetAsync(url).Result;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            return PostAsync(url, content).Result;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }
    }
}
