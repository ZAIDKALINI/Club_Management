﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using CustomException;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApps.Alerts;

namespace MyApps.Controllers
{
    public class CustomersController : Controller
    {
        CustomerRepository _repositoryCustomer;
        PayementRepository _repositoryPayement;
        IList<Customer> lst;
        public CustomersController(IUnitOfWork<Customer> uowCustomer,IUnitOfWork<CustomerPayement> uowPayement)
        {
          _repositoryCustomer = new CustomerRepository(uowCustomer);
          _repositoryPayement = new PayementRepository(uowPayement, uowCustomer);
        }
        // GET: Customers
        public IActionResult Index()
        {
             lst = _repositoryCustomer.GetElements();
            return View(lst);
        }

        // GET: Customers/Details/5
        public IActionResult Details(int id)
        {
            var customer = _repositoryPayement.GetElements(p => p.Person_Id == id);
            return View(customer);

         
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                _repositoryCustomer.AddNew(customer);

                return RedirectToAction(nameof(Index)).WithSuccess("Ajouter", "vous avez ajouté avec succès ");
            }
            catch(AjouterException e)
            {
                return View().WithDanger("ERREUR", e.Message);
            }
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(int id)
        {
            var customer = _repositoryCustomer.GetElementById(id);
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                _repositoryCustomer.UpdateElement(id, customer);

                return RedirectToAction(nameof(Index)).WithSuccess("Modifier", "vous avez modifié avec succès ");
            }
            catch(ModifierException e)
            {
                
                return View().WithDanger("ERREUR", e.Message);
            }
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(int id)
        {
            var customer = _repositoryCustomer.GetElementById(id);
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repositoryCustomer.Delete(id);

                return RedirectToAction(nameof(Index)).WithSuccess("Supprimer", "vous avez supprimé avec succès ");
            }
            catch(SupprimerException e)
            {
                return View().WithDanger("ERREUR", e.Message); ;
            }
        }
        public IActionResult Find(string search)
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
        public IActionResult FindByDate(string d1,string d2)
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