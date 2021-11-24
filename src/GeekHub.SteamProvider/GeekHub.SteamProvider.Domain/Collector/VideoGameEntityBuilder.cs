using System;
using System.Collections.Generic;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Models.Internal;

namespace GeekHub.SteamProvider.Domain.Collector
{
    public class VideoGameEntityBuilder
    {
        private readonly VideoGame _game;

        public VideoGameEntityBuilder()
        {
            _game = new VideoGame();
        }

        public VideoGameEntityBuilder WithDetails(VideoGameDetails gameDetails)
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

        public VideoGameEntityBuilder WithSource(string steamId)
        {
            _game.SteamId = steamId;

            return this;
        }

        public VideoGameEntityBuilder WithDevelopers(List<Guid> developersIds)
        {
            // if (!developersIds.IsNullOrEmpty())
            // {
            //     var gameDevelopers = new List<GameDeveloper>();
            //     foreach (var developerId in developersIds)
            //     {
            //         gameDevelopers.Add(new GameDeveloper()
            //         {
            //             DeveloperId = developerId,
            //             GameId = _game.Id
            //         });
            //     }
            //
            //     _game.GameDevelopers = gameDevelopers;
            // }

            return this;
        }

        public VideoGame Build()
        {
            return _game;
        }
    }
}