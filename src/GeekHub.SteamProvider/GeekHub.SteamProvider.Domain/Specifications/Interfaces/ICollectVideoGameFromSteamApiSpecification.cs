using System.Threading.Tasks;

namespace GeekHub.SteamProvider.Domain.Specifications.Interfaces
{
    public interface ICollectVideoGameFromSteamApiSpecification
    {
        Task ExecuteAsync(string steamId);
    }
}