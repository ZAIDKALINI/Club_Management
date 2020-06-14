using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using CustomException;
using DataAccessLayer;
using Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApps.Alerts;
using MyApps.Feautures;
using MyApps.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MyApps.Controllers
{
   // [Authorize(Roles ="Admin")]
    public class CoachesController : Controller
    {
        CoachService _repository;
        private readonly IHostEnvironment _hosting;

        public ILogger<CoachesController> logger { get; }

        [Obsolete]
        public CoachesController(IUnitOfWork<Coach> uow, IHostEnvironment _hosting,ILogger<CoachesController> logger)
        {
            _repository = new CoachService(uow);
            this._hosting = _hosting;
            this.logger = logger;
        }
        // GET: Coaches
        public ActionResult Index(int page=1)
        {
           
            var lst = _repository.GetElements(page,6);
      
            return View(lst);
        }

        // GET: Coaches/Details/5
        public ActionResult Details(Guid id)
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
    
        public IActionResult Create(CreatePersonViewModel model)
        {
            try
            {

                // TODO: Add insert logic here
                // TODO: Add insert logic here
                //if (ModelState.IsValid)
                //{
                    UploadFile upload = new UploadFile(_hosting);
                    string uniqueFileName = upload.UploadedFile(model.image, @"wwwroot\images\People");


                    _repository.AddNew(new Coach()
                    {
                        Adresse = model.Adresse,
                        CreatedBy = User.Identity.Name,
                        DateOfBirth = model.DateOfBirth,
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        genre = model.genre,
                        image = uniqueFileName,
                        Phone = model.Phone
                    });

                    return RedirectToAction(nameof(Index)).WithSuccess("Ajouter", "vous avez ajouté avec succès ");
                //}
                //return View().WithDanger("Ajouter", "Echeq d'ajout !!!");
            }
            catch (AjouterException e)
            {
                return View().WithDanger("ERREUR", e.Message);
            }
        }

        // GET: Coaches/Edit/5
        public ActionResult Edit(Guid id)
        {
            var coach = _repository.GetElementById(id);
         
            CreatePersonViewModel model = new CreatePersonViewModel()
            {
                Person_Id = id,
                Adresse = coach.Adresse,
                DateOfBirth = coach.DateOfBirth,
                First_Name = coach.First_Name,
                Last_Name = coach.Last_Name,
                genre = coach.genre,
                ImageUrl = coach.image,
                Phone = coach.Phone
            };
            return View(model);

        }

        // POST: Coaches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public IActionResult Edit(Guid id, CreatePersonViewModel model)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    UploadFile upload = new UploadFile(_hosting);
                    var newPath = upload.UploadedFile(model.image, model.ImageUrl, @"wwwroot\images\People") ?? String.Empty;


                    _repository.UpdateElement(id, new Coach()
                    {
                        Person_Id = model.Person_Id,
                        Adresse = model.Adresse,
                        CreatedBy = User.Identity.Name,
                        DateOfBirth = model.DateOfBirth,
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        genre = model.genre,
                        image = newPath,
                        Phone = model.Phone
                    });

                    return RedirectToAction(nameof(Index)).WithSuccess("Modifier", "vous avez modifié avec succès ");
                }
                return View().WithDanger("Modifier", "Echeq de modifier");
            }
            catch(ModifierException e)
            {
                return View().WithDanger("ERREUR", e.Message); 
            }
        }

        // GET: Coaches/Delete/5
        public ActionResult Delete(Guid id)
        {
            var coach = _repository.GetElementById(id);
            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            var coach = _repository.GetElementById(id);
            try
            {
                // TODO: Add delete logic here
                _repository.Delete(id);

                return RedirectToAction(nameof(Index)).WithSuccess("Supprimer", "vous avez supprimé avec succès "); ;
            }
          
            catch (DbUpdateException ex)
            {

                //Log the exception to a file. We discussed logging to a file
                // using Nlog in Part 63 of ASP.NET Core tutorial
                logger.LogError($"Exception Occured : {ex}");
                // Pass the ErrorTitle and ErrorMessage that you want to show to
                // the user using ViewBag. The Error view retrieves this data
                // from the ViewBag and displays to the user.
                ViewBag.ErrorTitle = $" Le coach \"{coach.First_Name+" "+coach.Last_Name}\" est en cours d'utilisation";
                ViewBag.ErrorMessage = $"Le coach  {coach.First_Name + " " + coach.Last_Name} ne peut pas être supprimé car il y a des activités dans ce coach. Si vous souhaitez supprimer ce coach, veuillez supprimer les activités du coach, puis essayez de supprimer";
                return View("Error");
            }
        
        }
        public ActionResult Find(string search,string createdBy)
        {
            //find by first name or last name
            try
            {
                // TODO: Add delete logic here
                var lst = _repository.GetElements(search,createdBy);
                return View(lst);
            }
            catch
            {
                return View();
            }
        }
    }
}