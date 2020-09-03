namespace GamesHub.Business.Contracts.Services
{
    using GamesHub.DataAccess.Contracts.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGameService
    {
        Task<Game> Get(Guid id);

        Task<IEnumerable<Game>> GetAll();

        Task<IEnumerable<Game>> GetTopGames();

        Task Create(Game game);
    }
}