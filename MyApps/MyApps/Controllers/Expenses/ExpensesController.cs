﻿using System;
using BusinessLogicLayer.ExpenseRepo;
using CustomException;
using DataAccessLayer;
using Entities.Expenses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApps.Alerts;

namespace MyApps.Controllers.Expenses
{
    public class ExpensesController : Controller
    {
        ExpensesRepository _expenseRepo;
        CategoriesRepository _categorieExpense;
        public ExpensesController(IUnitOfWork<Expense> uowExpense, IUnitOfWork<Category_expense> uowCategorie)
        {
             _expenseRepo = new ExpensesRepository(uowExpense, uowCategorie);
             _categorieExpense = new CategoriesRepository(uowCategorie);
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
        public IActionResult Create(Expense expense)
        {
            try
            {
                // TODO: Add insert logic here
                _expenseRepo.AddNew(expense);
                return RedirectToAction(nameof(Index)).WithSuccess("Ajouter", "vous avez ajouté avec succès ");
            }
            catch(AjouterException e)
            {
         
                return View().WithDanger("ERREUR", e.Message); 
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
        public IActionResult Edit(int id, Expense expense)
        {
            try
            {
                // TODO: Add update logic here
                _expenseRepo.UpdateElement(id, expense);

                return RedirectToAction(nameof(Index)).WithSuccess("Modifier", "vous avez modifié avec succès "); 
            }
            catch(ModifierException e)
            {
                return View().WithDanger("ERREUR", e.Message); 
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
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _expenseRepo.Delete(id);
                return RedirectToAction(nameof(Index)).WithSuccess("Supprimer", "vous avez supprimé avec succès ");
            }
            catch(SupprimerException e)
            {
                return View().WithDanger("ERREUR", e.Message); 
            }
        }
    }
}