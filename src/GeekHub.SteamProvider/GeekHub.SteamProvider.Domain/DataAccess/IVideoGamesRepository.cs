using System;
using GeekHub.Common.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IVideoGamesRepository : IBaseRepository<VideoGame>
    {
        Task CreateAsync(IEnumerable<VideoGame> videoGames);
        
        Task<VideoGame> GetBySteamIdAsync(string steamId);
        
        Task<VideoGame> GetByGeekHubIdAsync(Guid geekHubId);
        
        Task<IEnumerable<string>> GetAllSteamIdsAsync();
    }
}