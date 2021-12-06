using System.Collections.Generic;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Models.Internal;
using Genre = GeekHub.SteamProvider.Domain.Entities.Genre;

namespace GeekHub.SteamProvider.Domain.Utils
{
    public interface IVideoGameEntityBuilder
    {
        IVideoGameEntityBuilder WithDetails(GameDetailsData details);

        IVideoGameEntityBuilder WithSourceId(string steamId);

        IVideoGameEntityBuilder WithDevelopers(List<Developer> developers);

        IVideoGameEntityBuilder WithPublishers(List<Publisher> publishers);

        IVideoGameEntityBuilder WithGenres(List<Genre> genres);

        IVideoGameEntityBuilder WithPlatforms(List<Platform> platforms);

        VideoGame Build();
    }
}