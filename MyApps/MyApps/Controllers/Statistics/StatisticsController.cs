using BusinessLogicLayer.Statistics_ExpenseRepo;
using DataAccessLayer;
using Entities;
using Entities.Expenses;
using Entities.StatisticRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace MyApps.Controllers.Statistique
{


   //[Authorize(Roles = "Admin")]
    public class StatisticsController : Controller
    {
        public static IList<Reports> lst;
        StatisticExpenseRepository _repositoryExpense;
        StatisticIncomeRepository _repositoryIncome;
        Reporting rpt;
        public StatisticsController(IUnitOfWork<Expense> uowExpense, IUnitOfWork<CustomerPayement> uowPayement)
        {
             _repositoryExpense = new StatisticExpenseRepository(uowExpense);
             _repositoryIncome = new StatisticIncomeRepository(uowPayement);
             rpt = new Reporting(uowExpense,uowPayement);

        }
        // GET: Statistics
        public ActionResult Index(string d1, string d2)
        {
            d1 = DateTime.Now.ToShortDateString();
            d2 = DateTime.Now.AddDays(1).ToShortDateString();
            var PriceExpense = _repositoryExpense.GetBudgetByDate(d1, d2);
            var ExpenseCount = _repositoryExpense.GetCountExpenseByDate(d1, d2);
            var CustomerPayment = _repositoryIncome.GetBudgetByDate(d1, d2);
            var CustomerCount = _repositoryIncome.GetCountCustomerByDate(d1, d2);
            ViewBag.Price = PriceExpense;
            ViewBag.Count = ExpenseCount;
            ViewBag.PaymentCustomer = CustomerPayment;
            ViewBag.CountCustomer = CustomerCount;
            ////////////////////////////////
            var lst = rpt.getDailyReport();
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