namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public interface IBggApiClient
    {
        Task<BoardGame> GetGameAsync(RequestGameParameters parameters);

        Task<IEnumerable<PlayRecord>> GetPlayRecordsAsync(RequestPlaysParameters parameters);
    }
}
