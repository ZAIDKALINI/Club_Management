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
    public class UnitOfWork<T>:IDisposable, IUnitOfWork<T> where T : class
    {
        App_Context Context;
        private GenericBase<T> _Entity;
        public UnitOfWork(App_Context context)
        {
            Context = context;
        }
    
        public GenericBase<T> Entity
        {
            get
            {
                if (_Entity == null)
                    _Entity = new GenericBase<T>(Context);
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
