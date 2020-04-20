using BusinessLogicLayer;
using Entities;
using Entities.Expenses;
using Entities.Portfolio;
using Entities.StatisticRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class UnitOfWork<TEntity>: IUnitOfWork<TEntity> where TEntity:class
    {
        App_Context Context;
        public UnitOfWork(App_Context context)
        {
            Context = context;
        }
    
        private IGenericBase<TEntity> _Entity;
       

        public IGenericBase<TEntity> Entity
        {
            get
            {
                if (_Entity == null)
                    _Entity = new GenericBase<TEntity>(Context);
                return _Entity;
            }

        }


       

        public void Save()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

     
    }
}
