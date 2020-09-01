namespace GamesHub.Business.Services
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Timers;

    using GamesHub.Business.Contracts;
    using GamesHub.Business.Contracts.Services;
    using GamesHub.GamesProvider.Contracts;

    public class SyncService : ISyncService
    {
        private readonly IGameBuilder _gameBuilder;

        private readonly IGameService _gameService;

        private readonly IEnumerable<IGamesProvider> _gamesProviders;

        public SyncService(
            IEnumerable<IGamesProvider> steamGamesProviders,
            IGameService gameService,
            IGameBuilder gameBuilder)
        {
            _gamesProviders = steamGamesProviders;
            _gameService = gameService;
            _gameBuilder = gameBuilder;
        }

        public async Task SyncGames()
        {
            foreach (var gamesProvider in _gamesProviders)
            {
                var gameIds = await gamesProvider.GetAllIds();

                foreach (var gameId in gameIds)
                {
                    var gameDetails = await gamesProvider.GetDetails(gameId);
                    if (gameDetails != null)
                    {
                        var game = _gameBuilder.Build(gameDetails, gameId);
                        await _gameService.Create(game);
                    }
                }
            }
        }
    }
}