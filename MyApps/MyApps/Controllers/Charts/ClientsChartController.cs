using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace MyApps.Controllers.Charts
{
    public class ClientsChartController : Controller
    {
        List<ChartClient> reports;
        CustomerRepository _rep;
        public ClientsChartController(IUnitOfWork uow)
        {
            _rep = new CustomerRepository(uow);
            reports = new List<ChartClient>();
        }
        public IActionResult Index()
        {

            int TotalClt=0;
            var lstClient = _rep.GetElements(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Now.ToShortDateString());
            foreach (var item in lstClient)
            {
                TotalClt += lstClient.Where(c => c.DateInscri.Month == item.DateInscri.Month).Count();
                //test if this month is already in reports list
                var t = reports.Where(r => r.DateInscri.Month == item.DateInscri.Month).Count();
                if (t == 0)
                {
                    reports.Add(new ChartClient() { TotalInMonth = TotalClt, DateInscri = item.DateInscri });
                }
            }
            return View(reports.OrderBy(c=>c.DateInscri).ToList());
        }
    }
    public class ChartClient
    {
        public DateTime DateInscri { get; set; }
        public int TotalInMonth{ get; set; }
    }
}
