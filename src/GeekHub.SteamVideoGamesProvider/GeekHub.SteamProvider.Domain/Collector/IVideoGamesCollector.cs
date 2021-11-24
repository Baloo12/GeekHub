using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Models.Internal;

namespace GeekHub.SteamProvider.Domain.Collector
{
    public interface IVideoGamesCollector
    {
        Task<IEnumerable<string>> GetAllIds();

        Task<VideoGameDetails> GetDetails(string id);

        Task BeginCollect();
    }
}