using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Statistics_ExpenseRepo;
using Entities.StatisticRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApps.Controllers.Statistique
{
    public class StatisticsController : Controller
    {
        StatisticExpenseRepository _repositoryExpense = new StatisticExpenseRepository();
        StatisticIncomeRepository _repositoryIncome = new StatisticIncomeRepository();
        Reporting rpt = new Reporting();
        // GET: Statistics
        public ActionResult Index()
        {
             var PriceExpense = _repositoryExpense.GetBudgetByDate("", "");
             var ExpenseCount = _repositoryExpense.GetCountExpenseByDate("", "");
            var CustomerPayment = _repositoryIncome.GetBudgetByDate("", "");
            var CustomerCount = _repositoryIncome.GetCountCustomerByDate("", "");
            ViewBag.Price = PriceExpense;
            ViewBag.Count = ExpenseCount;
            ViewBag.PaymentCustomer = CustomerPayment;
            ViewBag.CountCustomer = CustomerCount;
            return View(rpt.getDailyReport());
        }

       public ActionResult GetByDate(string d1, string d2)
        {
            var PriceExpense = _repositoryExpense.GetBudgetByDate(d1, d2);
            var ExpenseCount = _repositoryExpense.GetCountExpenseByDate(d1, d2);
            var CustomerPayment = _repositoryIncome.GetBudgetByDate(d1, d2);
            var CustomerCount = _repositoryIncome.GetCountCustomerByDate(d1, d2);
            ViewBag.Price = PriceExpense;
            ViewBag.Count = ExpenseCount;
            ViewBag.PaymentCustomer = CustomerPayment;
            ViewBag.CountCustomer = CustomerCount;
            ////////////////////////////////
            
            return View(rpt.getMonthlyReport(Convert.ToDateTime(d1),Convert.ToDateTime(d2)));
        }
    }
}