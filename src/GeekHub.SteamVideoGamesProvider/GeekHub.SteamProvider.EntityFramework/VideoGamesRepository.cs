using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.SteamProvider.EntityFramework
{
    public class VideoGamesRepository : IVideoGamesRepository
    {
        private readonly SteamDbContext _dbContext;

        public VideoGamesRepository(SteamDbContext dbContext)
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

        public async Task CreateAsync(VideoGame model)
        {
            await _dbContext.AddAsync(model);
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

        public async Task<VideoGame> GetBySteamIdAsync(string steamId)
        {
            var entity = await _dbContext.VideoGames.FirstOrDefaultAsync(g => g.SteamId == steamId);
            
            return entity;
        }
    }
}