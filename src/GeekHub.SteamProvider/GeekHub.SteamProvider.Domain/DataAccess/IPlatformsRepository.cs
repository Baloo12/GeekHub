using GeekHub.Common.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using System.Threading.Tasks;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IPlatformsRepository : IBaseRepository<Platform>
    {
        Task<Platform> CreateAndReturnAsync(Platform model);
        
        Task<Platform> GetByName(string name);
    }
}