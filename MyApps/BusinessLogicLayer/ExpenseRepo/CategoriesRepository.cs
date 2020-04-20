﻿using DataAccessLayer;
using Entities.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.ExpenseRepo
{
    public class CategoriesRepository
    {
        IUnitOfWork _uow;
        public CategoriesRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void AddNew(Category_expense category)
        {
            _uow.ExpenseCategorieRepo.InsertElement(category);
            _uow.Save();
            _uow.Dispose();
        }
        public Category_expense FindById(int id)
        {
            var cat = _uow.ExpenseCategorieRepo.GetElementByID(id);
            return cat;
        }
        public void Delete(int id)
        {
            var cat = FindById(id);
            if (cat == null)
                throw new Exception("Not found");
            _uow.ExpenseCategorieRepo.DeleteElement(cat);
            _uow.Save();
            _uow.Dispose();
        }
        public void Edit(int id, Category_expense category)
        {
            var cat = FindById(id);
            if(cat==null)
            throw new Exception("Not found");
            _uow.ExpenseCategorieRepo.UpdateElement(category);
            _uow.Save();
            _uow.Dispose();
        }
        public IList<Category_expense> GetCategories()
        {
           return _uow.ExpenseCategorieRepo.GetElements().ToList();
                
        }
        public IList<Category_expense> GetCategories(Func <Category_expense,bool> exp)
        {
           var lst= _uow.ExpenseCategorieRepo.GetElements().Where(exp).ToList();
            return lst;

        }
    }
}
