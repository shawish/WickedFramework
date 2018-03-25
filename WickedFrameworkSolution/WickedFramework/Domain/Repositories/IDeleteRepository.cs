namespace WickedFramework.Domain.Repositories
{
    public interface IDeleteRepository<TKey>
    {
        bool Delete(TKey id);
    }
}
