using System.Threading.Tasks;
using WickedFramework.Domain.Entities;

namespace WickedFramework.Domain.Repositories.Async
{
    public interface IUpdateAsyncRepository<TEntity> where TEntity : EntityBase
    {
        Task<bool> Update(TEntity entity);
    }
}
