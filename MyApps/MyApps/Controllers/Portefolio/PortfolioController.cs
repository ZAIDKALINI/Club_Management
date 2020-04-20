using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using DataAccessLayer;
using Entities.Portfolio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApps.Models;

namespace MyApps.Controllers.Portefolio
{
   [Authorize]
    public class PortfolioController : Controller
    {
        private readonly PorfolioRepo _portfolio;
        [Obsolete]
        private readonly IHostingEnvironment _hosting;

        [Obsolete]
        public PortfolioController(IUnitOfWork<Portfolio> uow, IHostingEnvironment hosting)
        {
            _portfolio = new PorfolioRepo(uow);
            _hosting = hosting;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var lst =_portfolio.GetElements();
            return View(lst);
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portfolio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public IActionResult Create(PortfolioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"images\portfolio");
                    string fullPath = Path.Combine(uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                Portfolio portfolio = new Portfolio
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageUrl = model.File.FileName
                };
                _portfolio.AddNew(portfolio);
             
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Portfolio/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = _portfolio.GetElementById(id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }

        // POST: Portfolio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Title,Description,ImageUrl,Id")] Portfolio portfolio)
        {
            if (id != portfolio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _portfolio.UpdateElement(id,portfolio);
                 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioExists(portfolio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(portfolio);
        }

        // GET: Portfolio/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = _portfolio.GetElementById(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // POST: Portfolio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _portfolio.Delete(id);
  
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetPortfolio(int id)
        {
            var portfolio = _portfolio.GetElementById(id);
            return Json(portfolio);
        }
        private bool PortfolioExists(int id)
        {
            return _portfolio.GetElements().Any(e => e.Id == id);
        }
    }
}
