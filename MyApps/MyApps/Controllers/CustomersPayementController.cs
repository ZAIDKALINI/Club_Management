﻿using System;
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApps.Alerts;

namespace MyApps.Controllers
{
   
    public class CustomersPayementController : Controller
    {
        PayementRepository _repository;
        CustomerRepository _customerRepo;

        IList<CustomerPayement> lst;
        public CustomersPayementController(IUnitOfWork uow)
        {
             _repository = new PayementRepository(uow);
             _customerRepo = new CustomerRepository(uow);
           
        }
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

            ViewData["Person_Id"] = new SelectList(_customerRepo.GetElements(), "Person_Id", "Last_Name");
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
                _repository.AddNew(collection);
                var cust  = _repository.GetElements(p => p.Person_Id == collection.Person_Id);
              
                return RedirectToAction(nameof(Index)).WithSuccess("Ajouter", "vous avez ajouté avec succès "); 
            }
            catch(SupprimerException e)
            {
                return View().WithDanger("ERREUR",e.Message);
            }
        }

        // GET: CustomersPayement/Edit/5
        public ActionResult Edit(int id)
        {
         
            var payement = _repository.GetElementById(id);
            var cust = _customerRepo.GetElements();
            ViewData["Person_Id"] = new SelectList(cust, "Person_Id", "Last_Name", payement.Person_Id);
           
            return View(payement);
        }

        // POST: CustomersPayement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CustomerPayement customerPayement)
        {
            try
            {
                
                // TODO: Add update logic here
                _repository.UpdateElement(id,customerPayement);
                //_repository.ResetRestIsEndForTrue(customerPayement.Person_Id);
                var payement = _repository.GetElementById(id);
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
        public IActionResult Delete(int Id)
        {
            try
            {
               
                _repository.Delete(Id);
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
            
                var lst=  _repository.GetCustomersEndthierMonth;
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