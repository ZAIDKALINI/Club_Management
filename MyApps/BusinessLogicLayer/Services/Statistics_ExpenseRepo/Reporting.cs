using DataAccessLayer;
using Entities;
using Entities.Expenses;
using Entities.StatisticRepo;
using Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace BusinessLogicLayer.Statistics_ExpenseRepo
{
    public class Reporting
    {
        
        List<Reports> reports;
        private IUnitOfWork<Expense> uowExpense;
        private IUnitOfWork<CustomerPayement> _uowIncome;

        public Reporting(IUnitOfWork<Expense> _uow, IUnitOfWork<CustomerPayement> uowIncome)
        {
            reports = new List<Reports>();
            uowExpense = _uow;
            _uowIncome = uowIncome;
        }
        /// <summary>
        /// Get report for new customer
        /// </summary>
        /// <returns></returns>
        public IList<Reports> getDailyReport()
        {
            var lstC = uowExpense.Entity.GetElements(r => r.ExpenseDate.ToShortDateString() == DateTime.Now.ToShortDateString());
            var lstD = _uowIncome.Entity.GetElements(r => r.Payement_date.ToShortDateString() == DateTime.Now.ToShortDateString());
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
            if (from1 == DateTime.MinValue || to1 == DateTime.MinValue)
                getMonthlyReport();
            else if (from1 != null && to1 != null)
            {
                var lstCriditor = uowExpense.Entity.GetElements(r => r.ExpenseDate >= from1 && r.ExpenseDate <= to1);
                var lstDebitor = _uowIncome.Entity.GetElements(r => r.Payement_date >= from1 && r.Payement_date <= to1);
                fillList(lstCriditor, lstDebitor);
            }

            return reports;
        }

        private void getMonthlyReport()
        {
            var firstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            var lstCriditor = uowExpense.Entity.GetElements(r => r.ExpenseDate >= firstDate && r.ExpenseDate <= lastDate);
            var lstDebitor = _uowIncome.Entity.GetElements(r => r.Payement_date >= firstDate && r.Payement_date <= lastDate);
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
        /// <summary>
        /// Get data for chart payment by gender and year
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public IList<ChartGenderModel> getIncomeByGender( int year)
        {
            var lst = _uowIncome.Entity.GetWithItems(c =>  c.Payement_date.Year == year, c => c.customer).ToList();
            double price = 0;
            var TotalFemalePrice = lst.Where(gender => gender.customer.genre == Genre.female).Sum(sum => sum.Price);
            var TotalMalePrice = lst.Where(gender => gender.customer.genre == Genre.Male).Sum(sum => sum.Price);
            List<ChartGenderModel> ChartData = new List<ChartGenderModel>();                

            
                    ChartData.Add(new ChartGenderModel()
                    {
                       gender=Genre.female.ToString(),
                        Price = TotalFemalePrice
                    });
            ChartData.Add(new ChartGenderModel()
            {
                gender = Genre.Male.ToString(),
                Price = TotalMalePrice
            });

            return ChartData;

        }
    }
}
