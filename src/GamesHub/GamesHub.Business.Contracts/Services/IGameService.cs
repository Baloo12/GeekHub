using System;
using System.Threading.Tasks;
using GamesHub.DataAccess.Contracts.Models;

namespace GamesHub.Business.Contracts.Services
{
    using System.Collections.Generic;

    public interface IGameService
    {
        Task<Game> Get(Guid id);

        Task<IEnumerable<Game>> GetAll();
    }
}
