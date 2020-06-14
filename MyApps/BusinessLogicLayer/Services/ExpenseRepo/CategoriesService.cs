using DataAccessLayer;
using Entities.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.ExpenseRepo
{
    public class CategoriesService
    {
        IUnitOfWork<Category_expense> _uow;
        public CategoriesService(IUnitOfWork<Category_expense> uow)
        {
            _uow = uow;
        }
        public void AddNew(Category_expense category)
        {
            _uow.Entity.InsertElement(category);
            _uow.Save();
          
        }
        public Category_expense FindById(Guid id)
        {
            var cat = _uow.Entity.GetElementByID(id);
            return cat;
        }
        public void Delete(Guid id)
        {
            var cat = FindById(id);
            if (cat == null)
                throw new Exception("Not found");
            _uow.Entity.DeleteElement(cat);
            _uow.Save();
         
        }
        public void Edit(Guid id, Category_expense category)
        {
            var cat = FindById(id);
            if(cat==null)
            throw new Exception("Not found");
            _uow.Entity.UpdateElement(category);
            _uow.Save();
           
        }
        public IList<Category_expense> GetCategories()
        {
           return _uow.Entity.GetElements().ToList();
                
        }
        public IList<Category_expense> GetCategories(Func <Category_expense,bool> exp)
        {
           var lst= _uow.Entity.GetElements().Where(exp).ToList();
            return lst;

        }
    }
}
