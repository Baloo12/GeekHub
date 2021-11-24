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
    public class PublishersRepository : IPublishersRepository
    {
        private readonly SteamDbContext _dbContext;

        public PublishersRepository(SteamDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Publisher> GetAsync(Guid id)
        {
            var entity = await _dbContext.Publishers.FindAsync(id);
            
            return entity;
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            var entities = await _dbContext.Publishers.ToListAsync();
            
            return entities;
        }

        public async Task<IEnumerable<Publisher>> GetManyAsync(Expression<Func<Publisher, bool>> predicate)
        {
            var entities = await _dbContext.Publishers
                .Where(predicate)
                .ToListAsync();
            
            return entities;
        }

        public async Task CreateAsync(Publisher model)
        {
            await _dbContext.Publishers.AddAsync(model);
        }

        public async Task CreateAsync(IEnumerable<Publisher> models)
        {
            await _dbContext.Publishers.AddRangeAsync(models);
        }

        public void Update(Publisher model)
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

        public async Task<Publisher> CreateAndReturnAsync(Publisher model)
        {
            var createdEntity = await _dbContext.Publishers.AddAsync(model);

            return createdEntity.Entity;
        }

        public async Task<Publisher> GetByName(string name)
        {
            var entity = await _dbContext.Publishers.FirstOrDefaultAsync(d => d.Name == name);
            
            return entity;
        }
    }
}