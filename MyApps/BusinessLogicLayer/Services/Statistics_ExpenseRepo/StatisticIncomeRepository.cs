using DataAccessLayer;
using Entities;
using Entities.Incomes;
using Entities.StatisticRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Statistics_ExpenseRepo
{
    public class StatisticIncomeRepository
    {
        private IUnitOfWork<CustomerPayement> _repository;

        public StatisticIncomeRepository(IUnitOfWork<CustomerPayement> uow)
        {
            _repository = uow;
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
        /// <summary>
        /// get chiffre daffaire between to date
        /// </summary>
        /// <param name="d1">to</param>
        /// <param name="d2">from</param>
        /// <returns>chiffre d'affaire</returns>
        public double GetBudgetByDate(string d1, string d2)
        {
            // get expense belong in current row if parameters is null
            if (string.IsNullOrEmpty(d1) || string.IsNullOrEmpty(d2))
            {
                var firstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var lastDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                var sum = _repository.Entity.GetElements(s => s.Payement_date >= firstDate && s.Payement_date <= lastDate).Select(s => s.Price).Sum();
                return sum;

            }
            //
            // get expense between 2 date if parameters not null
            var D1 = ConvertDate(d1);
            var D2 = ConvertDate(d2);
            var sum1 = _repository.Entity.GetElements(s => s.Payement_date >= D1 && s.Payement_date <= D2).Select(s=>s.Price).Sum();
           
            return sum1;

        }
        /// <summary>
        /// Get a total incomes
        /// </summary>
        /// <param name="d1">to</param>
        /// <param name="d2">from</param>
        /// <returns>Total customer</returns>
        public int GetCountCustomerByDate(string d1, string d2)
        {
           
            if (string.IsNullOrEmpty(d1) || string.IsNullOrEmpty(d2))
            {
                var firstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var lastDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                var Count = getCountCustomerbyDate(firstDate,lastDate);
                return Count;

            }
            var count = getCountCustomerbyDate(ConvertDate(d1), ConvertDate(d2));
            return count;

            // get expense between 2 date if parameters not null
           
        }
        /// <summary>
        /// Get a total customer filter by date
        /// </summary>
        /// <param name="d1">to</param>
        /// <param name="d2">from</param>
        /// <returns>Total customer</returns>
        int getCountCustomerbyDate(DateTime d1,DateTime d2)
        {
           
            var count1 = _repository.Entity.GetElements().Where(s => s.Payement_date >= d1 && s.Payement_date <= d2 ).Count();
            return count1;
        }
        

       
    }
}
