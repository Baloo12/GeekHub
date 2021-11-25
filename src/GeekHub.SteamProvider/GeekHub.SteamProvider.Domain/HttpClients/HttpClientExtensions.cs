using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GeekHub.SteamProvider.Domain.HttpClients
{
    public static class HttpClientExtensions
    {
        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
    }
}