using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using CustomException;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApps.Alerts;
using MyApps.Feautures;
using MyApps.Models;

namespace MyApps.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CoachesController : Controller
    {
        CoachService _repository;
        private readonly IHostingEnvironment hosting;

        [Obsolete]
        public CoachesController(IUnitOfWork<Coach> uow, IHostingEnvironment _hosting)
        {
            _repository = new CoachService(uow);
            hosting = _hosting;
        }
        // GET: Coaches
        public ActionResult Index()
        {
            var lst = _repository.GetElements();
      
            return View(lst);
        }

        // GET: Coaches/Details/5
        public ActionResult Details(Guid id)
        {
            var coach = _repository.GetElementById(id);
            return View(coach);
        }

        // GET: Coaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public IActionResult Create(CreatePersonViewModel model)
        {
            try
            {

                // TODO: Add insert logic here
                // TODO: Add insert logic here
                UploadFile upload = new UploadFile(hosting);
                string uniqueFileName = upload.UploadedFile(model.image, @"images\People");
                _repository.AddNew(new Coach() {
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
            catch(AjouterException e)
            {
                return View().WithDanger("ERREUR", e.Message);
            }
        }

        // GET: Coaches/Edit/5
        public ActionResult Edit(Guid id)
        {
            var coach = _repository.GetElementById(id);
         
            CreatePersonViewModel model = new CreatePersonViewModel()
            {
                Person_Id = id,
                Adresse = coach.Adresse,
                DateOfBirth = coach.DateOfBirth,
                First_Name = coach.First_Name,
                Last_Name = coach.Last_Name,
                genre = coach.genre,
                ImageUrl = coach.image,
                Phone = coach.Phone
            };
            return View(model);

        }

        // POST: Coaches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public IActionResult Edit(Guid id, CreatePersonViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                UploadFile upload = new UploadFile(hosting);
                var newPath = upload.UploadedFile(model.image, @"images\People");
                if (newPath == null)
                    newPath = _repository.GetElementById(id).image;
                _repository.UpdateElement(id, new Coach() {
                    Person_Id=id,
                    Adresse = model.Adresse,
                    CreatedBy = User.Identity.Name,
                    DateOfBirth = model.DateOfBirth,
                    First_Name = model.First_Name,
                    Last_Name = model.Last_Name,
                    genre = model.genre,
                    image = newPath,
                    Phone = model.Phone
                });
                return RedirectToAction(nameof(Index)).WithSuccess("Modifier", "vous avez modifié avec succès ");
            }
            catch(ModifierException e)
            {
                return View().WithDanger("ERREUR", e.Message); 
            }
        }

        // GET: Coaches/Delete/5
        public ActionResult Delete(Guid id)
        {
            var coach = _repository.GetElementById(id);
            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repository.Delete(id);

                return RedirectToAction(nameof(Index)).WithSuccess("Supprimer", "vous avez supprimé avec succès "); ;
            }
            catch(SupprimerException e)
            {
                return View().WithDanger("ERREUR", e.Message);
            }
        }
        public ActionResult Find(string search,string createdBy)
        {
            //find by first name or last name
            try
            {
                // TODO: Add delete logic here
                var lst = _repository.GetElements(search,createdBy);
                return View(lst);
            }
            catch
            {
                return View();
            }
        }
    }
}