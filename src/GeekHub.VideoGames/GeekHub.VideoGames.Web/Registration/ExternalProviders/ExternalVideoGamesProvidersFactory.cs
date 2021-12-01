﻿using System;
using System.Collections.Generic;
using System.Linq;
using GeekHub.VideoGames.Domain.ExternalProviders;
using GeekHub.VideoGames.Domain.Interfaces;
using GeekHub.VideoGames.SteamAdapter;

namespace GeekHub.VideoGames.Web.Registration.ExternalProviders
{
    public class ExternalVideoGamesProvidersFactory : IExternalVideoGamesProvidersFactory
    {
        private readonly IEnumerable<IExternalVideoGamesProvider> _videoGamesProviders;

        public ExternalVideoGamesProvidersFactory(IEnumerable<IExternalVideoGamesProvider> videoGamesProviders)
        {
            _videoGamesProviders = videoGamesProviders;
        }
        public IExternalVideoGamesProvider ResolveProvider(string source)
        {
            switch (source.ToLower())
            {
                case "steam":
                    return _videoGamesProviders.FirstOrDefault(p =>
                        p.GetType() == typeof(SteamVideoGamesProvider));
                default:
                    throw new NotImplementedException("External provider not exists");
            }
        }
    }
}