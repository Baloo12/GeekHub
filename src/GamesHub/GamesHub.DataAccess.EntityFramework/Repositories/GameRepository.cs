namespace GamesHub.DataAccess.EntityFramework.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.Contracts.Repositories;

    using Microsoft.EntityFrameworkCore;

    public class GameRepository : IRepository<Game>
    {
        private readonly GamesHubContext _dbContext;

        public GameRepository()
        {
            // TODO: Use dependency injection
            _dbContext = new GamesHubContext();
        }

        // IDEA: Move all CRUD operations to BaseRepository
        public Task Add(Game model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMany(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Game> Get(Guid id)
        {
            var entity = await _dbContext.Games.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            var entities = await _dbContext.Games.ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<Game>> GetMany(Expression<Func<Game, bool>> predicate)
        {
            var entities = await _dbContext.Games.Where(predicate).ToListAsync();
            return entities;
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(Game model)
        {
            throw new NotImplementedException();
        }
    }
}