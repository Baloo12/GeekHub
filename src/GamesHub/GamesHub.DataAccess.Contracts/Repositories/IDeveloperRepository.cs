using System.Threading.Tasks;
using GamesHub.DataAccess.Contracts.Models;

namespace GamesHub.DataAccess.Contracts.Repositories
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
        Task<Developer> GetByName(string name);
    }
}
