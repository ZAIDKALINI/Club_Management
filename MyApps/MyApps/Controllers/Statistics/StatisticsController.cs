using BusinessLogicLayer.Statistics_ExpenseRepo;
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
            ////////////////////////////////
            var lst = rpt.getMonthlyReport("", "");
            return View(lst);
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
            var lst = rpt.getMonthlyReport(d1, d2);


            return View(lst);
        }
    }
}