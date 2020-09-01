namespace GamesHub.GamesProvider
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using GamesHub.GamesProvider.Contracts;
    using GamesHub.GamesProvider.Contracts.Models;

    using Newtonsoft.Json;

    public abstract class BaseGamesProvider : IGamesProvider
    {
        protected abstract GameSource Source { get; }

        public abstract Task<IEnumerable<string>> GetAllIds();

        public async Task<GameDetails> GetDetails(string id)
        {
            var details = await RequestDetails(id);
            if (details != null)
            {
                details.Source = Source;
            }

            return details;
        }

        protected abstract Task<GameDetails> RequestDetails(string id);

        protected async Task<TResponse> Request<TResponse>(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
    }
}