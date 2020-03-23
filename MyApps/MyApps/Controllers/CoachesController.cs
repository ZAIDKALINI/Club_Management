using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApps.Controllers
{
    public class CoachesController : Controller
    {
        CoachRepository _repository = new CoachRepository();
        // GET: Coaches
        public ActionResult Index()
        {
            var lst = _repository.GetElements();
      
            return View(lst);
        }

        // GET: Coaches/Details/5
        public ActionResult Details(int id)
        {
            var coach = _repository.GetElementById(id);
            return View(coach);
        }

        // GET: Coaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Entities.Coach coach)
        {
            try
            {
               
                // TODO: Add insert logic here
                _repository.AddNew(coach);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Coaches/Edit/5
        public ActionResult Edit(int id)
        {
            var coach = _repository.GetElementById(id);
            return View(coach);
       
        }

        // POST: Coaches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Entities.Coach collection)
        {
            try
            {
                // TODO: Add update logic here
                _repository.UpdateElement(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Coaches/Delete/5
        public ActionResult Delete(int id)
        {
            var coach = _repository.GetElementById(id);
            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Find(string search)
        {
            //find by first name or last name
            try
            {
                // TODO: Add delete logic here
                var lst = _repository.GetElements(search);
                return View(lst);
            }
            catch
            {
                return View();
            }
        }
    }
}