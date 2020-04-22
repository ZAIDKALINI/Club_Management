using BusinessLogicLayer;
using Entities;
using Entities.Expenses;
using Entities.Portfolio;
using Entities.StatisticRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IUnitOfWork<TEntity> :IDisposable where TEntity: class
    {
         IGenericBase<TEntity> Entity { get; }
        

        public void Save();
    }

}
