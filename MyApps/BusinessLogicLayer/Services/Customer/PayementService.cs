using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BusinessLogicLayer
{
    public class PayementService
    {
        private IUnitOfWork<CustomerPayement> _uowPayment;


        public PayementService(IUnitOfWork<CustomerPayement> uowPayement)
        {
            _uowPayment = uowPayement;
           
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
           var payement= _uowPayment.Entity.GetWithItems(p => p.IsEnd == true&&p.Person_Id== idPerson).FirstOrDefault();
            if (payement != null)
            {
                payement.IsEnd = false;
                _uowPayment.Save();
                _uowPayment.Dispose();
            }
       
        }
        public void ResetRestIsEndForTrue(int idPerson)
        {
            var payement = _uowPayment.Entity.GetWithItems(p => p.Person_Id == idPerson).OrderByDescending(p=>p.EndDate).FirstOrDefault();
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
            var pay = _uowPayment.Entity.GetWithItems(p => p.Person_Id ==id,c=>c.customer).OrderByDescending(p => p.EndDate).FirstOrDefault();

            pay.IsEnd = true;
            _uowPayment.Entity.UpdateElement(pay);
            _uowPayment.Save();
            //ResetRestIsEndForTrue(pay.Person_Id);
            //UOW.Save();

            //UOW.Dispose();
        }
        /// <summary>
        /// get payement by id
        /// </summary>
        /// <param name="id">id payement</param>
        /// <returns>Customer payement</returns>
        public CustomerPayement GetElementById(int? id)
        {
            var payement = _uowPayment.Entity.GetWithItems(c => c.Id == id,customer=>customer).FirstOrDefault();
          
            // payement.customer = _uowCustomer.Entity.GetElements(c => c.Person_Id == payement.Person_Id).FirstOrDefault();
           
            return payement;
        }
        /// <summary>
        /// get payment by customer spesific
        /// </summary>
        /// <param name="id">Customer</param>
        /// <returns>List payment</returns>
        public List<CustomerPayement> GetPayementByCustomer(int id)
        {
            var payement = _uowPayment.Entity.GetWithItems(c => c.Person_Id == id, customer => customer.customer).ToList();
            return payement;
        }
        public IList<CustomerPayement> GetElements()
        {
            var lst= _uowPayment.Entity.GetWithItems(c=>c.customer).ToList();
            return lst;
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
               
                var lst = _uowPayment.Entity.GetWithItems(p => p.EndDate <= DateTime.Now && p.IsEnd==true,c=>c.customer).ToList();
              
                return lst;
            }
        }
        

    }
}

