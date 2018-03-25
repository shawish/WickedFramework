using System;

namespace WickedFramework.Domain.Entities
{
    [Serializable]
    public abstract class EntityBase : EntityBase<int>, IEntityBase
    {

    }

    [Serializable]
    public abstract class EntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }

    }
}
