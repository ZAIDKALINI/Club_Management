using DataAccessLayer;
using Entities.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.ExpenseRepo
{
    public class ExpensesRepository
    {
        IUnitOfWork<Expense> _uowExpense;
        IUnitOfWork<Category_expense> _uowCategory;
        public ExpensesRepository(IUnitOfWork<Expense> uowExpense, IUnitOfWork<Category_expense> uowCategory)
        {
            _uowExpense = uowExpense;
            _uowCategory = uowCategory;
        }
       
      
        public void AddNew(Expense expense)
        {
            if (expense.Id_Expense == 0)
            {

                _uowExpense.Entity.InsertElement(expense);
                _uowExpense.Save();
            
            }

            else
                throw new Exception("IdShould be identity");
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new Exception("Id is null");
            var expense = GetElementById(id);
            if (expense == null)
                throw new Exception("Element not found");
            _uowExpense.Entity.DeleteElement(expense);
            _uowExpense.Save();
           
        }

        public Expense GetElementById(int? id)
        {
            var expense = _uowExpense.Entity.GetElements(c => c.Id_Expense == id).FirstOrDefault();
            //get category for current expense
            var category = GetCategoryForExpense(expense);
            expense = SetCategoryForExpense(expense, category);
            return expense;
        }

        Category_expense GetCategoryForExpense(Expense expense)
        {
            var category = _uowCategory.Entity.GetElements(c => c.Id_Category == expense.Id_Category).FirstOrDefault();
            return category;
        }
        Expense SetCategoryForExpense(Expense expense,Category_expense category_Expense)
        {
            expense.category = category_Expense;
            return expense;
        }

        public IList<Expense> GetElements()
        {
            var lstExp= _uowExpense.Entity.GetElements().ToList();
            foreach (var item in lstExp)
            {
                item.category = GetCategoryForExpense(item);
            }
            return lstExp;

        }
        public IList<Expense> GetElements(Func<Expense, bool> exp)
        {
            var lstexpense = _uowExpense.Entity.GetElements(exp).ToList();
            var lstCategorie = _uowCategory.Entity.GetElements().ToList();
            foreach (var item in lstexpense)
            {
                var categorie = lstCategorie.FirstOrDefault(c => item.Id_Category == c.Id_Category);
                item.category = categorie;
            }
            return lstexpense;
        }


        public void UpdateElement(int id, Expense expense)
        {
            if (id == expense.Id_Expense)
            {
                //expense.category = UOW.ExpenseCategorieRepo.GetElements(c => c.Id_Category == expense.Id_Category).FirstOrDefault();
                _uowExpense.Entity.UpdateElement(expense);
                _uowExpense.Save();
            
            }
            else
                throw new Exception("Id category dosen't belong to the new category");
        }
    }
}
