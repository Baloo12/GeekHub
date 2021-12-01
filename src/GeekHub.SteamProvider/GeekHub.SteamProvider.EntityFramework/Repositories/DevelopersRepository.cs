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
    public class DevelopersRepository : IDevelopersRepository
    {
        private readonly SteamDbContext _dbContext;

        public DevelopersRepository(SteamDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Developer> GetAsync(Guid id)
        {
            var entity = await _dbContext.Developers.FindAsync(id);
            
            return entity;
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            var entities = await _dbContext.Developers.ToListAsync();
            
            return entities;
        }

        public async Task<IEnumerable<Developer>> GetManyAsync(Expression<Func<Developer, bool>> predicate)
        {
            var entities = await _dbContext.Developers
                .Where(predicate)
                .ToListAsync();
            
            return entities;
        }

        public async Task<Developer> CreateAsync(Developer model)
        {
            var createdEntityEntry = await _dbContext.Developers.AddAsync(model);
            var createdEntity = createdEntityEntry.Entity;

            return createdEntity;
        }

        public Developer Update(Developer model)
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

        public async Task<Developer> CreateAndReturnAsync(Developer model)
        {
            var createdEntity = await _dbContext.Developers.AddAsync(model);

            return createdEntity.Entity;
        }

        public async Task<Developer> GetByName(string name)
        {
            var entity = await _dbContext.Developers.FirstOrDefaultAsync(d => d.Name == name);
            
            return entity;
        }
    }
}