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
    public class ListaProizvodaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaProizvodaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ListaProizvoda
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListaProizvoda.Include(l => l.Narudzba).Include(l => l.Proizvod);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListaProizvoda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaProizvoda = await _context.ListaProizvoda
                .Include(l => l.Narudzba)
                .Include(l => l.Proizvod)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (listaProizvoda == null)
            {
                return NotFound();
            }

            return View(listaProizvoda);
        }

        // GET: ListaProizvoda/Create
        public IActionResult Create()
        {
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID");
            ViewData["IDProizvoda"] = new SelectList(_context.Proizvod, "ID", "ID");
            return View();
        }

        // POST: ListaProizvoda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDProizvoda,IDNarudzbe")] ListaProizvoda listaProizvoda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaProizvoda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", listaProizvoda.IDNarudzbe);
            ViewData["IDProizvoda"] = new SelectList(_context.Proizvod, "ID", "ID", listaProizvoda.IDProizvoda);
            return View(listaProizvoda);
        }

        // GET: ListaProizvoda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaProizvoda = await _context.ListaProizvoda.FindAsync(id);
            if (listaProizvoda == null)
            {
                return NotFound();
            }
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", listaProizvoda.IDNarudzbe);
            ViewData["IDProizvoda"] = new SelectList(_context.Proizvod, "ID", "ID", listaProizvoda.IDProizvoda);
            return View(listaProizvoda);
        }

        // POST: ListaProizvoda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDProizvoda,IDNarudzbe")] ListaProizvoda listaProizvoda)
        {
            if (id != listaProizvoda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaProizvoda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaProizvodaExists(listaProizvoda.ID))
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
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", listaProizvoda.IDNarudzbe);
            ViewData["IDProizvoda"] = new SelectList(_context.Proizvod, "ID", "ID", listaProizvoda.IDProizvoda);
            return View(listaProizvoda);
        }

        // GET: ListaProizvoda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaProizvoda = await _context.ListaProizvoda
                .Include(l => l.Narudzba)
                .Include(l => l.Proizvod)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (listaProizvoda == null)
            {
                return NotFound();
            }

            return View(listaProizvoda);
        }

        // POST: ListaProizvoda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaProizvoda = await _context.ListaProizvoda.FindAsync(id);
            _context.ListaProizvoda.Remove(listaProizvoda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaProizvodaExists(int id)
        {
            return _context.ListaProizvoda.Any(e => e.ID == id);
        }
    }
}
