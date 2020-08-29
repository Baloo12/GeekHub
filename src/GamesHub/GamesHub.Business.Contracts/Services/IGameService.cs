namespace GamesHub.Business.Contracts.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GamesHub.DataAccess.Contracts.Models;

    public interface IGameService
    {
        Task<Game> Get(Guid id);

        Task<IEnumerable<Game>> GetAll();

        Task<IEnumerable<Game>> GetTopGames();
    }
}