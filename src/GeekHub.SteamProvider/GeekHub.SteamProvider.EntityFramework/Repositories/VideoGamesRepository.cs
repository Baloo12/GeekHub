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
        
        public async Task<IEnumerable<VideoGame>> GetManyAsync(Expression<Func<VideoGame, bool>> predicate, int count)
        {
            var entities = await _dbContext.VideoGames
                .Where(predicate)
                .Take(count)
                .ToListAsync();
            
            return entities;
        }

        public async Task<VideoGame> CreateAsync(VideoGame model)
        {
            var createdEntityEntry = await _dbContext.VideoGames.AddAsync(model);
            var createdEntity = createdEntityEntry.Entity;

            return createdEntity;
        }

        public async Task CreateAsync(IEnumerable<VideoGame> models)
        {
            await _dbContext.VideoGames.AddRangeAsync(models);
        }

        public VideoGame Update(VideoGame model)
        {
            var updatedEntityEntry = _dbContext.VideoGames.Update(model);
            var updatedEntity = updatedEntityEntry.Entity;

            return updatedEntity;
        }

        public void Delete(Guid id)
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

        public async Task<VideoGame> GetByGeekHubIdAsync(Guid geekHubId)
        {
            var entity = await _dbContext.VideoGames
                .Where(g => g.GeekHubId == geekHubId)
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