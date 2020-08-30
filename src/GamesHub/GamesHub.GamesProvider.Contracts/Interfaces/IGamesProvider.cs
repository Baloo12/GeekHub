using GamesHub.GamesProvider.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesHub.GamesProvider.Contracts.Interfaces
{
    public interface IGamesProvider
    {
        Task<IEnumerable<Game>> GetAll();

        Task<GameDetails> GetDetails(string id);
    }
}
