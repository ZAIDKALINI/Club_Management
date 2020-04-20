using DataAccessLayer;
using Entities.Expenses;
using Entities.StatisticRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Statistics_ExpenseRepo
{
    public class StatisticExpenseRepository
    {
        IUnitOfWork<Expense> _expense;
        public StatisticExpenseRepository(IUnitOfWork<Expense> expense)
        {
            _expense = expense;
        }
       
        DateTime ConvertDate(string date)
        {
            try
            {
                return Convert.ToDateTime(date);
            }
            catch
            {
                throw new Exception("Cannot convert string date to date time");
            }
        }
   
        public double GetBudgetByDate(string d1,string d2)
        {
            // get expense belong in current row if parameters is null
            if(string.IsNullOrEmpty(d1) || string.IsNullOrEmpty(d2))
            {
                var firstDate= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var lastDate= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                var sum = _expense.Entity.GetElements().Where(s => s.ExpenseDate >= firstDate && s.ExpenseDate <= lastDate).Select(s => s.Price).Sum();
                return sum;
                
            }
            // get expense between 2 date if parameters not null
            var D1 = ConvertDate(d1);
            var D2 = ConvertDate(d2);
            var sum1= _expense.Entity.GetElements().Where(s => s.ExpenseDate >= D1 && s.ExpenseDate <= D2).Select(s => s.Price).Sum();
            return sum1;

        }
        public int GetCountExpenseByDate(string d1,string d2)
        {
            if (string.IsNullOrEmpty(d1) || string.IsNullOrEmpty(d2))
            {
                var firstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var lastDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                var count = _expense.Entity.GetElements().Where(s => s.ExpenseDate >= firstDate && s.ExpenseDate <= lastDate).Select(s => s.Price).Count();
                return count;

            }
            // get expense between 2 date if parameters not null
            var D1 = ConvertDate(d1);
            var D2 = ConvertDate(d2);
            var count1 = _expense.Entity.GetElements().Where(s => s.ExpenseDate >= D1 && s.ExpenseDate <= D2).Select(s => s.Price).Count();
            return count1;
        }
    }
}
