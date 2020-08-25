namespace GamesHub.Business.Services
{
    using GamesHub.Business.Contracts.Services;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.Contracts.Repositories;
    using System;
    using System.Threading.Tasks;

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
    }
}
