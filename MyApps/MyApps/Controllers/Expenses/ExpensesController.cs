using System;
using BusinessLogicLayer.ExpenseRepo;
using DataAccessLayer;
using Entities.Expenses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyApps.Controllers.Expenses
{
    public class ExpensesController : Controller
    {
        ExpensesRepository _expenseRepo;
        CategoriesRepository _categorieExpense;
        public ExpensesController(IUnitOfWork _uow)
        {
             _expenseRepo = new ExpensesRepository(_uow);
             _categorieExpense = new CategoriesRepository(_uow);
        }
        // GET: Expenses
        public ActionResult Index()
        {
            var lst = _expenseRepo.GetElements();
            return View(lst);
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            //"Id_Category", "Name_Category"

            ViewBag.Id_Category = new SelectList(_categorieExpense.GetCategories(), "Id_Category", "Name_Category");
            return View();
        }

        // POST: Expenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            try
            {
                // TODO: Add insert logic here
                _expenseRepo.AddNew(expense);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int id)
        {
            var exp = _expenseRepo.GetElementById(id);
            var lstCat = _categorieExpense.GetCategories();
            ViewBag.Id_Category = new SelectList(lstCat, "Id_Category", "Name_Category",exp.category.Id_Category);
            return View(exp);
        }

        // POST: Expenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Expense expense)
        {
            try
            {
                // TODO: Add update logic here
                _expenseRepo.UpdateElement(id, expense);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int id)
        {
            var exp = _expenseRepo.GetElementById(id);
            return View(exp);
        }

        // POST: Expenses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _expenseRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}