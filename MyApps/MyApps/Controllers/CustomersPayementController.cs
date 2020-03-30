using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyApps.Controllers
{
    public class CustomersPayementController : Controller
    {
        PayementRepository _repository = new PayementRepository();
        CustomerRepository _customerRepo = new CustomerRepository();

        IList<CustomerPayement> lst;
        // GET: CustomersPayement
        public ActionResult Index()
        {
             lst = _repository.GetElements();
            ViewBag.Person_Id = new SelectList(_customerRepo.GetElements(), "Person_Id", "Last_Name");
           
            return View(lst);
        }

        // GET: CustomersPayement/Details/5
        public ActionResult Details(int id)
        {
         
            var customerPayement=_repository.GetElementById(id);
            var customer = _customerRepo.GetElementById(id);
            customerPayement.customer = customer;
        
            return View(customerPayement);
        }

        // GET: CustomersPayement/Create
        public ActionResult Create()
        {
       
            ViewBag.Person_Id = new SelectList(_customerRepo.GetElements(), "Person_Id","","");
            return View();
        }

        // POST: CustomersPayement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerPayement collection)
        {
            try
            {
                // TODO: Add insert logic here
                _repository.AddNew(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersPayement/Edit/5
        public ActionResult Edit(int id)
        {
         
            var payement = _repository.GetElementById(id);
            var cust = _customerRepo.GetElements();
            ViewBag.Person_Id = new SelectList(cust, "Person_Id", "Last_Name", payement.customer.Person_Id);
            return View(payement);
        }

        // POST: CustomersPayement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerPayement customerPayement)
        {
            try
            {
                // TODO: Add update logic here
                _repository.UpdateElement(id,customerPayement);

                return RedirectToAction("GetCustumer");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersPayement/Delete/5
        public ActionResult Delete(int id)
        {

            var customerPayement = _repository.GetElementById(id);
            var customer = _customerRepo.GetElementById(id);
            customerPayement.customer = customer;
            return View(customerPayement);
        }

        // POST: CustomersPayement/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
     /// <summary>
     /// Get customer should pay thier month
     /// </summary>
     /// <returns></returns>
        public ActionResult GetCustumer()
        {
            try
            {
                // TODO: Add update logic here
              var lst=  _repository.GetCustomersEndthierMonth;

                return View(nameof(Index),lst);
            }
            catch
            {
                return View();
            }
        }

    }
}