using DataAccessLayer;
using Entities.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.ExpenseRepo
{
    public class ExpensesService
    {
        private IUnitOfWork<Expense> _uowExpense;
       

        public ExpensesService(IUnitOfWork<Expense> uowExpense)
        {
            _uowExpense = uowExpense;
          
        }
       
      
        public void AddNew(Expense expense)
        {
            if (expense.Id_Expense == Guid.Empty)
            {

                _uowExpense.Entity.InsertElement(expense);
                _uowExpense.Save();
                _uowExpense.Dispose();
            }

            else
                throw new Exception("IdShould be identity");
        }

        public void Delete(Guid id)
        {
            if (id == null)
                throw new Exception("Id is null");
            var expense = GetElementById(id);
            if (expense == null)
                throw new Exception("Element not found");
            _uowExpense.Entity.DeleteElement(expense);
            _uowExpense.Save();
            _uowExpense.Dispose();
        }

        public Expense GetElementById(Guid id)
        {
            var expense = _uowExpense.Entity.GetWithItems(c => c.Id_Expense == id,e=>e.category).FirstOrDefault();
            return expense;
        }

      

        public IList<Expense> GetElements()
        {
            var lstExp= _uowExpense.Entity.GetWithItems(e=>e.category).ToList();
           
            return lstExp;

        }
        


        public void UpdateElement(Guid id, Expense expense)
        {
            if (id == expense.Id_Expense)
            {
               // expense.category = _uowCategory.Entity.GetElements(c => c.Id_Category == expense.Id_Category).FirstOrDefault();
                _uowExpense.Entity.UpdateElement(expense);
                _uowExpense.Save();
                _uowExpense.Dispose();
            }
            else
                throw new Exception("Id category dosen't belong to the new category");
        }
    }
}
