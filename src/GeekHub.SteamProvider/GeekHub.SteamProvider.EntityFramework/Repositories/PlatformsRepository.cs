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
    public class PlatformsRepository : IPlatformsRepository
    {
        private readonly SteamDbContext _dbContext;

        public PlatformsRepository(SteamDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Platform> GetAsync(Guid id)
        {
            var entity = await _dbContext.Platforms.FindAsync(id);
            
            return entity;
        }

        public async Task<IEnumerable<Platform>> GetAllAsync()
        {
            var entities = await _dbContext.Platforms.ToListAsync();
            
            return entities;
        }

        public async Task<IEnumerable<Platform>> GetManyAsync(Expression<Func<Platform, bool>> predicate)
        {
            var entities = await _dbContext.Platforms
                .Where(predicate)
                .ToListAsync();
            
            return entities;
        }

        public async Task<Platform> CreateAsync(Platform model)
        {
            var createdEntityEntry = await _dbContext.Platforms.AddAsync(model);
            var createdEntity = createdEntityEntry.Entity;

            return createdEntity;
        }

        public Platform Update(Platform model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Platform> CreateAndReturnAsync(Platform model)
        {
            var createdEntity = await _dbContext.Platforms.AddAsync(model);

            return createdEntity.Entity;
        }

        public async Task<Platform> GetByName(string name)
        {
            var entity = await _dbContext.Platforms.FirstOrDefaultAsync(d => d.Name == name);
            
            return entity;
        }
    }
}