using DataAccessLayer;
using Entities.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class PorfolioRepo
    {
        IUnitOfWork<Portfolio> UOW;
        public PorfolioRepo(IUnitOfWork<Portfolio> _UOW)
        {
            UOW = _UOW;
        }
        public void AddNew(Portfolio portfolio)
        {
            if (portfolio.Id == 0)
            {
                portfolio.UpdateDate = DateTime.Now;
                UOW.Entity.InsertElement(portfolio);
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
            var portfolio = GetElementById(id);
            if (portfolio == null)
                throw new Exception("Element not found");
            UOW.Entity.DeleteElement(portfolio);
            UOW.Save();
            UOW.Dispose();
        }

        public Portfolio GetElementById(int? id)
        {
            var portfolio = UOW.Entity.GetElements(c => c.Id == id);
            return portfolio.FirstOrDefault();
        }


        /// <summary>
        /// getAllElement
        /// </summary>
        /// <returns></returns>
        public IList<Portfolio> GetElements()
        {
            return UOW.Entity.GetElements().ToList();
        }
        public IEnumerable<Portfolio> GetElements(Func<Portfolio, bool> expression)
        {
            var lst = UOW.Entity.GetElements(expression);
            return lst;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search">cherche multi cretaire</param>
        /// <returns></returns>
        public IEnumerable<Portfolio> GetElements(string search)
        {

            if (!String.IsNullOrEmpty(search))
            {
                var lst = GetElements(c => c.Description.ToUpper().Contains(search.ToUpper()) || c.UpdateDate.ToString().Contains(search)).ToList();
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
        public IEnumerable<Portfolio> GetElements(string d1, string d2)
        {
            IList<Portfolio> lst;
            var _d1 = Convert.ToDateTime(d1);
            var _d2 = Convert.ToDateTime(d2);
            lst = GetElements().Where(c => c.UpdateDate >= _d1 && c.UpdateDate <= _d2).ToList();
            return lst;

        }

        public void UpdateElement(int id, Portfolio portfolio)
        {
            if (id == portfolio.Id)
            {
                
                portfolio.UpdateDate = DateTime.Now;
                UOW.Entity.UpdateElement(portfolio);
                UOW.Save();
                UOW.Dispose();
            }
            else
                throw new Exception("Id category dosen't belong to the new category");
        }
    }
}
