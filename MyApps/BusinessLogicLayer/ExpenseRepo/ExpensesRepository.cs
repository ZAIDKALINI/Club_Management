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
        IUnitOfWork UOW;
        public ExpensesRepository(IUnitOfWork _uow)
        {
            UOW = _uow;
        }
       
      
        public void AddNew(Expense expense)
        {
            if (expense.Id_Expense == 0)
            {

                UOW.ExpenseRepo.InsertElement(expense);
                UOW.Save();
                UOW.Dispose();
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
            UOW.ExpenseRepo.DeleteElement(expense);
            UOW.Save();
            UOW.Dispose();
        }

        public Expense GetElementById(int? id)
        {
            var expense = UOW.ExpenseRepo.GetElements(c => c.Id_Expense == id).FirstOrDefault();
            //get category for current expense
            var category=GetCategoryForExpense(expense);
           expense= SetCategoryForExpense(expense, category);
            return expense;
        }

        Category_expense GetCategoryForExpense(Expense expense)
        {
            var category = UOW.ExpenseCategorieRepo.GetElements(c => c.Id_Category == expense.Id_Category).FirstOrDefault();
            return category;
        }
        Expense SetCategoryForExpense(Expense expense,Category_expense category_Expense)
        {
            expense.category = category_Expense;
            return expense;
        }

        public IList<Expense> GetElements()
        {
            var lstExp= UOW.ExpenseRepo.GetElements().ToList();
            foreach (var item in lstExp)
            {
               item.category=  GetCategoryForExpense(item);
            }
            return lstExp;

        }
        public IList<Expense> GetElements(Func<Expense, bool> exp)
        {
            var lstexpense = UOW.ExpenseRepo.GetElements(exp).ToList();
            var lstCategorie = UOW.ExpenseCategorieRepo.GetElements().ToList();
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
                expense.category = UOW.ExpenseCategorieRepo.GetElements(c => c.Id_Category == expense.Id_Category).FirstOrDefault();
                UOW.ExpenseRepo.UpdateElement(expense);
                UOW.Save();
                UOW.Dispose();
            }
            else
                throw new Exception("Id category dosen't belong to the new category");
        }
    }
}
