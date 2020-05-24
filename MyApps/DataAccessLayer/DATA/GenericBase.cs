using DataAccessLayer;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Extensions;
using Entities.Paginate;

namespace BusinessLogicLayer
{
    public class GenericBase<TEntity> : IGenericBase<TEntity>where TEntity : class
    {
        protected App_Context context;
        internal DbSet<TEntity> dbSet;
        public GenericBase(App_Context db)
        {
            context = db;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            dbSet = context.Set<TEntity>();
        }
        public void DeleteElement(TEntity obj)
        {

          var o= dbSet.Remove(obj);
            context.SaveChanges();
          context.Entry(obj).State = EntityState.Detached;
        }

        public IEnumerable<TEntity> GetElements()
        {
            return dbSet.ToList();
        }
       
        public IEnumerable<TEntity> GetElements(Func<TEntity, bool> expression)
        {
          var lst= dbSet.Where(expression);
            return lst;
        }
        public IEnumerable<TEntity> SelectElements(Func<TEntity, TEntity> expression)
        {
            return dbSet.Select(expression);
        }
        public TEntity GetElementByID(Guid ObjId)
        {
            
            var Obj = dbSet.Find(ObjId);
            return Obj;
        }

        public void InsertElement(TEntity Obj)
        {
           // dbSet.Add(Obj);
            context.Attach(Obj).State = EntityState.Added;
            context.SaveChanges();
            context.Entry(Obj).State = EntityState.Detached;
        }



        public void UpdateElement(TEntity NewObj)
        {
           
            context.Attach(NewObj).State = EntityState.Modified;
            context.SaveChanges();
            context.Entry(NewObj).State = EntityState.Detached;
            context.Dispose();
        }
        public IEnumerable<TEntity> GetWithItems(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet.AsQueryable().Where(predicate);
          
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }



        public IEnumerable<TEntity> GetWithItems(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = dbSet.AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public PagedResult<TEntity> GetElements(int pageNumber, int pageSize)
        {
            var dataPage = dbSet.GetPaged(pageNumber, pageSize);
            return dataPage;
        }
    }
}
