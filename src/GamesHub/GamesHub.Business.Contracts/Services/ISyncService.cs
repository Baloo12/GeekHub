using System.Threading.Tasks;

namespace GamesHub.Business.Contracts.Services
{
    public interface ISyncService
    {
        Task SyncGames();
    }
}
