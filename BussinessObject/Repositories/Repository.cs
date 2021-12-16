using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessObject.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly QuizDatabaseContext _dbContext;
        internal DbSet<TEntity> dbSet;

        public Repository(QuizDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity dto)
        {
            dbSet.Add(dto);
        }

        public TEntity Get(string Id)
        {
            return dbSet.Find(Id);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includedProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includedProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;

        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includedProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includedProp);
                }
            }

            return query.FirstOrDefault();

        }

        public void Remove(TEntity dto)
        {
            dbSet.Remove(dto);
        }

        public void Remove(string id)
        {
            TEntity deletedDto = dbSet.Find(id);
            if (deletedDto != null)
            {
                dbSet.Remove(deletedDto);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> dto)
        {
            dbSet.RemoveRange(dto);
        }
    }
}
