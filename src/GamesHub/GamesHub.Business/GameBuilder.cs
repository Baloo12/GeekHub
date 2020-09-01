namespace GamesHub.Business
{
    using GamesHub.Business.Contracts;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.GamesProvider.Contracts.Models;

    public class GameBuilder : IGameBuilder
    {
        public Game Build(GameDetails gameDetails, string sourceEntityId)
        {
            var game = new Game() { Name = gameDetails.Name };

            switch (gameDetails.Source)
            {
                case GameSource.Steam:
                    game.SteamAppId = sourceEntityId;
                    break;
                default:
                    break;
            }

            return game;
        }
    }
}