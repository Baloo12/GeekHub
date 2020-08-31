namespace GamesHub.Business.Services
{
    using System.Threading.Tasks;

    using GamesHub.Business.Contracts.Services;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.GamesProvider.Contracts.Interfaces;

    public class SyncService : ISyncService
    {
        private readonly IGameService _gameService;

        private readonly ISteamGamesProvider _steamGamesProvider;

        public SyncService(ISteamGamesProvider steamGamesProvider, IGameService gameService)
        {
            _steamGamesProvider = steamGamesProvider;
            _gameService = gameService;
        }

        public async Task SyncGames()
        {
            var games = await _steamGamesProvider.GetAll();
            foreach (var game in games)
            {
                var gamesDetails = await _steamGamesProvider.GetDetails(game.Id);
                if (gamesDetails != null)
                    await _gameService.Create(new Game { Name = gamesDetails.Name });
            }
        }
    }
}