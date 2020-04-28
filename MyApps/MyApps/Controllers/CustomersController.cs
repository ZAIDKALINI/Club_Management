using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using CustomException;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApps.Alerts;
using MyApps.Feautures;
using MyApps.Models;

namespace MyApps.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomersController : Controller
    {
        CustomerService _repositoryCustomer;
        PayementService _repositoryPayement;
        IList<Customer> lst;
        [Obsolete]
        private readonly IHostingEnvironment _hosting;

        [Obsolete]
        public CustomersController(IUnitOfWork<Customer> uowCustomer,IUnitOfWork<CustomerPayement> uowPayement, IHostingEnvironment _hosting)
        {
          _repositoryCustomer = new CustomerService(uowCustomer);
          _repositoryPayement = new PayementService(uowPayement);
            this._hosting = _hosting;
        }
        // GET: Customers
        public IActionResult Index()
        {
             lst = _repositoryCustomer.GetElements();
            return View(lst);
        }

        // GET: Customers/Details/5
        /// <summary>
        /// Get dtails payement for Customer spesific 
        /// </summary>
        /// <param name="idPayement">id Customer</param>
        /// <returns></returns>
        public IActionResult Details(Guid Id)
        {
            
            var customer = _repositoryPayement.GetPayementByCustomer(Id);
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
        [Obsolete]
        public IActionResult Create(CreatePersonViewModel model)
        {
            try
            {

                // TODO: Add insert logic here
                UploadFile upload = new UploadFile(_hosting);
                string uniqueFileName = upload.UploadedFile(model.image,@"images\People");
               
                   
                    _repositoryCustomer.AddNew(new Customer() { 
                    Adresse=model.Adresse,
                    CreatedBy=User.Identity.Name,
                    DateOfBirth=model.DateOfBirth,
                    First_Name=model.First_Name,
                    Last_Name=model.Last_Name,
                    genre=model.genre,
                    image=uniqueFileName,
                    Phone=model.Phone
                    });

                    return RedirectToAction(nameof(Index)).WithSuccess("Ajouter", "vous avez ajouté avec succès ");
                
            
        
            }
            catch(AjouterException e)
            {
                ModelState.AddModelError("", e.Message);
                return View().WithDanger("ERREUR", e.Message);
            }
        }
       
        // GET: Customers/Edit/5
        public IActionResult Edit(Guid id)
        {
            var customer = _repositoryCustomer.GetElementById(id);
            CreatePersonViewModel model = new CreatePersonViewModel()
            {
                Person_Id=id,
                Adresse = customer.Adresse,
                DateOfBirth = customer.DateOfBirth,
                First_Name = customer.First_Name,
                Last_Name = customer.Last_Name,
                genre = customer.genre,
                ImageUrl = customer.image,
                Phone = customer.Phone
            };
            return View(model);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public IActionResult Edit(Guid id, CreatePersonViewModel customer)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    UploadFile upload = new UploadFile(_hosting);
                    var newPath = upload.UploadedFile(customer.image, @"images\People");
                    if (newPath == null)
                        newPath = _repositoryCustomer.GetElementById(id).image;
                    _repositoryCustomer.UpdateElement(id, new Customer()
                    {
                        Person_Id=customer.Person_Id,
                        Adresse = customer.Adresse,
                        CreatedBy = User.Identity.Name,
                        DateOfBirth = customer.DateOfBirth,
                        First_Name = customer.First_Name,
                        Last_Name = customer.Last_Name,
                        genre = customer.genre,
                        image = newPath,
                        Phone = customer.Phone
                    });

                    return RedirectToAction(nameof(Index)).WithSuccess("Modifier", "vous avez modifié avec succès ");
                }
                return View().WithDanger("Modifier", "Echeq de modifier");
            }
            catch(Exception e)
            {
                
                return View().WithDanger("ERREUR", e.Message);
            }
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(Guid id)
        {
            var customer = _repositoryCustomer.GetElementById(id);
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, IFormCollection collection)
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
                

                 var lst = _repositoryCustomer.GetElements(search.Trim()).ToList();
                                      
                return View("Index",lst);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
      
       
    }
}