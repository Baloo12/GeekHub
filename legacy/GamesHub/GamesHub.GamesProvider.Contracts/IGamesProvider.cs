namespace GamesHub.GamesProvider.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GamesHub.GamesProvider.Contracts.Models;

    public interface IGamesProvider
    {
        Task<IEnumerable<string>> GetAllIds();

        Task<GameDetails> GetDetails(string id);
    }
}
