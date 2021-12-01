using System;
using System.Threading.Tasks;
using GeekHub.VideoGames.Contracts.Dtos.Steam;

namespace GeekHub.VideoGames.Domain.Interfaces
{
    public interface IExternalVideoGamesProvider
    {
        Task<VideoGameDto> GetDetails(Guid id);
    }
}