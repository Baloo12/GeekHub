using System.Threading.Tasks;
using GeekHub.VideoGames.Domain.Entities;

namespace GeekHub.VideoGames.Domain.Interfaces
{
    public interface IVideoGamesRepository : IBaseRepository<VideoGame>
    {
        Task<VideoGame> GetByNameAsync(string name);
    }
}