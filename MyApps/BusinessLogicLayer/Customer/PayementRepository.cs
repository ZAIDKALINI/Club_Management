using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class PayementRepository
    {
        UnitOfWork UOW;
        public PayementRepository()
        {
            UOW = new UnitOfWork();
        }
        public void WirteDateEndPayement(CustomerPayement payement)
        {
            DateTime endDate = payement.Payement_date.AddMonths(payement.duration);
            payement.EndDate = endDate;
        }
        public void AddNew(CustomerPayement payement)
        {
            if (payement.Id == 0)
            {
                ResetRestIsEndForFalse(payement.Person_Id);
                payement.IsEnd = true;
                WirteDateEndPayement(payement);
                UOW.PayementsRepo.InsertElement(payement);
                UOW.Save();
             
            }

            else
                throw new Exception("IdShould be identity");
        }
       /// <summary>
       /// set last month on true
       /// </summary>
       /// <param name="id">Customer id who make payement</param>
        private void ResetRestIsEndForFalse(int id)
        {
           var payement= UOW.PayementsRepo.GetElements(p => p.IsEnd == true&&p.Person_Id==id).FirstOrDefault();
            if (payement != null)
            {
                payement.IsEnd = false;
                UOW.PayementsRepo.UpdateElement(payement);
                UOW.Save();
            }
       
        }
        /// <summary>
        /// Delete payement
        /// </summary>
        /// <param name="id">payement id</param>
        public void Delete(int? id)
        {
            if (id == null)
                throw new Exception("Id is null");
            var payement = GetElementById(id);
            if (payement == null)
                throw new Exception("Element not found");
           
            int personId = payement.Person_Id;
            UOW.PayementsRepo.DeleteElement(payement);
            UOW.Save();
            if (payement.IsEnd)
            {
                ResetRestIsEndForFalseForDelete(personId);
            }

        }
        /// <summary>
        /// reset last month date if deleting last one
        /// </summary>
        /// <param name="id">person id</param>
        private void ResetRestIsEndForFalseForDelete(int? id)
        {            
            var pay = UOW.PayementsRepo.GetElements(p => p.Person_Id ==id).OrderByDescending(p => p.EndDate).FirstOrDefault();
            pay.IsEnd = true;
            UOW.PayementsRepo.UpdateElement(pay);
            UOW.Save();
        }

        public CustomerPayement GetElementById(int? id)
        {
            var payement = UOW.PayementsRepo.GetElements(c => c.Id == id).FirstOrDefault();
          
             payement.customer = UOW.CustomeresRepo.GetElements(c => c.Person_Id == payement.Person_Id).FirstOrDefault();
           
            return payement;
        }

      
        public IList<CustomerPayement> GetElements()
        {
            var lst= UOW.PayementsRepo.GetElements().ToList();
            foreach (var item in lst)
            {
                item.customer = UOW.CustomeresRepo.GetElements(c => c.Person_Id == item.Person_Id).FirstOrDefault();
            }
            return lst;
        }
        public IList<CustomerPayement> GetElements(Func<CustomerPayement,bool> exp)
        {
           var lstPayement= UOW.PayementsRepo.GetElements(exp).ToList();
          // var lstCustomer= UOW.CustomeresRepo.GetElements().ToList();
            foreach (var item in lstPayement)
            {
               var customer= UOW.CustomeresRepo.GetElements(c => item.Person_Id == c.Person_Id).FirstOrDefault();
                item.customer = customer;
            }
            return lstPayement;
        }


        public void UpdateElement(int id, CustomerPayement payement)
        {
            if (id == payement.Id)
            {
                DateTime endDate = payement.Payement_date.AddMonths(payement.duration);
                payement.EndDate = endDate;
                UOW.PayementsRepo.UpdateElement(payement);
                UOW.Save();
                ResetRestIsEndForFalseForDelete(payement.Person_Id);
            }
            else
                throw new Exception("Id category dosen't belong to the new category");
        }
        /// <summary>
        /// Get all element who end thier payement
        /// </summary>
        public IList<CustomerPayement> GetCustomersEndthierMonth 
        {
            get 
            {
                //var lst1 = (from c in UOW.PayementsRepo.GetElements() group c by c.Person_Id into newGroup select newGroup.);
                var lst = UOW.PayementsRepo.GetElements(p => p.EndDate <= DateTime.Now && p.IsEnd==true).ToList();
                foreach (var item in lst)
                {
                    item.customer = UOW.CustomeresRepo.GetElements(c => c.Person_Id == item.Person_Id).FirstOrDefault();
                }
                return lst;
            }
        }
        

    }
}

