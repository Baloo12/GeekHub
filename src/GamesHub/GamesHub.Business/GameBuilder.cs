using System;
using GamesHub.Common.Extensions;

namespace GamesHub.Business
{
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.GamesProvider.Contracts.Models;
    using System.Collections.Generic;

    public class GameBuilder
    {
        private readonly Game _game;

        public GameBuilder()
        {
            _game = new Game();
        }

        public GameBuilder WithDetails(GameDetails gameDetails)
        {
            _game.Name = gameDetails.Name;
            _game.Description = gameDetails.Description;
            _game.Image = gameDetails.Image;
            _game.ReleaseDate = gameDetails.ReleaseDate;
            _game.Type = gameDetails.Type;
            _game.RequiredAge = gameDetails.RequiredAge;
            _game.IsFree = gameDetails.IsFree;
            _game.Website = gameDetails.Website;

            return this;
        }

        public GameBuilder WithSource(GameSource source, string sourceEntityId)
        {
            switch (source)
            {
                case GameSource.Steam:
                    _game.SteamAppId = sourceEntityId;
                    break;
                default:
                    break;
            }

            return this;
        }

        public GameBuilder WithDevelopers(List<Guid> developersIds)
        {
            if (!developersIds.IsNullOrEmpty())
            {
                var gameDevelopers = new List<GameDeveloper>();
                foreach (var developerId in developersIds)
                {
                    gameDevelopers.Add(new GameDeveloper()
                    {
                        DeveloperId = developerId,
                        GameId = _game.Id
                    });
                }

                _game.GameDevelopers = gameDevelopers;
            }

            return this;
        }

        public Game Build()
        {
            return _game;
        }
    }
}