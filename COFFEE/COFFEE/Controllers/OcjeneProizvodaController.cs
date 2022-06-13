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
    public class OcjeneProizvodaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OcjeneProizvodaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OcjeneProizvoda
        public async Task<IActionResult> Index()
        {
            return View(await _context.OcjeneProizvoda.ToListAsync());
        }

        // GET: OcjeneProizvoda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocjeneProizvoda = await _context.OcjeneProizvoda
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ocjeneProizvoda == null)
            {
                return NotFound();
            }

            return View(ocjeneProizvoda);
        }

        // GET: OcjeneProizvoda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OcjeneProizvoda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ocjena")] OcjeneProizvoda ocjeneProizvoda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocjeneProizvoda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ocjeneProizvoda);
        }

        // GET: OcjeneProizvoda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocjeneProizvoda = await _context.OcjeneProizvoda.FindAsync(id);
            if (ocjeneProizvoda == null)
            {
                return NotFound();
            }
            return View(ocjeneProizvoda);
        }

        // POST: OcjeneProizvoda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ocjena")] OcjeneProizvoda ocjeneProizvoda)
        {
            if (id != ocjeneProizvoda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocjeneProizvoda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcjeneProizvodaExists(ocjeneProizvoda.ID))
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
            return View(ocjeneProizvoda);
        }

        // GET: OcjeneProizvoda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocjeneProizvoda = await _context.OcjeneProizvoda
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ocjeneProizvoda == null)
            {
                return NotFound();
            }

            return View(ocjeneProizvoda);
        }

        // POST: OcjeneProizvoda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ocjeneProizvoda = await _context.OcjeneProizvoda.FindAsync(id);
            _context.OcjeneProizvoda.Remove(ocjeneProizvoda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcjeneProizvodaExists(int id)
        {
            return _context.OcjeneProizvoda.Any(e => e.ID == id);
        }
    }
}
