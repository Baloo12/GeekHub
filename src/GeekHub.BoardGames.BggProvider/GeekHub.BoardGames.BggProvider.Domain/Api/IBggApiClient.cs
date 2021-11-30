namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System.Threading.Tasks;

    public interface IBggApiClient
    {
        Task<string> GetGameContentAsync(int bggId);
    }
}
