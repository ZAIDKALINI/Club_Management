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
    [Authorize(Roles = "Admin")]
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
            ViewBag.Person_Id = new SelectList(_customerRepo.GetElements(), "Person_Id", "Last_Name");
           
            return View(lst);
        }
       
        // GET: CustomersPayement/Details/5
        public ActionResult Details(Guid idPayement)
        {
         
            var customerPayement=_repositoryPayement.GetElementById(idPayement);
            var customer = _customerRepo.GetElementById(idPayement);
            customerPayement.customer = customer;
        
            return View(customerPayement);
        }

        // GET: CustomersPayement/Create
        public ActionResult Create(Guid id)
        {
            var cus = _customerRepo.GetElementById(id);
            ViewBag.Person_Id = id;
            ViewBag.Person_Name = cus.First_Name+" "+cus.Last_Name;
            ViewBag.Person_Image = cus.image??"Default.jpg";
           
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
            catch(SupprimerException e)
            {
                return View().WithDanger("ERREUR",e.Message);
            }
        }

        // GET: CustomersPayement/Edit/5
        public ActionResult Edit(Guid id)
        {
         
            var payement = _repositoryPayement.GetElementById(id);
            var cust = _customerRepo.GetElements();
            ViewData["Person_Id"] = new SelectList(cust, "Person_Id", "Last_Name", payement.Person_Id);
           
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
                _repositoryPayement.UpdateElement(id,customerPayement);
                //_repository.ResetRestIsEndForTrue(customerPayement.Person_Id);
                var payement = _repositoryPayement.GetElementById(id);
                var cust = _customerRepo.GetElements();
                ViewData["Person_Id"] = new SelectList(cust, "Person_Id", "Last_Name", payement.Person_Id);

                return RedirectToAction("Index").WithSuccess("Modifier", "vous avez modifié avec succès ");
            }
            catch(SupprimerException e)
            {
               
                return View().WithDanger("ERREUR", e.Message); 
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
            catch (SupprimerException e)
            {

                return RedirectToAction("Index").WithDanger("ERREUR", e.Message);
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
                var cust = _customerRepo.GetElements();
            
                var lst=  _repositoryPayement.GetCustomersEndthierMonth();
                ViewBag.Person_Id = new SelectList(_customerRepo.GetElements(), "Person_Id", "Last_Name");

                return View(nameof(Index),lst);
            }
            catch
            {
                return View();
            }
        }

    }
}