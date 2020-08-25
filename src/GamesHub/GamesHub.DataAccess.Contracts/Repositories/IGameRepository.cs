namespace GamesHub.DataAccess.Contracts.Repositories
{
    using GamesHub.DataAccess.Contracts.Models;

    // IDEA: maybe leave only one generic repo and create concrete repos when needed.
    public interface IGameRepository<TEntity> : IRepository<Game, TEntity>
    {
    }
}