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
        CustomerRepository _rep;
        public ClientsChartController(IUnitOfWork uow)
        {
            _rep = new CustomerRepository(uow);
        }
        public IActionResult Index()
        {
            var lstClient = _rep.GetElements(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Now.ToShortDateString());
            return View();
        }
    }
}