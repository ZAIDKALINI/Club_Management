using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Statistics_ExpenseRepo;
using DataAccessLayer;
using Entities.StatisticRepo;
using Microsoft.AspNetCore.Mvc;

namespace MyApps.Controllers
{
    public class ChartController : Controller
    {
        Reporting reporting;
        List<Reports> reports;
        public ChartController(IUnitOfWork uow)
        {
            reporting = new Reporting(uow);
            reports = new List<Reports>();
        }
        public IActionResult Index()
        {
            
            double deb;
            double crd;
            var lst = reporting.getMonthlyReport(DateTime.Now.AddYears(-1).ToString(), DateTime.Now.AddYears(1).ToString());
            foreach (var item in lst)
            {
                deb = 0;
                crd = 0;
                deb += lst.Where(r => r.Date.Month == item.Date.Month).Sum(r=>r.Debit);
                crd += lst.Where(r => r.Date.Month == item.Date.Month).Sum(r => r.Creditor);
                //test if this month is already in reports list
                var t = reports.Where(r => r.Date.Month == item.Date.Month);
                 var count = t.Count();
                if (count == 0)
                {
                    reports.Add(new Reports() { Date = item.Date, Debit = deb, Creditor=crd });
                    count = 0;
                }
                

                
            }
            var rptLst = reports.OrderBy(o => o.Date).ToList();


            return View(rptLst);
        }
      
    
    }
}