using DataAccessLayer;
using Entities;
using Entities.Expenses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class GenericBase<TEntity> where TEntity : class
    {
        App_Context context;
        internal DbSet<TEntity> dbSet;
        public GenericBase(App_Context db)
        {
            context = db;
            dbSet = context.Set<TEntity>();
        }
        public void DeleteElement(TEntity obj)
        {

          var o= dbSet.Remove(obj);
        }

        public IEnumerable<TEntity> GetElements()
        {
            return dbSet.ToList();
        }
       
        public IEnumerable<TEntity> GetElements(Func<TEntity, bool> expression)
        {
            return dbSet.Where(expression).ToList();
        }

        public TEntity GetElementByID(int ObjId)
        {
            var Obj = dbSet.Find(ObjId);
            return Obj;
        }

        public void InsertElement(TEntity Obj)
        {
            dbSet.Add(Obj);
        }



        public void UpdateElement(TEntity NewObj)
        {
            dbSet.Attach(NewObj);
            context.Entry(NewObj).State = EntityState.Modified;
        }
    }
}
