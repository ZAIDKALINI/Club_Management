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
        UnitOfWork UOW;
        public ExpensesRepository()
        {
            UOW = new UnitOfWork();
        }
      
        public void AddNew(Expense expense)
        {
            if (expense.Id_Expense == 0)
            {

                UOW.ExpenseRepo.InsertElement(expense);
                UOW.Save();
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
        }

        public Expense GetElementById(int? id)
        {
            var expense = UOW.ExpenseRepo.GetElements(c => c.Id_Expense == id).FirstOrDefault();
     
            return expense;
        }

        

        public IList<Expense> GetElements()
        {
            var lstExp= UOW.ExpenseRepo.GetElements().ToList();
           
            return lstExp;

        }
        public IList<Expense> GetElements(Func<Expense, bool> exp)
        {
            var lstexpense = UOW.ExpenseRepo.GetElements(exp).ToList();
            var lstCategorie = UOW.ExpenseCategorieRepo.GetElements().ToList();
           
            return lstexpense;
        }


        public void UpdateElement(int id, Expense expense)
        {
            if (id == expense.Id_Expense)
            {
      
                UOW.ExpenseRepo.UpdateElement(expense);
                UOW.Save();
            }
            else
                throw new Exception("Id category dosen't belong to the new category");
        }
    }
}
