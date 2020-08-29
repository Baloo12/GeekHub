namespace GamesHub.Business.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GamesHub.Business.Contracts.Services;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.Contracts.Repositories;

    public class GameService : IGameService
    {
        private readonly IRepository<Game> _gameRepository;

        public GameService(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
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
    }
}