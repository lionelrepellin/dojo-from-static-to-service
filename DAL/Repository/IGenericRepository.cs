using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public interface IGenericRepository<TEntity> 
        where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        TEntity FindById(object id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        void Update(TEntity entityToUpdate);
    }
}