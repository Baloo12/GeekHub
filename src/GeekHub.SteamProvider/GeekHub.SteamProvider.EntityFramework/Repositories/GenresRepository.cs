using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.SteamProvider.EntityFramework.Repositories
{
    public class GenresRepository : IGenresRepository
    {
        private readonly SteamDbContext _dbContext;

        public GenresRepository(SteamDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Genre> GetAsync(Guid id)
        {
            var entity = await _dbContext.Genres.FindAsync(id);
            
            return entity;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            var entities = await _dbContext.Genres.ToListAsync();
            
            return entities;
        }

        public async Task<IEnumerable<Genre>> GetManyAsync(Expression<Func<Genre, bool>> predicate)
        {
            var entities = await _dbContext.Genres
                .Where(predicate)
                .ToListAsync();
            
            return entities;
        }

        public async Task CreateAsync(Genre model)
        {
            await _dbContext.Genres.AddAsync(model);
        }

        public async Task CreateAsync(IEnumerable<Genre> models)
        {
            await _dbContext.Genres.AddRangeAsync(models);
        }

        public void Update(Genre model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Genre> CreateAndReturnAsync(Genre model)
        {
            var createdEntity = await _dbContext.Genres.AddAsync(model);

            return createdEntity.Entity;
        }

        public async Task<Genre> GetByName(string name)
        {
            var entity = await _dbContext.Genres.FirstOrDefaultAsync(d => d.Name == name);
            
            return entity;
        }
    }
}