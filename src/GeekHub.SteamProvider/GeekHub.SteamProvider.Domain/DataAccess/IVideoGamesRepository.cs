using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IVideoGamesRepository : IBaseRepository<VideoGame>
    {
        Task<VideoGame> GetBySteamIdAsync(string steamId);
        
        Task<IEnumerable<string>> GetAllSteamIdsAsync();
    }
}