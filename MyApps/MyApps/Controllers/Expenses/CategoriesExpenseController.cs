using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.ExpenseRepo;
using CustomException;
using DataAccessLayer;
using Entities.Expenses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApps.Alerts;

namespace MyApps.Controllers.Expenses
{
    public class CategoriesExpenseController : Controller
    {
        CategoriesRepository _categorieRepo;
       
        public CategoriesExpenseController(IUnitOfWork _uow)
        {
            _categorieRepo = new CategoriesRepository(_uow);
        }
        // GET: Categories
        public ActionResult Index()
        {
            var lst = _categorieRepo.GetCategories();
            return View(lst);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.categories = _categorieRepo.GetCategories();
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category_expense category)
        {
            try
            {
                _categorieRepo.AddNew(category);
                

                return RedirectToAction(nameof(Index)).WithSuccess("Ajouter", "vous avez ajouté avec succès ");
            }
            catch(SupprimerException e)
            {
                return View().WithDanger("ERREUR", e.Message); 
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categorieRepo.FindById(id);
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category_expense category)
        {
            try
            {
                // TODO: Add update logic here
                _categorieRepo.Edit(id, category);

                return RedirectToAction(nameof(Index)).WithSuccess("Modifier", "vous avez modifié avec succès ");
            }
            catch(ModifierException e)
            {
                return View().WithDanger("ERREUR", e.Message); 
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categorieRepo.FindById(id);
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                _categorieRepo.Delete(id);
                return RedirectToAction(nameof(Index)).WithSuccess("Supprimer", "vous avez supprimé avec succès ");
            }
            catch(SupprimerException e)
            {
                return View().WithDanger("ERREUR", e.Message); ;
            }
        }
    }
}