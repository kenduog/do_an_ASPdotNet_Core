using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Do_an_web_Laptop.Data;
using Do_an_web_Laptop.Models;

namespace Do_an_web_Laptop.Controllers
{
    public class LaptopSeriesController : Controller
    {
        private readonly SaigonStoreContext _context;

        public LaptopSeriesController(SaigonStoreContext context)
        {
            _context = context;
        }

        // GET: LaptopSeries
        public async Task<IActionResult> Index()
        {
            var saigonStoreContext = _context.LaptopSeries.Include(l => l.Manufacture);
            return View(await saigonStoreContext.ToListAsync());
        }

        // GET: LaptopSeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptopSerie = await _context.LaptopSeries
                .Include(l => l.Manufacture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptopSerie == null)
            {
                return NotFound();
            }

            return View(laptopSerie);
        }

        // GET: LaptopSeries/Create
        public IActionResult Create()
        {
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Id");
            return View();
        }

        // POST: LaptopSeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManufactureId,Name,ProductionTime,Status")] LaptopSerie laptopSerie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptopSerie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Id", laptopSerie.ManufactureId);
            return View(laptopSerie);
        }

        // GET: LaptopSeries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptopSerie = await _context.LaptopSeries.FindAsync(id);
            if (laptopSerie == null)
            {
                return NotFound();
            }
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Id", laptopSerie.ManufactureId);
            return View(laptopSerie);
        }

        // POST: LaptopSeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManufactureId,Name,ProductionTime,Status")] LaptopSerie laptopSerie)
        {
            if (id != laptopSerie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptopSerie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopSerieExists(laptopSerie.Id))
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
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Id", laptopSerie.ManufactureId);
            return View(laptopSerie);
        }

        // GET: LaptopSeries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptopSerie = await _context.LaptopSeries
                .Include(l => l.Manufacture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptopSerie == null)
            {
                return NotFound();
            }

            return View(laptopSerie);
        }

        // POST: LaptopSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laptopSerie = await _context.LaptopSeries.FindAsync(id);
            _context.LaptopSeries.Remove(laptopSerie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopSerieExists(int id)
        {
            return _context.LaptopSeries.Any(e => e.Id == id);
        }
    }
}
