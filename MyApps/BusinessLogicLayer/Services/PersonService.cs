using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class PersonService<T>where T : Person
    {
        IUnitOfWork<T> UOW;
        public PersonService(IUnitOfWork<T> _UOW)
        {
            UOW = _UOW;
        }
        public virtual void AddNew(T person)
        {
            if (person.Person_Id==Guid.Empty)
            {
                person.DateInscri = DateTime.Now;
                
                UOW.Entity.InsertElement(person);
                UOW.Save();
                UOW.Dispose();
                
            }

            else
                throw new Exception("IdShould be identity");
        }

        public virtual void Delete(Guid id)
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

        public virtual T GetElementById(Guid id)
        {
            var customer = UOW.Entity.GetElements(c => c.Person_Id == id);
            return customer.FirstOrDefault();
        }


        /// <summary>
        /// getAllElement
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> GetElements()
        {
            return UOW.Entity.GetElements().ToList();
        }
        public virtual IEnumerable<T> GetElements(Func<T, bool> expression)
        {
            var lst = UOW.Entity.GetElements(expression);
            return lst;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search">cherche multi cretaire</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetElements(string search)
        {
            search = System.Text.RegularExpressions.Regex.Replace(search, @"\s{2,}", " ");
            if (!String.IsNullOrEmpty(search))
            {
                var lst = GetElements(c => c.First_Name.ToUpper().Contains(search.ToUpper()) || c.Last_Name.ToUpper().Contains(search.ToUpper()) || (c.First_Name.ToUpper()+" "+ c.Last_Name.ToUpper()).Contains(search.ToUpper()) || (c.Last_Name.ToUpper() + " " + c.First_Name.ToUpper()).Contains(search.ToUpper()));
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
        public virtual IEnumerable<T> GetElements(string d1, string d2)
        {
            IList<T> lst;
            var _d1 = Convert.ToDateTime(d1);
            var _d2 = Convert.ToDateTime(d2);
            lst = GetElements().Where(c => c.DateInscri >= _d1 && c.DateInscri <= _d2 ).ToList();
            return lst;

        }

        public virtual void UpdateElement(Guid id, T Person)
        {
            if (id == Person.Person_Id)
            {
                //set date inscri 
                var cus = GetElementById(id);
                Person.DateInscri = cus.DateInscri;
                UOW.Entity.UpdateElement(Person);
                UOW.Save();
                UOW.Dispose();
            }
            else
                throw new Exception("Id category dosen't belong to the new category");
        }
       

    }
}
