﻿using System.Threading.Tasks;
using GeekHub.VideoGames.Contracts.Dtos.Steam;

namespace GeekHub.SteamProvider.Domain.Provider
{
    public interface IVideoGamesProvider
    {
        public Task<VideoGameDto> Get(string steamId);
    }
}