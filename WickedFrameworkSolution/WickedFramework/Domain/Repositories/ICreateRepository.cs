using WickedFramework.Domain.Entities;

namespace WickedFramework.Domain.Repositories
{
    public interface ICreateRepository<TEntity, TResult> where TEntity : EntityBase
    {
        TResult Create(TEntity entity);
    }
}
