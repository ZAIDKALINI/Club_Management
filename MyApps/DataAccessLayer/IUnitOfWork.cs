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
    public interface IUnitOfWork:IDisposable
    {
         GenericBase<Customer> CustomeresRepo { get; }
        
        GenericBase<CustomerPayement> PayementsRepo { get; }
        GenericBase<Coach> CoachRepo { get; }
        GenericBase<Category_expense> ExpenseCategorieRepo { get; }
        GenericBase<Expense> ExpenseRepo { get; }
        GenericBase<CoachPayement> CoachPayementRepo { get; }
        GenericBase<StatisticExpense> StatisticExpense { get; }
        GenericBase<Portfolio> PortfolioRep { get; }
        public void Save();
    }
}
