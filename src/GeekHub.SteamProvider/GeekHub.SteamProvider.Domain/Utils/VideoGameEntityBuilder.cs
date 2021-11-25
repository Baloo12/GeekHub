using System;
using System.Collections.Generic;
using GeekHub.Common.Extensions;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Models.Internal;
using Genre = GeekHub.SteamProvider.Domain.Entities.Genre;

namespace GeekHub.SteamProvider.Domain.Utils
{
    public class VideoGameEntityBuilder
    {
        private readonly VideoGame _game;
        
        public VideoGameEntityBuilder(VideoGame game)
        {
            _game = game;
        }

        public VideoGameEntityBuilder()
        {
            _game = new VideoGame();
        }

        public VideoGameEntityBuilder WithDetails(GameDetailsData details)
        {
            _game.Name = details.Name;
            _game.Description = details.ShortDescription;
            _game.Image = details.Image;
            _game.ReleaseDate = details.ReleaseDate?.Date ?? "Coming Soon";
            _game.Type = details.Type;
            _game.RequiredAge = details.RequiredAge;
            _game.IsFree = details.IsFree;
            _game.Website = details.Website;

            return this;
        }

        public VideoGameEntityBuilder WithSourceId(string steamId)
        {
            _game.SteamId = steamId;

            return this;
        }

        public VideoGameEntityBuilder WithDevelopers(List<Developer> developers)
        {
            if (!developers.IsNullOrEmpty())
            {
                _game.Developers = developers;
            }

            return this;
        }
        
        public VideoGameEntityBuilder WithPublishers(List<Publisher> publishers)
        {
            if (!publishers.IsNullOrEmpty())
            {
                _game.Publishers = publishers;
            }

            return this;
        }
        
        public VideoGameEntityBuilder WithGenres(List<Genre> genres)
        {
            if (!genres.IsNullOrEmpty())
            {
                _game.Genres = genres;
            }

            return this;
        }
        
        public VideoGameEntityBuilder WithPlatforms(List<Platform> platforms)
        {
            if (!platforms.IsNullOrEmpty())
            {
                _game.Platforms = platforms;
            }

            return this;
        }

        public VideoGame Build()
        {
            _game.ModifiedAt = DateTime.Now;
            
            return _game;
        }
    }
}