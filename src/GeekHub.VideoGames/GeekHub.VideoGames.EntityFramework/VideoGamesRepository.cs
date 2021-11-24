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

        public async Task<IEnumerable<VideoGame>> GetListAsync()
        {
            var entities = await _dbContext.VideoGames
                .ToListAsync();
            
            return entities;
        }

        public async Task<IEnumerable<VideoGame>> GetListAsync(Expression<Func<VideoGame, bool>> predicate)
        {
            var entities = await _dbContext.VideoGames.Where(predicate).ToListAsync();
            
            return entities;
        }

        public async Task CreateAsync(VideoGame model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(VideoGame model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}