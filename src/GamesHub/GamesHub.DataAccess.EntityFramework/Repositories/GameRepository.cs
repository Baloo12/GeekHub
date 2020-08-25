namespace GamesHub.DataAccess.EntityFramework.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using AutoMapper;

    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.Contracts.Repositories;
    using GamesHub.DataAccess.EntityFramework.Entities;
    using GamesHub.DataAccess.EntityFramework.Mapping;

    using Microsoft.EntityFrameworkCore;

    public class GameRepository : IRepository<Game, GameEntity>
    {
        private readonly GamesHubContext _dbContext;

        private readonly IMapper _mapper;

        public GameRepository()
        {
            // TODO: Use dependency injection
            _dbContext = new GamesHubContext();
            _mapper = MappingBuidler.CreateMapper();
        }

        // IDEA: Move all CRUD operations to BaseRepository
        public Task Add(Game model)
        {
            throw new NotImplementedException();
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
            var model = _mapper.Map<Game>(entity);
            return model;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            var entities = await _dbContext.Games.ToListAsync();
            var models = _mapper.Map<IEnumerable<Game>>(entities);
            return models;
        }

        public async Task<IEnumerable<Game>> GetMany(Expression<Func<GameEntity, bool>> predicate)
        {
            var entities = await _dbContext.Games.Where(predicate).ToListAsync();
            var models = _mapper.Map<IEnumerable<Game>>(entities);
            return models;
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(Game model)
        {
            throw new NotImplementedException();
        }
    }
}