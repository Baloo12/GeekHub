using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GeekHub.VideoGames.Domain.Entities;
using GeekHub.VideoGames.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.VideoGames.EntityFramework
{
    public class VideoGamesRepository : IVideoGamesRepository
    {
        private readonly VideoGamesDbContext _dbContext;

        public VideoGamesRepository(VideoGamesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<VideoGame> GetAsync(Guid id)
        {
            var entity = await _dbContext.VideoGames.FindAsync(id);
            
            return entity;
        }

        public async Task<IEnumerable<VideoGame>> GetAllAsync()
        {
            var entities = await _dbContext.VideoGames.ToListAsync();
            
            return entities;
        }

        public async Task<IEnumerable<VideoGame>> GetManyAsync(Expression<Func<VideoGame, bool>> predicate)
        {
            var entities = await _dbContext.VideoGames
                .Where(predicate)
                .ToListAsync();
            
            return entities;
        }

        public async Task<VideoGame> CreateAsync(VideoGame model)
        {
            var createdEntityEntry = await _dbContext.AddAsync(model);
            var createdEntity = createdEntityEntry.Entity;

            return createdEntity;
        }

        public Task UpdateAsync(VideoGame model)
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

        public async Task<VideoGame> GetByNameAsync(string name)
        {
            var entity = await _dbContext.VideoGames.FirstOrDefaultAsync(g => g.Name == name);
            
            return entity;
        }
    }
}