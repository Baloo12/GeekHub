using System;
using System.Threading.Tasks;
using GamesHub.DataAccess.Contracts.Models;

namespace GamesHub.Business.Contracts.Services
{
    public interface IGameService
    {
        Task<Game> Get(Guid id);
    }
}
