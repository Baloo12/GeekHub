namespace GamesHub.DataAccess.EntityFramework.Repositories
{
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.Contracts.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly GamesHubContext _dbContext;

        public DeveloperRepository(GamesHubContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Developer model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
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

        public Task<Developer> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            var developers = await _dbContext.Developers
                .Include(d => d.GameDevelopers)
                .ThenInclude(gd => gd.Developer)
                .Include(d => d.GameDevelopers)
                .ThenInclude(gd => gd.Game)
                .ToListAsync();
            return developers;
        }

        public Task<IEnumerable<Developer>> GetMany(Expression<Func<Developer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Update(Developer model)
        {
            throw new NotImplementedException();
        }

        public async Task<Developer> GetByName(string name)
        {
            var developer = await _dbContext.Developers.FirstOrDefaultAsync(d => d.Name == name);
            return developer;
        }
    }
}
