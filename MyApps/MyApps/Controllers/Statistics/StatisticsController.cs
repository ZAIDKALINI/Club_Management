using BusinessLogicLayer.Statistics_ExpenseRepo;
using DataAccessLayer;
using Entities;
using Entities.Expenses;
using Entities.StatisticRepo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyApps.Controllers.Statistique
{
    public class StatisticsController : Controller
    {
        public static IList<Reports> lst;
        StatisticExpenseRepository _repositoryExpense;
        StatisticIncomeRepository _repositoryIncome;
        Reporting rpt;
        public StatisticsController(IUnitOfWork<Expense> uowExpense, IUnitOfWork<CustomerPayement> uowIncome)
        {
             _repositoryExpense = new StatisticExpenseRepository(uowExpense);
             _repositoryIncome = new StatisticIncomeRepository(uowIncome);
             rpt = new Reporting(uowExpense, uowIncome);

        }
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
            ////////////////////////////////
            var lst = rpt.getMonthlyReport("", "");
            return View(lst);
        }
        [HttpPost]
        public JsonResult GetByDate(string d1, string d2)
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
             lst = rpt.getMonthlyReport(d1, d2);


            return Json(lst);
        }
        public IActionResult PrintReport(string d1,string d2)
        {
            var lst = rpt.getMonthlyReport(d1, d2);
            return View(lst);
        }
    }
}