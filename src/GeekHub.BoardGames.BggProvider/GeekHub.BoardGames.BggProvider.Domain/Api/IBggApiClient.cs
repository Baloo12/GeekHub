namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public interface IBggApiClient
    {
        Task<BoardGame> GetGameAsync(RequestGameParameters parameters);

        Task<PlayRecordsResponse> GetPlayRecordsAsync(RequestPlaysParameters parameters);
    }

    public class PlayRecordsResponse
    {
        public int PageNumber { get; set; }

        public IEnumerable<PlayRecord> Plays { get; set; }

        public int TotalPlays { get; set; }
    }
}
