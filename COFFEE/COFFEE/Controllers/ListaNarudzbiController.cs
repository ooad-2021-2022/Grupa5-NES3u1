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
    public class ListaNarudzbiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaNarudzbiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ListaNarudzbi
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListaNarudzbi.Include(l => l.Izvjestaj).Include(l => l.Narudzba);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListaNarudzbi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaNarudzbi = await _context.ListaNarudzbi
                .Include(l => l.Izvjestaj)
                .Include(l => l.Narudzba)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (listaNarudzbi == null)
            {
                return NotFound();
            }

            return View(listaNarudzbi);
        }

        // GET: ListaNarudzbi/Create
        public IActionResult Create()
        {
            ViewData["IDIzvjestaja"] = new SelectList(_context.Izvjestaj, "ID", "ID");
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID");
            return View();
        }

        // POST: ListaNarudzbi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDIzvjestaja,IDNarudzbe")] ListaNarudzbi listaNarudzbi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaNarudzbi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDIzvjestaja"] = new SelectList(_context.Izvjestaj, "ID", "ID", listaNarudzbi.IDIzvjestaja);
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", listaNarudzbi.IDNarudzbe);
            return View(listaNarudzbi);
        }

        // GET: ListaNarudzbi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaNarudzbi = await _context.ListaNarudzbi.FindAsync(id);
            if (listaNarudzbi == null)
            {
                return NotFound();
            }
            ViewData["IDIzvjestaja"] = new SelectList(_context.Izvjestaj, "ID", "ID", listaNarudzbi.IDIzvjestaja);
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", listaNarudzbi.IDNarudzbe);
            return View(listaNarudzbi);
        }

        // POST: ListaNarudzbi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDIzvjestaja,IDNarudzbe")] ListaNarudzbi listaNarudzbi)
        {
            if (id != listaNarudzbi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaNarudzbi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaNarudzbiExists(listaNarudzbi.ID))
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
            ViewData["IDIzvjestaja"] = new SelectList(_context.Izvjestaj, "ID", "ID", listaNarudzbi.IDIzvjestaja);
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", listaNarudzbi.IDNarudzbe);
            return View(listaNarudzbi);
        }

        // GET: ListaNarudzbi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaNarudzbi = await _context.ListaNarudzbi
                .Include(l => l.Izvjestaj)
                .Include(l => l.Narudzba)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (listaNarudzbi == null)
            {
                return NotFound();
            }

            return View(listaNarudzbi);
        }

        // POST: ListaNarudzbi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaNarudzbi = await _context.ListaNarudzbi.FindAsync(id);
            _context.ListaNarudzbi.Remove(listaNarudzbi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaNarudzbiExists(int id)
        {
            return _context.ListaNarudzbi.Any(e => e.ID == id);
        }
    }
}
