using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAcess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(String Id);

        IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null
            );

        TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null
            );

        void Add(TEntity dto);
        void Remove(TEntity dto);
        void Remove(String id);
        void RemoveRange(IEnumerable<TEntity> dto);
    }
}
