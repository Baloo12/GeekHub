﻿namespace GamesHub.DataAccess.EntityFramework.Repositories
{
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.Contracts.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class GameRepository : IGameRepository
    {
        private readonly GamesHubContext _dbContext;

        public GameRepository(GamesHubContext dbContext)
        {
            _dbContext = dbContext;
        }

        // IDEA: Move all CRUD operations to BaseRepository
        public async Task Add(Game model)
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

        public async Task<Game> Get(Guid id)
        {
            var entity = await _dbContext.Games.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            var entities = await _dbContext.Games
                .Include(g => g.GameDevelopers)
                .ThenInclude(gd => gd.Game)
                .Include(g => g.GameDevelopers)
                .ThenInclude(gd => gd.Developer)
                .ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<Game>> GetMany(Expression<Func<Game, bool>> predicate)
        {
            var entities = await _dbContext.Games.Where(predicate).ToListAsync();
            return entities;
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(Game model)
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetBySteamAppId(string steamAppId)
        {
            var entity = await _dbContext.Games.FirstOrDefaultAsync(x => x.SteamAppId.Equals(steamAppId)); // IDEA: maybe ignore culture. depends on is format
            return entity;
        }
    }
}