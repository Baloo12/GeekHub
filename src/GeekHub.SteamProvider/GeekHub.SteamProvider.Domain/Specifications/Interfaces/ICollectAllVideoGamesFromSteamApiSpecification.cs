using System.Threading.Tasks;

namespace GeekHub.SteamProvider.Domain.Specifications.Interfaces
{
    public interface ICollectAllVideoGamesFromSteamApiSpecification
    {
        Task ExecuteAsync();
    }
}