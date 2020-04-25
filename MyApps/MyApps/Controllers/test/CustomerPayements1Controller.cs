using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Entities;

namespace MyApps.Controllers.test
{
    public class CustomerPayements1Controller : Controller
    {
        private readonly App_Context _context;

        public CustomerPayements1Controller(App_Context context)
        {
            _context = context;
        }

        // GET: CustomerPayements1
        public async Task<IActionResult> Index()
        {
            var app_Context = _context.CustomerPayements.Include(c => c.customer);
            return View(await app_Context.ToListAsync());
        }

        // GET: CustomerPayements1/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPayement = await _context.CustomerPayements
                .Include(c => c.customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerPayement == null)
            {
                return NotFound();
            }

            return View(customerPayement);
        }

        // GET: CustomerPayements1/Create
        public IActionResult Create()
        {
            ViewData["Person_Id"] = new SelectList(_context.Customers, "Person_Id", "Person_Id");
            return View();
        }

        // POST: CustomerPayements1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Person_Id,duration,EndDate,IsEnd,Id,Ref,Price,Payement_date")] CustomerPayement customerPayement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerPayement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Person_Id"] = new SelectList(_context.Customers, "Person_Id", "Person_Id", customerPayement.Person_Id);
            return View(customerPayement);
        }

        // GET: CustomerPayements1/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPayement = await _context.CustomerPayements.FindAsync(id);
            if (customerPayement == null)
            {
                return NotFound();
            }
            ViewData["Person_Id"] = new SelectList(_context.Customers, "Person_Id", "Person_Id", customerPayement.Person_Id);
            return View(customerPayement);
        }

        // POST: CustomerPayements1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Person_Id,duration,EndDate,IsEnd,Id,Ref,Price,Payement_date")] CustomerPayement customerPayement)
        {
            if (id != customerPayement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerPayement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerPayementExists(customerPayement.Id))
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
            ViewData["Person_Id"] = new SelectList(_context.Customers, "Person_Id", "Person_Id", customerPayement.Person_Id);
            return View(customerPayement);
        }

        // GET: CustomerPayements1/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPayement = await _context.CustomerPayements
                .Include(c => c.customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerPayement == null)
            {
                return NotFound();
            }

            return View(customerPayement);
        }

        // POST: CustomerPayements1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerPayement = await _context.CustomerPayements.FindAsync(id);
            _context.CustomerPayements.Remove(customerPayement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerPayementExists(Guid id)
        {
            return _context.CustomerPayements.Any(e => e.Id == id);
        }
    }
}
