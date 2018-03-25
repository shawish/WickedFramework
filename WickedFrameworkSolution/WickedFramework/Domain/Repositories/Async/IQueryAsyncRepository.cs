using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WickedFramework.Domain.Entities;

namespace WickedFramework.Domain.Repositories.Async
{
    public interface IQueryAsyncRepository<TEntity, TPrimaryKey, T> where TEntity : EntityBase where T : class
    {
        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetById(TPrimaryKey id);

        Task<IEnumerable<T>> GetAsync(Func<IQueryable<T>, IQueryable<T>> queryShaper, CancellationToken cancellationToken);

        Task<TResult> GetAsync<TResult>(Func<IQueryable<T>, TResult> queryShaper, CancellationToken cancellationToken);
    }
}
