using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApps.Controllers
{
    public class CustomersController : Controller
    {
        CustomerRepository _repositoryCustomer = new CustomerRepository();
        PayementRepository _repositoryPayement = new PayementRepository();
        IList<Customer> lst;
        // GET: Customers
        public ActionResult Index()
        {
             lst = _repositoryCustomer.GetElements();
            return View(lst);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customer = _repositoryPayement.GetElements(p => p.Person_Id == id);
            return View(customer);

         
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                _repositoryCustomer.AddNew(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _repositoryCustomer.GetElementById(id);
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                _repositoryCustomer.UpdateElement(id, customer);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _repositoryCustomer.GetElementById(id);
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repositoryCustomer.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Find(string search)
        {
            //find by first name or last name
            try
            {
                // TODO: Add delete logic here
                var lst = _repositoryCustomer.GetElements(search);
                return View(lst);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult FindByDate(string d1,string d2)
        {
            //find by first name or last name
            try
            {

                // TODO: Add delete logic here
                lst = _repositoryCustomer.GetElements(d1, d2).ToList();
                    return View("Find",lst);
            }
            catch
            {
                return View();
            }
        }
    }
}