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
using Microsoft.AspNetCore.Mvc;
using MyApps.Alerts;

namespace MyApps.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CoachesController : Controller
    {
        CoachService _repository;
        public CoachesController(IUnitOfWork<Coach> uow)
        {
            _repository = new CoachService(uow);
        }
        // GET: Coaches
        public ActionResult Index()
        {
            var lst = _repository.GetElements(User.Identity.Name);
      
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
        public IActionResult Create(Entities.Coach coach)
        {
            try
            {
               
                // TODO: Add insert logic here
                _repository.AddNew(coach);
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
            return View(coach);
       
        }

        // POST: Coaches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Entities.Coach collection)
        {
            try
            {
                // TODO: Add update logic here
                _repository.UpdateElement(id, collection);
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