﻿using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    class PersonService 
    {
        IUnitOfWork<Customer> UOW;
        public PersonService(IUnitOfWork<Customer> _UOW)
        {
            UOW = _UOW;
        }
        public virtual void AddNew(Customer person)
        {
            if (person.Person_Id == 0)
            {
                person.DateInscri = DateTime.Now;
                UOW.Entity.InsertElement(person);
                UOW.Save();
                UOW.Dispose();
                
            }

            else
                throw new Exception("IdShould be identity");
        }

        public virtual void Delete(int? id)
        {
            if (id == null)
                throw new Exception("Id is null");
            var customer = GetElementById(id);
            if (customer == null)
                throw new Exception("Element not found");
            UOW.Entity.DeleteElement(customer);
            UOW.Save();
            UOW.Dispose();
        }

        public virtual Customer GetElementById(int? id)
        {
            var customer = UOW.Entity.GetElements(c => c.Person_Id == id);
            return customer.FirstOrDefault();
        }


        /// <summary>
        /// getAllElement
        /// </summary>
        /// <returns></returns>
        public virtual IList<Customer> GetElements()
        {
            return UOW.Entity.GetElements().ToList();
        }
        public virtual IEnumerable<Customer> GetElements(Func<Customer, bool> expression)
        {
            var lst = UOW.Entity.GetElements(expression);
            return lst;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search">cherche multi cretaire</param>
        /// <returns></returns>
        public virtual IEnumerable<Customer> GetElements(string search)
        {

            if (!String.IsNullOrEmpty(search))
            {
                var lst = GetElements(c => c.First_Name.ToUpper().Contains(search.ToUpper()) || c.Last_Name.ToUpper().Contains(search.ToUpper())).ToList();
                return lst;
            }


            var lst1 = GetElements();
            return lst1;


        }
        /// <summary>
        /// Search by date
        /// date range
        /// </summary>
        /// <param name="d1">First date</param>
        /// <param name="d2">Last date</param>
        /// <returns></returns>
        public virtual IEnumerable<Customer> GetElements(string d1, string d2)
        {
            IList<Customer> lst;
            var _d1 = Convert.ToDateTime(d1);
            var _d2 = Convert.ToDateTime(d2);
            lst = GetElements().Where(c => c.DateInscri >= _d1 && c.DateInscri <= _d2).ToList();
            return lst;

        }

        public virtual void UpdateElement(int id, Customer customer)
        {
            if (id == customer.Person_Id)
            {
                //set date inscri 
                var cus = GetElementById(id);
                customer.DateInscri = cus.DateInscri;
                UOW.Entity.UpdateElement(customer);
                UOW.Save();
                UOW.Dispose();
            }
            else
                throw new Exception("Id category dosen't belong to the new category");
        }

    }
    }
