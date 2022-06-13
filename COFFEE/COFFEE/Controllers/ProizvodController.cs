using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COFFEE.Data;
using COFFEE.Models;

namespace COFFEE.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProizvodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proizvod
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Proizvod.Include(p => p.Popust);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Proizvod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = await _context.Proizvod
                .Include(p => p.Popust)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proizvod == null)
            {
                return NotFound();
            }

            return View(proizvod);
        }

        // GET: Proizvod/Create
        public IActionResult Create()
        {
            ViewData["IDPopusta"] = new SelectList(_context.Popust, "ID", "ID");
            return View();
        }

        // POST: Proizvod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naziv,Cijena,VrstaProizvoda,IDPopusta,Ocjena,VrijemeCekanja,NutritivnaVrijednost,NaStanju")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDPopusta"] = new SelectList(_context.Popust, "ID", "ID", proizvod.IDPopusta);
            return View(proizvod);
        }

        // GET: Proizvod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = await _context.Proizvod.FindAsync(id);
            if (proizvod == null)
            {
                return NotFound();
            }
            ViewData["IDPopusta"] = new SelectList(_context.Popust, "ID", "ID", proizvod.IDPopusta);
            return View(proizvod);
        }

        // POST: Proizvod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,Cijena,VrstaProizvoda,IDPopusta,Ocjena,VrijemeCekanja,NutritivnaVrijednost,NaStanju")] Proizvod proizvod)
        {
            if (id != proizvod.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvodExists(proizvod.ID))
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
            ViewData["IDPopusta"] = new SelectList(_context.Popust, "ID", "ID", proizvod.IDPopusta);
            return View(proizvod);
        }

        // GET: Proizvod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = await _context.Proizvod
                .Include(p => p.Popust)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proizvod == null)
            {
                return NotFound();
            }

            return View(proizvod);
        }

        // POST: Proizvod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvod = await _context.Proizvod.FindAsync(id);
            _context.Proizvod.Remove(proizvod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvodExists(int id)
        {
            return _context.Proizvod.Any(e => e.ID == id);
        }
    }
}
