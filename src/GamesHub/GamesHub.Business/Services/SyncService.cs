using GamesHub.DataAccess.Contracts.Models;
using GamesHub.GamesProvider.Contracts.Models;

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
        private readonly IDeveloperService _developerService;

        private readonly IEnumerable<IGamesProvider> _gamesProviders;

        public SyncService(
            IEnumerable<IGamesProvider> steamGamesProviders,
            IGameService gameService,
            IDeveloperService developerService,
            IGameBuilder gameBuilder)
        {
            _gamesProviders = steamGamesProviders;
            _gameService = gameService;
            _developerService = developerService;
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
                        await UpdateGameDevelopers(gameDetails, game);
                        await _gameService.Create(game);
                    }
                }
            }
        }

        private async Task UpdateGameDevelopers(GameDetails gameDetails, Game game)
        {
            var gameDevelopers = new List<GameDeveloper>();
            foreach (var developerName in gameDetails.Developers)
            {
                var developer = new Developer()
                {
                    Name = developerName
                };

                await _developerService.Create(developer);
                var developerId = await _developerService.GetIdByName(developerName);
                gameDevelopers.Add(new GameDeveloper()
                {
                    DeveloperId = developerId,
                    GameId = game.Id
                });
            }

            game.GameDevelopers = gameDevelopers;
        }
    }
}