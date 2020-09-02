using GamesHub.DataAccess.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesHub.Business.Contracts.Services
{
    public interface IDeveloperService
    {
        Task Create(Developer developer);
        
        Task<Guid> GetIdByName(string name);

        Task<IEnumerable<Developer>> GetAll();
    }
}
