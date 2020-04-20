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
        private IUnitOfWork<CustomerPayement> _uowPayment;
        private IUnitOfWork<Customer> _uowCustomer;

        public PayementRepository(IUnitOfWork<CustomerPayement> uowPayement, IUnitOfWork<Customer> uowCustomer)
        {
            _uowPayment = uowPayement;
            _uowCustomer = uowCustomer;
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
                WirteDateEndPayement(payement);
                _uowPayment.Entity.InsertElement(payement);
                _uowPayment.Save();
                ResetRestIsEndForTrue(payement.Person_Id);
               
              
                _uowPayment.Dispose();
            

            }

            else
                throw new Exception("IdShould be identity");
        }
       /// <summary>
       /// set last month on true
       /// </summary>
       /// <param name="id">Customer id who make payement</param>
        public void ResetRestIsEndForFalse(int idPerson)
        {
           var payement= _uowPayment.Entity.GetElements(p => p.IsEnd == true&&p.Person_Id== idPerson).FirstOrDefault();
            if (payement != null)
            {
                payement.IsEnd = false;
                _uowPayment.Save();
                _uowPayment.Dispose();
            }
       
        }
        public void ResetRestIsEndForTrue(int idPerson)
        {
            var payement = _uowPayment.Entity.GetElements(p => p.Person_Id == idPerson).OrderByDescending(p=>p.EndDate).FirstOrDefault();
            var pay = GetElementById(payement.Id);
            if (pay != null)
            {
                pay.IsEnd = true;
                _uowPayment.Entity.UpdateElement(pay);
                _uowPayment.Save();
                _uowPayment.Dispose();
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
            _uowPayment.Entity.DeleteElement(payement);
            _uowPayment.Save();
            _uowPayment.Dispose();
            if (payement.IsEnd)
            {
                ResetRestIsEndForFalseForDelete(personId);
            }

        }
        /// <summary>
        /// reset last month date if deleting last one
        /// </summary>
        /// <param name="id">person id</param>
        public void ResetRestIsEndForFalseForDelete(int? id)
        {            
            var pay = _uowPayment.Entity.GetElements(p => p.Person_Id ==id).OrderByDescending(p => p.EndDate).FirstOrDefault();

            pay.IsEnd = true;
            _uowPayment.Entity.UpdateElement(pay);
            _uowPayment.Save();
            //ResetRestIsEndForTrue(pay.Person_Id);
            //UOW.Save();

            //UOW.Dispose();
        }

        public CustomerPayement GetElementById(int? id)
        {
            var payement = _uowPayment.Entity.GetElements(c => c.Id == id).FirstOrDefault();
          
             payement.customer = _uowCustomer.Entity.GetElements(c => c.Person_Id == payement.Person_Id).FirstOrDefault();
           
            return payement;
        }

      
        public IList<CustomerPayement> GetElements()
        {
            var lst= _uowPayment.Entity.GetElements().ToList();
            foreach (var item in lst)
            {
                item.customer = _uowCustomer.Entity.GetElements(c => c.Person_Id == item.Person_Id).FirstOrDefault();
            }
            return lst;
        }
        public IList<CustomerPayement> GetElements(Func<CustomerPayement,bool> exp)
        {
           var lstPayement= _uowPayment.Entity.GetElements(exp).ToList();
          // var lstCustomer= UOW.CustomeresRepo.GetElements().ToList();
            foreach (var item in lstPayement)
            {
               var customer= _uowCustomer.Entity.GetElements(c => item.Person_Id == c.Person_Id).FirstOrDefault();
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
                _uowPayment.Entity.UpdateElement(payement);
                _uowPayment.Save();
                _uowPayment.Dispose();
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
                //var lst1 = (from c in UOW.Entity.GetElements() group c by c.Person_Id into newGroup select newGroup.);
                var lst = _uowPayment.Entity.GetElements(p => p.EndDate <= DateTime.Now && p.IsEnd==true).ToList();
                foreach (var item in lst)
                {
                    item.customer = _uowCustomer.Entity.GetElements(c => c.Person_Id == item.Person_Id).FirstOrDefault();
                }
                return lst;
            }
        }
        

    }
}

