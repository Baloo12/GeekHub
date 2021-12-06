using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Models.Internal;

namespace GeekHub.SteamProvider.Domain.HttpClients
{
    public interface ISteamApiClient
    {
        Task<SteamGames> GetAllGames();
    }
}