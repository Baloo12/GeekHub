using GamesHub.Business.Contracts.Services;
using GamesHub.DataAccess.Contracts.Models;
using GamesHub.GamesProvider.Contracts.Interfaces;
using System.Threading.Tasks;

namespace GamesHub.Business.Services
{
    public class SyncService : ISyncService
    {
        private readonly IGamesProvider _gamesProvider;
        private readonly IGameService _gameService;

        public SyncService(IGamesProvider gamesProvider, IGameService gameService)
        {
            _gamesProvider = gamesProvider;
            _gameService = gameService;
        }
        public async Task SyncGames()
        {
            var games = await _gamesProvider.GetAll();
            foreach (var game in games)
            {
                var gamesDetails = await _gamesProvider.GetDetails(game.Id);
                if (gamesDetails != null)
                {
                    await _gameService.Create(new Game()
                    {
                        Name = gamesDetails.Name
                    });
                }
            }
        }
    }
}
