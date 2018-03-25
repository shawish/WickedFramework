using System.Threading.Tasks;

namespace WickedFramework.Domain.Repositories.Async
{
    public interface IDeleteAsyncRepository<TKey>
    {
        Task<bool> Delete(TKey id);
    }
}
