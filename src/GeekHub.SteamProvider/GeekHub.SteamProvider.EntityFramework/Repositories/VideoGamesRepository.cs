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
            await _dbContext.VideoGames.AddAsync(model);
        }

        public async Task CreateAsync(IEnumerable<VideoGame> models)
        {
            await _dbContext.VideoGames.AddRangeAsync(models);
        }

        public void Update(VideoGame model)
        {
            _dbContext.VideoGames.Update(model);
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
            var entity = await _dbContext.VideoGames
                .Where(g => g.SteamId == steamId)
                .Include(g => g.Developers)
                .Include(g => g.Genres)
                .Include(g => g.Publishers)
                .Include(g => g.Platforms)
                .FirstOrDefaultAsync();
            
            return entity;
        }

        public async Task<IEnumerable<string>> GetAllSteamIdsAsync()
        {
            var entity = await _dbContext.VideoGames
                .Select(g => g.SteamId)
                .ToListAsync();
            
            return entity;
        }
    }
}