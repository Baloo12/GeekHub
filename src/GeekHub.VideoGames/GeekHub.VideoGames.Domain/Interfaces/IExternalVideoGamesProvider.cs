using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.VideoGames.Contracts.Dtos.Steam;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;

namespace GeekHub.VideoGames.Domain.Interfaces
{
    public interface IExternalVideoGamesProvider
    {
        Task<VideoGameDto> GetDetailsAsync(Guid id);

        Task<IEnumerable<UnsynchronizedVideoGameDto>> GetUnsynchronizedAsync(int count);
        
        Task SynchronizeAsync(IEnumerable<SynchronizedVideoGameDto> videoGamesToSynchronize);
    }
}