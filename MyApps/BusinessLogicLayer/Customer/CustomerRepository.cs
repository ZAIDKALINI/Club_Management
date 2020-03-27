using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class CustomerRepository
    {
        UnitOfWork UOW;
        public CustomerRepository()
        {
            UOW = new UnitOfWork();
        }
        public void AddNew(Customer customer)
        {
            if (customer.Person_Id == 0)
            {
                customer.DateInscri = DateTime.Now;
                UOW.CustomeresRepo.InsertElement(customer);
                UOW.Save();
            }

            else
                throw new Exception("IdShould be identity");
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new Exception("Id is null");
            var customer = GetElementById(id);
            if (customer == null)
                throw new Exception("Element not found");
            UOW.CustomeresRepo.DeleteElement(customer);
            UOW.Save();
        }

        public Customer GetElementById(int? id)
        {
            var customer = UOW.CustomeresRepo.GetElements(c => c.Person_Id == id);
            return customer.FirstOrDefault();
        }


        /// <summary>
        /// getAllElement
        /// </summary>
        /// <returns></returns>
        public IList<Customer> GetElements()
        {
            return UOW.CustomeresRepo.GetElements().ToList();
        }
        public IEnumerable<Customer> GetElements(Func<Customer, bool> expression)
        {
           var lst= UOW.CustomeresRepo.GetElements(expression);
            return lst;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search">cherche multi cretaire</param>
        /// <returns></returns>
        public IEnumerable<Customer> GetElements(string search)
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
        public IEnumerable<Customer> GetElements(string d1,string d2)
        {
            IList<Customer> lst;
            var _d1 = Convert.ToDateTime(d1);
            var _d2 = Convert.ToDateTime(d2);
            lst = GetElements().Where(c => c.DateInscri >= _d1 && c.DateInscri <= _d2).ToList();
            return lst;

        }

        public void UpdateElement(int id, Customer customer)
        {
            if (id == customer.Person_Id)
            {
               var cust= GetElementById(id);
                customer.DateInscri = cust.DateInscri;
                UOW.CustomeresRepo.UpdateElement(customer);
                UOW.Save();
            }
            else
                throw new Exception("Id category dosen't belong to the new category");
        }
      

    }
}
