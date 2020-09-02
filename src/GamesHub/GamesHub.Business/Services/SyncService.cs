namespace GamesHub.Business.Services
{
    using GamesHub.Business.Contracts.Services;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.GamesProvider.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SyncService : ISyncService
    {
        private readonly IGameService _gameService;
        private readonly IDeveloperService _developerService;
        private readonly IEnumerable<IGamesProvider> _gamesProviders;

        public SyncService(
            IEnumerable<IGamesProvider> steamGamesProviders,
            IGameService gameService,
            IDeveloperService developerService)
        {
            _gamesProviders = steamGamesProviders;
            _gameService = gameService;
            _developerService = developerService;
        }

        public async Task SyncGames()
        {
            foreach (var gamesProvider in _gamesProviders)
            {
                var gameIds = await gamesProvider.GetAllIds();

                foreach (var gameId in gameIds)
                {
                    var gameDetails = await gamesProvider.GetDetails(gameId);
                    var developersIds = await GetDeveloperEntitiesIds(gameDetails.Developers);

                    if (gameDetails != null)
                    {
                        var game = new GameBuilder()
                            .WithDetails(gameDetails)
                            .WithSource(gameDetails.Source, gameId)
                            .WithDevelopers(developersIds)
                            .Build();
                        await _gameService.Create(game);
                    }
                }
            }
        }

        private async Task<List<Guid>> GetDeveloperEntitiesIds(List<string> developers)
        {
            var developersIds = new List<Guid>();

            foreach (var developerName in developers)
            {
                var isDeveloperExist = await _developerService.IsExistWithName(developerName);

                if (!isDeveloperExist)
                {
                    var developer = new Developer()
                    {
                        Name = developerName
                    };

                    await _developerService.Create(developer);
                }

                var developerId = await _developerService.GetIdByName(developerName);

                developersIds.Add(developerId);
            }

            return developersIds;
        }
    }
}