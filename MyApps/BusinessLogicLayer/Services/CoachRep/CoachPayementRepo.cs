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
        public IUnitOfWork<CoachPayement> _uowPayement { get; }

        private IUnitOfWork<Coach> _uowCoach;

        public CoachPayementRepo(IUnitOfWork<CoachPayement> uowPayement, IUnitOfWork<Coach> uowCoach)
        {
            _uowPayement = uowPayement;
            _uowCoach = uowCoach;
        }


        public void AddNew(CoachPayement payement)
        {
            if (payement.Id == 0)
            {
               
                _uowPayement.Entity.InsertElement(payement);
                _uowPayement.Save();
                _uowPayement.Dispose();
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
            _uowPayement.Entity.DeleteElement(payement);
            _uowPayement.Save();
            _uowPayement.Dispose();
        }

        public CoachPayement GetElementById(int? id)
        {
            var payement = _uowPayement.Entity.GetElements(c => c.Id == id);
            return payement.FirstOrDefault();
           
        }


        public IList<CoachPayement> GetElements()
        {
            return _uowPayement.Entity.GetElements().ToList();
        }
        /// <summary>
        /// find by expression linq or lambda
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public IList<CoachPayement> GetElements(Func<CoachPayement, bool> exp)
        {
            var lstPayement = _uowPayement.Entity.GetElements(exp).ToList();
            var lstCustomer = _uowCoach.Entity.GetElements().ToList();
            foreach (var item in lstPayement)
            {
                var coach = lstCustomer.FirstOrDefault(c => item.Person_Id == c.Person_Id);
                item.Coach = coach;
            }
            return lstPayement;
        }


        public void UpdateElement(int id, CoachPayement payement)
        {
            if (id == payement.Id)
            {
              
                _uowPayement.Entity.UpdateElement(payement);
                _uowPayement.Save();
                _uowPayement.Dispose();
            }
            else
                throw new Exception("Old id  dosen't belong to the new payement id");
        }
    }
}
