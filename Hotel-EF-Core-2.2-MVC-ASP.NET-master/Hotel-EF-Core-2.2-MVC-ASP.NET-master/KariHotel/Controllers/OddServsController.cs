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
    public class OddServsController : Controller
    {
        private readonly HotelContext _context;

        public OddServsController(HotelContext context)
        {
            _context = context;
        }

        // GET: OddServs
        public async Task<IActionResult> Index()
        {
            return View(await _context.OddServ.ToListAsync());
        }

        // GET: OddServs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oddServ = await _context.OddServ
                .FirstOrDefaultAsync(m => m.OddServID == id);
            if (oddServ == null)
            {
                return NotFound();
            }

            return View(oddServ);
        }

        // GET: OddServs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OddServs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OddServID,Name,Price")] OddServ oddServ)
        {
            try
            {
                if (ModelState.IsValid)
            {
                _context.Add(oddServ);
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
            return View(oddServ);
        }

        // GET: OddServs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oddServ = await _context.OddServ.FindAsync(id);
            if (oddServ == null)
            {
                return NotFound();
            }
            return View(oddServ);
        }

        // POST: OddServs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OddServID,Name,Price")] OddServ oddServ)
        {
            if (id != oddServ.OddServID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oddServ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OddServExists(oddServ.OddServID))
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
            return View(oddServ);
        }

        // GET: OddServs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oddServ = await _context.OddServ
                .FirstOrDefaultAsync(m => m.OddServID == id);
            if (oddServ == null)
            {
                return NotFound();
            }

            return View(oddServ);
        }

        // POST: OddServs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oddServ = await _context.OddServ.FindAsync(id);
            _context.OddServ.Remove(oddServ);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OddServExists(int id)
        {
            return _context.OddServ.Any(e => e.OddServID == id);
        }
    }
}
