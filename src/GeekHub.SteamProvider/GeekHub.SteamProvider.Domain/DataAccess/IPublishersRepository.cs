using GeekHub.Common.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using System.Threading.Tasks;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IPublishersRepository : IBaseRepository<Publisher>
    {
        Task<Publisher> CreateAndReturnAsync(Publisher model);
        
        Task<Publisher> GetByName(string name);
    }
}