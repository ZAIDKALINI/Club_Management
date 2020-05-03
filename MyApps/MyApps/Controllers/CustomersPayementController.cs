using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using CustomException;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApps.Alerts;

namespace MyApps.Controllers
{
  //  [Authorize(Roles = "Admin")]
    public class CustomersPayementController : Controller
    {
      

        IList<CustomerPayement> lst;
        private PayementService _repositoryPayement;
        private CustomerService _customerRepo;
 

        public CustomersPayementController(IUnitOfWork<CustomerPayement> uowPayement, IUnitOfWork<Customer> uowCustomer)
        {
            _repositoryPayement = new PayementService(uowPayement);
            _customerRepo = new CustomerService(uowCustomer);
          


        }
        // GET: CustomersPayement
        public ActionResult Index()
        {
             lst = _repositoryPayement.GetElements();
                   
            return View(lst);
        }
       
      
        // GET: CustomersPayement/Create
        public ActionResult Create(Guid id)
        {
            //get info initial for customer
            var cus = _customerRepo.GetElementById(id);
            ViewBag.Person_Name = cus.First_Name+" "+cus.Last_Name;
            ViewBag.Person_Image = cus.image??"Default.jpg";
            ViewBag.Person_Id = cus.Person_Id;


            return View();
        }

        // POST: CustomersPayement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerPayement collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.Id = Guid.Empty;
                _repositoryPayement.AddNew(collection);
              //  var cust  = _repositoryPayement.GetElements(p => p.Person_Id == collection.Person_Id);
              
                return RedirectToAction("Details","Customers", new { id = collection.Person_Id }).WithSuccess("Ajouter", "vous avez ajouté avec succès "); 
            }
            catch
            {
            
                return View("Error");
            }
        }

        // GET: CustomersPayement/Edit/5
        public ActionResult Edit(Guid id/*Payement id*/)
        {
         
            //get payement for editing
            var payement = _repositoryPayement.GetElementById(id);
            // set info for client 
            var cus = _customerRepo.GetElementById(payement.Person_Id);
            ViewBag.Person_Id = cus.Person_Id;
            ViewBag.Person_Name = cus.First_Name + " " + cus.Last_Name;
            ViewBag.Person_Image = cus.image ?? "Default.jpg";


            return View(payement);
        }

        // POST: CustomersPayement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, CustomerPayement customerPayement)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _repositoryPayement.UpdateElement(id, customerPayement);
                  
                   
                     return RedirectToAction("Index").WithSuccess("Modifier", "vous avez modifié avec succès ");
                }
                return View(customerPayement).WithDanger("Modifier","Operation de modifier est échouer");

            }
            catch
            {
                return View("Error");

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid Id)
        {
            try
            {
               
                _repositoryPayement.Delete(Id);
                return RedirectToAction("Index").WithSuccess("Supprimer", "vous avez supprimé avec succès ");
            }
            catch 
            {

                return View("Error");
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
            
            
                var lst=  _repositoryPayement.GetCustomersEndthierMonth();
              

                return View(nameof(Index),lst);
            }
            catch
            {
                return View();
            }
        }

    }
}