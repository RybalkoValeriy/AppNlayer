using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.DAL.EF;
using App.DAL.Entities.Users;
using App.DAL.Entities;
using App.DAL.Interfaces;

namespace App.DAL.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext db;
        private DbSet<TEntity> dbSet;

        public Repository(ApplicationDataContext context)
        {
            db = context;
            dbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> M()
        {
            return new LinkedList<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public TEntity GGetId(object id)
        {
            if (id == null)
                throw new NullReferenceException();
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GGetAll()
        {

            return dbSet.AsNoTracking();
        }

        public IEnumerable<TEntity> GGet(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate);
        }

        public IQueryable<TEntity> GetInclude(params Expression<Func<TEntity, object>>[] expr)
        {
            IQueryable<TEntity> query = db.Set<TEntity>();
            expr.ToList().ForEach(x => query = query.Include(x));
            return query;
        }
    }
}