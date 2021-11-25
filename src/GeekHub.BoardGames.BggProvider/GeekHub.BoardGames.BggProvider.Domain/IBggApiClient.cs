namespace GeekHub.BoardGames.BggProvider.Domain
{
    using System.Threading.Tasks;

    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public interface IBggApiClient
    {
        Task<BoardGame> GetGameAsync(int bggId);
    }
}
