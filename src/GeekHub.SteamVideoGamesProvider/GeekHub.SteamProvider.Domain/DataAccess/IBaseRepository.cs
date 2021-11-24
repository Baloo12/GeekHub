using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeekHub.SteamProvider.Domain.DataAccess
{
    public interface IBaseRepository<TModel>
    {
        Task<TModel> GetAsync(Guid id);
        
        Task<IEnumerable<TModel>> GetAllAsync();
        
        Task<IEnumerable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> predicate);

        Task CreateAsync(TModel model);
        
        Task UpdateAsync(TModel model);
        
        Task DeleteAsync(Guid id);

        Task SaveChangesAsync();
    }
}