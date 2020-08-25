namespace GamesHub.DataAccess.Contracts.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<TModel, TEntity>
    {
        // IDEA: Combine into AddOrUpdate method
        Task Add(TModel model);

        Task Delete(Guid id);

        Task DeleteMany(IEnumerable<Guid> ids);

        Task<bool> Exists(Guid id);

        Task<TModel> Get(Guid id);

        Task<IEnumerable<TModel>> GetAll();

        Task<IEnumerable<TModel>> GetMany(Expression<Func<TEntity, bool>> predicate);

        // IDEA: Combine into AddOrUpdate method
        Task Update(TModel model);
    }
}