namespace GamesHub.Business
{
    using GamesHub.Business.Contracts;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.GamesProvider.Contracts.Models;

    public class GameBuilder : IGameBuilder
    {
        public Game Build(GameDetails gameDetails, string sourceEntityId)
        {
            var game = new Game()
            {
                Name = gameDetails.Name,
                Description = gameDetails.Description,
                Image = gameDetails.Image,
                ReleaseDate = gameDetails.ReleaseDate,
                Type = gameDetails.Type,
                RequiredAge = gameDetails.RequiredAge,
                IsFree = gameDetails.IsFree,
                Website = gameDetails.Website
            };

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