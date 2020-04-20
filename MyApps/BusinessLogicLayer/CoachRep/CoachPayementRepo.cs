using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    class CoachPayementRepo
    {
        IUnitOfWork<CoachPayement> UOW;
        public CoachPayementRepo(IUnitOfWork<CoachPayement> uow)
        {
            UOW = uow;
        }
     
        public void AddNew(CoachPayement payement)
        {
            if (payement.Id == 0)
            {
               
                UOW.Entity.InsertElement(payement);
                UOW.Save();
        
            }

            else
                throw new Exception("Id Should be identity");
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new Exception("Id is null");
            var payement = GetElementById(id);
            if (payement == null)
                throw new Exception("Element not found");
            UOW.Entity.DeleteElement(payement);
            UOW.Save();
    
        }

        public CoachPayement GetElementById(int? id)
        {
            var payement = UOW.Entity.GetElements(c => c.Id == id);
            return payement.FirstOrDefault();
           
        }


        public IList<CoachPayement> GetElements()
        {
            return UOW.Entity.GetElements().ToList();
        }
        /// <summary>
        /// find by expression linq or lambda
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public IList<CoachPayement> GetElements(Func<CoachPayement, bool> exp)
        {
            var lstPayement = UOW.Entity.GetElements(exp).ToList();

            //var lstCustomer = UOW.CoachRepo.GetElements().ToList();
            //foreach (var item in lstPayement)
            //{
            //    var coach = lstCustomer.FirstOrDefault(c => item.Person_Id == c.Person_Id);
            //    item.Coach = coach;
            //}
            return lstPayement;
        }


        public void UpdateElement(int id, CoachPayement payement)
        {
            if (id == payement.Id)
            {
              
                UOW.Entity.UpdateElement(payement);
                UOW.Save();
   
            }
            else
                throw new Exception("Old id  dosen't belong to the new payement id");
        }
    }
}
