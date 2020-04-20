using DataAccessLayer;
using Entities;
using Entities.Expenses;
using Entities.StatisticRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Statistics_ExpenseRepo
{
    public class Reporting
    {
        IUnitOfWork<Expense> _expense;
        IUnitOfWork<CustomerPayement> _income;
        List<Reports> reports;
        public Reporting(IUnitOfWork<Expense> expense,IUnitOfWork<CustomerPayement> income)
        {
            reports = new List<Reports>();
            _expense = expense;
            _income = income;
        }
        /// <summary>
        /// Get report for new customer
        /// </summary>
        /// <returns></returns>
        public IList<Reports> getDailyReport()
        {
            var lstC = _expense.Entity.GetElements(r => r.ExpenseDate == DateTime.Now);
            var lstD = _income.Entity.GetElements(r => r.Payement_date == DateTime.Now);
            //Insert Creditor
            foreach (var item in lstC)
            {
                reports.Add(new Reports()
                {
                    Date = item.ExpenseDate,
                    Description = item.Description,
                    Creditor = item.Price,
                    Debit = 0
                });
            }

            //Insert Debit
            foreach (var item in lstD)
            {
                reports.Add(new Reports()
                {
                    Date = item.Payement_date,
                    Description = "Paiement client",
                    Creditor = 0,
                    Debit = item.Price
                });
            }
            return reports;

        }

        public IList<Reports> getMonthlyReport(string from, string to)
        {
            var from1 = ConvertDate.ConvertToDate(from);
            var to1 = ConvertDate.ConvertToDate(to);
            //////////////////////////////////
            if (from1 == DateTime.MinValue || from1 == DateTime.MinValue)
                getMonthlyReport();
            else if (from1 != null && to1 != null)
            {
                var lstCriditor = _expense.Entity.GetElements(r => r.ExpenseDate >= from1 && r.ExpenseDate <= to1);
                var lstDebitor = _income.Entity.GetElements(r => r.Payement_date >= from1 && r.Payement_date <= to1);
                fillList(lstCriditor, lstDebitor);
            }

            return reports;
        }

        private void getMonthlyReport()
        {
            var firstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            var lstCriditor = _expense.Entity.GetElements(r => r.ExpenseDate >= firstDate && r.ExpenseDate <= lastDate);
            var lstDebitor = _income.Entity.GetElements(r => r.Payement_date >= firstDate && r.Payement_date <= lastDate);
            fillList(lstCriditor, lstDebitor);


        }
        private void fillList(IEnumerable<Expense> lstCriditor, IEnumerable<CustomerPayement> lstDebitor)
        {
            foreach (var item in lstCriditor)
            {
                reports.Add(new Reports()
                {
                    Date = item.ExpenseDate,
                    Description = item.Description,
                    Creditor = item.Price,
                    Debit = 0
                });
            }

            //Insert Debit
            foreach (var item in lstDebitor)
            {
                reports.Add(new Reports()
                {
                    Date = item.Payement_date,
                    Description = "Paiement client",
                    Creditor = 0,
                    Debit = item.Price
                });
            }
        }
    }
}
