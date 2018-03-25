using WickedFramework.Domain.Entities;

namespace WickedFramework.Domain.Repositories
{
    public interface IUpdateRepository<TEntity> where TEntity : EntityBase
    {
        bool Update(TEntity entity);
    }
}
