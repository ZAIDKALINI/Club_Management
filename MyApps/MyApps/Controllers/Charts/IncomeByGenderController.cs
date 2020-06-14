using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyApps.Controllers.Charts
{
    public class IncomeByGenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}