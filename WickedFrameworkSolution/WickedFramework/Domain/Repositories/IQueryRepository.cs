using System;
using System.Linq;
using System.Linq.Expressions;
using WickedFramework.Domain.Entities;
using WickedFramework.Enums;

namespace WickedFramework.Domain.Repositories
{
    public interface IQueryRepository<TEntity, TPrimaryKey> where TEntity : EntityBase
    {
        int Count();

        int Count(Expression<Func<TEntity, bool>> predicate);

        TEntity GetById(TPrimaryKey id);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include);

        IQueryable<TEntity> Page<TSortType>(Expression<Func<TEntity, bool>> predicate,
                                            int pageIndex,
                                            int pageSize,
                                            Expression<Func<TEntity, TSortType>> orderByProperty,
                                            SortOrder sortOrder,
                                            out int rowCount);

        IQueryable<TEntity> Page<TSortType, TThenSortType>(Expression<Func<TEntity, bool>> predicate,
                                                           int pageIndex,
                                                           int pageSize,
                                                           Expression<Func<TEntity, TSortType>> orderByProperty,
                                                           SortOrder sortOrder,
                                                           Expression<Func<TEntity, 
                                                           TThenSortType>> thenByProperty,
                                                           SortOrder thenSortOrder, 
                                                           out int rowCount);

        IQueryable<TEntity> Page<TSortType, TThenSortType>(Expression<Func<TEntity, bool>> predicate, int pageIndex,
                                                           int pageSize,
                                                           Expression<Func<TEntity, 
                                                           TSortType>> orderByProperty,
                                                           SortOrder sortOrder,
                                                           Expression<Func<TEntity, TThenSortType>> thenByProperty,
                                                           SortOrder thenSortOrder,
                                                           out int rowCount,
                                                           params Expression<Func<TEntity, object>>[] include);

        IQueryable<TEntity> Page<TSortType>(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize,
                                            Expression<Func<TEntity, TSortType>> orderByProperty,
                                            SortOrder sortOrder, 
                                            out int rowCount,
                                            params Expression<Func<TEntity, object>>[] include);
    }
}
