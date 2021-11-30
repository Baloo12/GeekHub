using GeekHub.Common.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using System.Threading.Tasks;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IGenresRepository : IBaseRepository<Genre>
    {
        Task<Genre> CreateAndReturnAsync(Genre model);
        
        Task<Genre> GetByName(string name);
    }
}