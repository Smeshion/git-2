using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KariHotel.Data;
using KariHotel.Models;

namespace KariHotel.Controllers
{
    public class FinesController : Controller
    {
        private readonly HotelContext _context;

        public FinesController(HotelContext context)
        {
            _context = context;
        }

        // GET: Fines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fines.ToListAsync());
        }

        // GET: Fines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fines = await _context.Fines
                .FirstOrDefaultAsync(m => m.FinesID == id);
            if (fines == null)
            {
                return NotFound();
            }

            return View(fines);
        }

        // GET: Fines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinesID,Name,Price")] Fines fines)
        {
            try
            {
                if (ModelState.IsValid)
            {
                _context.Add(fines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(fines);
        }

        // GET: Fines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fines = await _context.Fines.FindAsync(id);
            if (fines == null)
            {
                return NotFound();
            }
            return View(fines);
        }

        // POST: Fines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price")] Fines fines)
        {
            if (id != fines.FinesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinesExists(fines.FinesID))
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
            return View(fines);
        }

        // GET: Fines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fines = await _context.Fines
                .FirstOrDefaultAsync(m => m.FinesID == id);
            if (fines == null)
            {
                return NotFound();
            }

            return View(fines);
        }

        // POST: Fines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fines = await _context.Fines.FindAsync(id);
            _context.Fines.Remove(fines);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinesExists(int id)
        {
            return _context.Fines.Any(e => e.FinesID == id);
        }
    }
}
