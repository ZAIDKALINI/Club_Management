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
   
    public class CustomersPayementController : Controller
    {
      

        IList<CustomerPayement> lst;
        private PayementService _repositoryPayement;
        private CustomerService _customerRepo;
        SignInManager<ApplicationUser> signInManager;

        public CustomersPayementController(IUnitOfWork<CustomerPayement> uowPayement, IUnitOfWork<Customer> uowCustomer, 
                                            SignInManager<ApplicationUser> signInManager)
        {
            _repositoryPayement = new PayementService(uowPayement);
            _customerRepo = new CustomerService(uowCustomer);
            this.signInManager = signInManager;


        }
        // GET: CustomersPayement
        public ActionResult Index()
        {
             lst = _repositoryPayement.GetElements(User.Identity.Name);
            ViewBag.Person_Id = new SelectList(_customerRepo.GetElements(User.Identity.Name), "Person_Id", "Last_Name");
           
            return View(lst);
        }

        // GET: CustomersPayement/Details/5
        public ActionResult Details(Guid id)
        {
         
            var customerPayement=_repositoryPayement.GetElementById(id);
            var customer = _customerRepo.GetElementById(id);
            customerPayement.customer = customer;
        
            return View(customerPayement);
        }

        // GET: CustomersPayement/Create
        public ActionResult Create()
        {

            ViewData["Person_Id"] = new SelectList(_customerRepo.GetElements(User.Identity.Name), "Person_Id", "Last_Name");
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
            var cust = _customerRepo.GetElements(User.Identity.Name);
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
                var cust = _customerRepo.GetElements(User.Identity.Name);
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
                var cust = _customerRepo.GetElements(User.Identity.Name);
            
                var lst=  _repositoryPayement.GetCustomersEndthierMonth(User.Identity.Name);
                ViewBag.Person_Id = new SelectList(_customerRepo.GetElements(User.Identity.Name), "Person_Id", "Last_Name");

                return View(nameof(Index),lst);
            }
            catch
            {
                return View();
            }
        }

    }
}