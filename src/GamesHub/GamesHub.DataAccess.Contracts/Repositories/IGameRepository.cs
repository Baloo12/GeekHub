namespace GamesHub.DataAccess.Contracts.Repositories
{
    using System.Threading.Tasks;

    using GamesHub.DataAccess.Contracts.Models;

    public interface IGameRepository : IRepository<Game>
    {
        Task<Game> GetBySteamAppId(string steamAppId);
    }
}