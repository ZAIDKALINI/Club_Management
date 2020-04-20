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
    public interface IUnitOfWork<T> where T :class 
    {
         GenericBase<T> Entity { get; }
         public void Save();
    }
}
