using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeekHub.VideoGames.Domain.Interfaces
{
    public interface IBaseRepository<TModel>
    {
        Task<TModel> GetAsync(Guid id);
        
        Task<IEnumerable<TModel>> GetListAsync();
        
        Task<IEnumerable<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate);

        Task CreateAsync(TModel model);
        
        Task UpdateAsync(TModel model);
        
        Task DeleteAsync(Guid id);
    }
}