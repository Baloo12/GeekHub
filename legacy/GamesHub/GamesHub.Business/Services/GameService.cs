﻿namespace GamesHub.Business.Services
{
    using GamesHub.Business.Contracts.Services;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.Contracts.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task Create(Game game)
        {
            var gameExists = await CheckSteam(game);

            if (gameExists == false)
            {
                game.Rank = new Rank();
                await _gameRepository.Add(game);
            }
        }

        public async Task<Game> Get(Guid id)
        {
            return await _gameRepository.Get(id);
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _gameRepository.GetAll();
        }

        public async Task<IEnumerable<Game>> GetTopGames()
        {
            var allGames = await _gameRepository.GetAll();
            return allGames.OrderBy(x => x.Rank.Overall);
        }

        private async Task<bool> CheckSteam(Game game)
        {
            var entity = await _gameRepository.GetBySteamAppId(game.SteamAppId);
            if (entity != null)
            {
                // TODO: Merge with existing data. For now just ignore
            }

            return entity != null;
        }
    }
}