using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rfidtag.Data;
using rfidtag.Models;

namespace rfidtag.Controllers
{
    public class DashboardController : Controller
    {
        private readonly rfidtagContext _context;

        public DashboardController(rfidtagContext context)
        {
            _context = context;
        }

        // GET: Dashboard
        public async Task<IActionResult> Index()
        {
              return _context.Supply != null ? 
                          View(await _context.Supply.ToListAsync()) :
                          Problem("Entity set 'rfidtagContext.Supply'  is null.");
        }

        // GET: Dashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Supply == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // GET: Dashboard/Create
        public IActionResult Create()
        {

            ViewBag.Rand = new Random().Next();
            return View();
        }

        // POST: Dashboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RfidNo,Owner,Location,Gender,Contact,BirthDate,HealthStatus")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supply);
        }

        // GET: Dashboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Supply == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }
            return View(supply);
        }

        // POST: Dashboard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RfidNo,Owner,Location,Gender,Contact,BirthDate,HealthStatus")] Supply supply)
        {
            if (id != supply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyExists(supply.Id))
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
            return View(supply);
        }

        // GET: Dashboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Supply == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // POST: Dashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Supply == null)
            {
                return Problem("Entity set 'rfidtagContext.Supply'  is null.");
            }
            var supply = await _context.Supply.FindAsync(id);
            if (supply != null)
            {
                _context.Supply.Remove(supply);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplyExists(int id)
        {
          return (_context.Supply?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
