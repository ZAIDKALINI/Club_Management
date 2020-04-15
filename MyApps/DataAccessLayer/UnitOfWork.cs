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
    public class UnitOfWork: IUnitOfWork
    {
        App_Context Context;
        public UnitOfWork(App_Context context)
        {
            Context = context;
        }
    
        private GenericBase<Customer> _CustomersRepo;
        private GenericBase<CustomerPayement> _PayementsCustomerRepo;
        private GenericBase<Coach> _CoachRepo;
        private GenericBase<Category_expense> _ExpenseCategorie;
        private GenericBase<Expense> _ExpenseRepo;
        private GenericBase<CoachPayement> _CoachPayementRepo;
        private GenericBase<StatisticExpense> _StatisticExpense;
        private GenericBase<Portfolio> _portfolio;

        public GenericBase<Customer> CustomeresRepo
        {
            get
            {
                if (_CustomersRepo == null)
                    _CustomersRepo = new GenericBase<Customer>(Context);
                return _CustomersRepo;
            }

        }
        public GenericBase<CustomerPayement> PayementsRepo
        {
            get
            {
                if (_PayementsCustomerRepo == null)
                    _PayementsCustomerRepo = new GenericBase<CustomerPayement>(Context);
                return _PayementsCustomerRepo;
            }

        }
        public GenericBase<Coach> CoachRepo {
            get
            {
                if (_CoachRepo == null)
                    _CoachRepo = new GenericBase<Coach>(Context);
                return _CoachRepo;
            }
                
                
         }
        public GenericBase<Category_expense> ExpenseCategorieRepo
        {
            get
            {
                if (_ExpenseCategorie == null)
                    _ExpenseCategorie = new GenericBase<Category_expense>(Context);
                return _ExpenseCategorie;
            }

        }
        public GenericBase<Expense> ExpenseRepo
        {
            get
            {
                if (_ExpenseRepo == null)
                    _ExpenseRepo = new GenericBase<Expense>(Context);
                return _ExpenseRepo;
            }
        }
        public GenericBase<CoachPayement> CoachPayementRepo
        {
            get
            {
                if (_CoachPayementRepo == null)
                    _CoachPayementRepo = new GenericBase<CoachPayement>(Context);
                return _CoachPayementRepo;
            }
        }
        public GenericBase<StatisticExpense> StatisticExpense
        {
            get
            {
                if (_StatisticExpense == null)
                    _StatisticExpense = new GenericBase<StatisticExpense>(Context);
                return _StatisticExpense;
            }
        }

        public GenericBase<Portfolio> PortfolioRep
        {
            get
            {
                if (_portfolio == null)
                    _portfolio = new GenericBase<Portfolio>(Context);
                return _portfolio;
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
