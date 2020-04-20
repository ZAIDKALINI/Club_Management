using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CoachRepository
    {
        IUnitOfWork<Coach> _uow;
        public CoachRepository(IUnitOfWork<Coach> uow)
        {
            _uow = uow;
        }
        public  void AddNew(Coach coach)
        {
            if (coach.Person_Id == 0)
            {
                coach.DateInscri = DateTime.Now;
                _uow.Entity.InsertElement(coach);
                _uow.Save();
             
            }

            else
                throw new Exception("IdShould be identity");
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new Exception("Id is null");
            var Coach = GetElementById(id);
            if (Coach == null)
                throw new Exception("Element not found");
            _uow.Entity.DeleteElement(Coach);
            _uow.Save();
         
        }

        public Coach GetElementById(int? id)
        {
            var Coach = _uow.Entity.GetElements(c => c.Person_Id == id);
            return Coach.FirstOrDefault();
        }



        public IList<Coach> GetElements()
        {
            return _uow.Entity.GetElements().ToList();
        }
        public IList<Coach> GetElements(Func<Coach, bool> expression)
        {
            return _uow.Entity.GetElements(expression).ToList();
        }
        public IList<Coach> GetElements(string search)
        {
            if(!string.IsNullOrEmpty(search))
            return _uow.Entity.GetElements(c=>c.Last_Name.ToUpper().Contains(search.ToUpper())||c.First_Name.ToUpper().Contains(search.ToUpper())).ToList();
            return _uow.Entity.GetElements().ToList();

        }

        public void UpdateElement(int id, Coach Coach)
        {
            if (id == Coach.Person_Id)
            {
                _uow.Entity.UpdateElement(Coach);
                _uow.Save();
           
            }
            else
                throw new Exception("Id coach dosen't belong to the new coach who you entered");
        }
    }
}
