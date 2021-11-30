namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System.Threading.Tasks;

    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;

    public interface IBggApiClient
    {
        Task<string> GetGameContentAsync(RequestGameParameters requestParameters);
    }
}
