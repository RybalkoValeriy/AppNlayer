using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.DAL.Entities;
using App.DAL.Entities.Users;

namespace App.DAL.Interfaces
{
    public interface IRepository<TEntity> 
    {
        void Add(TEntity entity);
        TEntity GGetId(object id);
        IEnumerable<TEntity> GGetAll();
        IEnumerable<TEntity> GGet(Func<TEntity, bool> predicate);
        IQueryable<TEntity> GetInclude(params Expression<Func<TEntity, object>>[] expr);
    }
}
