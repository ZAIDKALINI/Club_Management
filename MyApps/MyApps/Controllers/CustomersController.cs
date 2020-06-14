using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer;
using BusinessLogicLayer.Convertion;
using CustomException;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyApps.Alerts;
using MyApps.Feautures;
using MyApps.Models;

namespace MyApps.Controllers
{
    //[Authorize(Roles = "SuperManager")]
    public class CustomersController : Controller
    {
        CustomerService _repositoryCustomer;
        PayementService _repositoryPayement;
        
        
        private readonly IHostEnvironment _hosting;

        public ILogger<CustomersController> logger { get; }

        public CustomersController(IUnitOfWork<Customer> uowCustomer,IUnitOfWork<CustomerPayement> uowPayement, IHostEnvironment _hosting,ILogger<CustomersController> Logger)
        {
          _repositoryCustomer = new CustomerService(uowCustomer);
          _repositoryPayement = new PayementService(uowPayement);
            this._hosting = _hosting;
            this.logger = Logger;
        }
        // GET: Customers
        public IActionResult Index(int page = 1)
        {
            var dataPage = _repositoryCustomer.GetElements(page, 6);

            return View(dataPage);
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
        
        public IActionResult Create(CreatePersonViewModel model)
        {
            try
            {

                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    UploadFile upload = new UploadFile(_hosting);
                    string uniqueFileName = upload.UploadedFile(model.image, @"wwwroot\images\People");


                    _repositoryCustomer.AddNew(new Customer()
                    {
                        Adresse = model.Adresse,
                        CreatedBy = User.Identity.Name,
                        DateOfBirth = model.DateOfBirth,
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        genre = model.genre,
                        image = uniqueFileName,
                        Phone = model.Phone
                    });

                    return RedirectToAction(nameof(Index)).WithSuccess("Ajouter", "vous avez ajouté avec succès ");
            }

                return View().WithDanger("Ajouter", "Echeq d'ajout !!!");


            }
            catch (AjouterException e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
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
        
        public IActionResult Edit(Guid id, CreatePersonViewModel customer)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    UploadFile upload = new UploadFile(_hosting);
                    var newPath = upload.UploadedFile(customer.image, customer.ImageUrl,@"wwwroot\images\People")??String.Empty;
                  
                        
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
            var customer = _repositoryCustomer.GetElementById(id);
            try
            {
                // TODO: Add delete logic here
                _repositoryCustomer.Delete(id);

                return RedirectToAction(nameof(Index)).WithSuccess("Supprimer", "vous avez supprimé avec succès ");
            }
            catch (DbUpdateException ex)
            {

                //Log the exception to a file. We discussed logging to a file
                // using Nlog in Part 63 of ASP.NET Core tutorial
                logger.LogError($"Exception Occured : {ex}");
                // Pass the ErrorTitle and ErrorMessage that you want to show to
                // the user using ViewBag. The Error view retrieves this data
                // from the ViewBag and displays to the user.
                ViewBag.ErrorTitle = $" Le client \"{customer.First_Name + " " + customer.Last_Name}\" est en cours d'utilisation";
                ViewBag.ErrorMessage = $"Le client  {customer.First_Name + " " + customer.Last_Name} ne peut pas être supprimé car il y a des activités dans ce client. Si vous souhaitez supprimer ce client, veuillez supprimer les activités du client, puis essayez de supprimer";
                return View("Error");
            }
        }
        public IActionResult Find(string search)
        {
            //find by first name or last name
            try
            {
                // TODO: Add delete logic here
                

                 var lst = _repositoryCustomer.GetElements(search.Trim()).ToList();
                var result = ConvertToPagedResult<Customer>.PagedResult(lst.Take(9).ToList());
                              
                return View("Index",result);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
      
       
    }
}