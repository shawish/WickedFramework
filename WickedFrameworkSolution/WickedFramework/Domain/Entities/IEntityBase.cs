namespace WickedFramework.Domain.Entities
{
    public interface IEntityBase<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
