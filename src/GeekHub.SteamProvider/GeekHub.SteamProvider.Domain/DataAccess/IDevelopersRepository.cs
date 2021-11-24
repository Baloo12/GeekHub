using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IDevelopersRepository : IBaseRepository<Developer>
    {
        Task<Developer> CreateAndReturnAsync(Developer model);
        
        Task<Developer> GetByName(string name);
    }
}