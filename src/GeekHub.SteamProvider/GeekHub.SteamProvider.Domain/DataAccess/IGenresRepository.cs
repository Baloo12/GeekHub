using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IGenresRepository : IBaseRepository<Genre>
    {
        Task<Genre> CreateAndReturnAsync(Genre model);
        
        Task<Genre> GetByName(string name);
    }
}