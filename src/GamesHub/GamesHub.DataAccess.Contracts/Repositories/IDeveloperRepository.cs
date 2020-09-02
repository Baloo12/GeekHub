namespace GamesHub.DataAccess.Contracts.Repositories
{
    using GamesHub.DataAccess.Contracts.Models;
    using System.Threading.Tasks;

    public interface IDeveloperRepository : IRepository<Developer>
    {
        Task<Developer> GetByName(string name);
    }
}
