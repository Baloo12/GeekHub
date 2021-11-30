using GeekHub.Common.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using System.Threading.Tasks;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IDevelopersRepository : IBaseRepository<Developer>
    {
        Task<Developer> CreateAndReturnAsync(Developer model);
        
        Task<Developer> GetByName(string name);
    }
}