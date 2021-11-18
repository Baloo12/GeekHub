namespace GamesHub.DataAccess.Contracts.Repositories
{
    using GamesHub.DataAccess.Contracts.Models;
    using System.Threading.Tasks;

    public interface IGameRepository : IRepository<Game>
    {
        Task<Game> GetBySteamAppId(string steamAppId);
    }
}