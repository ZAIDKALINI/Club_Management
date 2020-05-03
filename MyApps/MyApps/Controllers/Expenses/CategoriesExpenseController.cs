using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.ExpenseRepo;
using CustomException;
using DataAccessLayer;
using Entities.Expenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyApps.Alerts;

namespace MyApps.Controllers.Expenses
{
    [Authorize(Roles = "Admin")]
    public class CategoriesExpenseController : Controller
    {
        CategoriesService _categorieRepo;
        private readonly ILogger<CategoriesExpenseController> logger;

        public CategoriesExpenseController(IUnitOfWork<Category_expense> _uow, ILogger<CategoriesExpenseController> logger)
        {
            _categorieRepo = new CategoriesService(_uow);
            this.logger = logger;
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
           // ViewBag.categories = _categorieRepo.GetCategories();
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
        public ActionResult Edit(Guid id)
        {
            var category = _categorieRepo.FindById(id);
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Category_expense category)
        {
            try
            {
                // TODO: Add update logic here
                _categorieRepo.Edit(id, category);

                return RedirectToAction(nameof(Index)).WithSuccess("Modifier", "vous avez modifié avec succès ");
            }
            catch(Exception e)
            {
                return View().WithDanger("ERREUR", e.Message); 
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(Guid id)
        {
            var category = _categorieRepo.FindById(id);
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            var categorie = _categorieRepo.FindById(id);
            try
            {
                // TODO: Add delete logic here
                
                _categorieRepo.Delete(id);
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
                ViewBag.ErrorTitle = $" Le catégorie \"{categorie.Name_Category}\" est en cours d'utilisation";
                ViewBag.ErrorMessage = $"Le catégorie de dépense {categorie.Name_Category} ne peut pas être supprimé car il y a des dépenses dans ce catégorie. Si vous souhaitez supprimer ce catégorie, veuillez supprimer les dépenses du catégorie, puis essayez de supprimer";
                return View("Error");
            }
        }
        public IActionResult Find(string search)
        {
            IList<Category_expense> lst;
            if (search == null)
            {
                lst= _categorieRepo.GetCategories();
            }
            else
             lst = _categorieRepo.GetCategories(c=>c.Name_Category.ToUpper().Contains(search.ToUpper()));
            
            return Json(lst);
        }
    }
}