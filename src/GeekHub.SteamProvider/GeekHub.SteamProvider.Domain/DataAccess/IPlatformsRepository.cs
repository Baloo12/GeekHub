using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IPlatformsRepository : IBaseRepository<Platform>
    {
        Task<Platform> CreateAndReturnAsync(Platform model);
        
        Task<Platform> GetByName(string name);
    }
}