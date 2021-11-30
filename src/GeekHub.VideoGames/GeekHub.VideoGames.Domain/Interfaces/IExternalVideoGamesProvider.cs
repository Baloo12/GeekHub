using System.Threading.Tasks;
using GeekHub.VideoGames.Contracts.Dtos.Steam;

namespace GeekHub.VideoGames.Domain.Interfaces
{
    public interface IExternalVideoGamesProvider
    {
        Task<VideoGameDto> GetDetails(string externalId); // Idea: use common Guid Id, get rid of external ids at all
    }
}