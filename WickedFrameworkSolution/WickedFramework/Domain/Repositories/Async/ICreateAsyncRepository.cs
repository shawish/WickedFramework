using System.Threading.Tasks;
using WickedFramework.Domain.Entities;

namespace WickedFramework.Domain.Repositories.Async
{
    public interface ICreateAsyncRepository<TEntity, TResult> where TEntity : EntityBase
    {
        Task<TResult> Create(TEntity entity);
    }
}
