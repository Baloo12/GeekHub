using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IPublishersRepository : IBaseRepository<Publisher>
    {
        Task<Publisher> CreateAndReturnAsync(Publisher model);
        
        Task<Publisher> GetByName(string name);
    }
}