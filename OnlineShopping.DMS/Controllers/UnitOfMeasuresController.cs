using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DMS.Data;
using OnlineShopping.DMS.Models;

namespace OnlineShopping.DMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UnitOfMeasuresController : Controller
    {
        private readonly ShopDbContext _context;

        public UnitOfMeasuresController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: UnitOfMeasures
        public async Task<IActionResult> Index()
        {
              return _context.UnitsOfMeasure != null ? 
                          View(await _context.UnitsOfMeasure.ToListAsync()) :
                          Problem("Entity set 'ShopDbContext.UnitsOfMeasure'  is null.");
        }

        // GET: UnitOfMeasures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnitsOfMeasure == null)
            {
                return NotFound();
            }

            var unitOfMeasure = await _context.UnitsOfMeasure
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            return View(unitOfMeasure);
        }

        // GET: UnitOfMeasures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitOfMeasures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UOM,Description")] UnitOfMeasure unitOfMeasure)
        {
            
                _context.Add(unitOfMeasure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          
        }

        // GET: UnitOfMeasures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnitsOfMeasure == null)
            {
                return NotFound();
            }

            var unitOfMeasure = await _context.UnitsOfMeasure.FindAsync(id);
            if (unitOfMeasure == null)
            {
                return NotFound();
            }
            return View(unitOfMeasure);
        }

        // POST: UnitOfMeasures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UOM,Description")] UnitOfMeasure unitOfMeasure)
        {
            if (id != unitOfMeasure.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitOfMeasure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitOfMeasureExists(unitOfMeasure.ID))
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
            return View(unitOfMeasure);
        }

        // GET: UnitOfMeasures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnitsOfMeasure == null)
            {
                return NotFound();
            }

            var unitOfMeasure = await _context.UnitsOfMeasure
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            return View(unitOfMeasure);
        }

        // POST: UnitOfMeasures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnitsOfMeasure == null)
            {
                return Problem("Entity set 'ShopDbContext.UnitsOfMeasure'  is null.");
            }
            var unitOfMeasure = await _context.UnitsOfMeasure.FindAsync(id);
            if (unitOfMeasure != null)
            {
                _context.UnitsOfMeasure.Remove(unitOfMeasure);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitOfMeasureExists(int id)
        {
          return (_context.UnitsOfMeasure?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
