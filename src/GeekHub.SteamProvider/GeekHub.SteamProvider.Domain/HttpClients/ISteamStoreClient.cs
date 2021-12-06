using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Models.Internal;

namespace GeekHub.SteamProvider.Domain.HttpClients
{
    public interface ISteamStoreClient
    {
        Task<SteamGameDetails> GetGameDetails(string steamId);
    }
}