using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeekHub.Common.DataAccess
{
    public interface IBaseRepository<TModel>
    {
        Task<TModel> GetAsync(Guid id);
        
        Task<IEnumerable<TModel>> GetAllAsync();
        
        Task<IEnumerable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> predicate);

        Task<TModel> CreateAsync(TModel model);
        
        TModel Update(TModel model);
        
        void Delete(Guid id);

        Task SaveChangesAsync();
    }
}