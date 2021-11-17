﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GeekHub.VideoGamesSource.Domain.Interfaces;
using GeekHub.VideoGamesSource.Domain.Models;
using Newtonsoft.Json;

namespace GeekHub.VideoGamesSource.Domain
{
    public abstract class BaseVideoGamesProvider : IVideoGamesProvider
    {
        protected abstract string Source { get; }

        public abstract Task<IEnumerable<string>> GetAllIds();

        public async Task<VideoGameDetails> GetDetails(string id)
        {
            var details = await RequestDetails(id);
            if (details != null)
            {
                details.Source = Source;
            }

            return details;
        }

        protected abstract Task<VideoGameDetails> RequestDetails(string id);

        protected async Task<TResponse> Request<TResponse>(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
    }
}