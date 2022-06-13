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
    public class RedCekanjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RedCekanjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RedCekanja
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RedCekanja.Include(r => r.Korisnik).Include(r => r.Narudzba);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RedCekanja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redCekanja = await _context.RedCekanja
                .Include(r => r.Korisnik)
                .Include(r => r.Narudzba)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (redCekanja == null)
            {
                return NotFound();
            }

            return View(redCekanja);
        }

        // GET: RedCekanja/Create
        public IActionResult Create()
        {
            ViewData["IDKorisnik"] = new SelectList(_context.Korisnik, "ID", "ID");
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID");
            return View();
        }

        // POST: RedCekanja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDNarudzbe,IDKorisnik")] RedCekanja redCekanja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(redCekanja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDKorisnik"] = new SelectList(_context.Korisnik, "ID", "ID", redCekanja.IDKorisnik);
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", redCekanja.IDNarudzbe);
            return View(redCekanja);
        }

        // GET: RedCekanja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redCekanja = await _context.RedCekanja.FindAsync(id);
            if (redCekanja == null)
            {
                return NotFound();
            }
            ViewData["IDKorisnik"] = new SelectList(_context.Korisnik, "ID", "ID", redCekanja.IDKorisnik);
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", redCekanja.IDNarudzbe);
            return View(redCekanja);
        }

        // POST: RedCekanja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDNarudzbe,IDKorisnik")] RedCekanja redCekanja)
        {
            if (id != redCekanja.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(redCekanja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RedCekanjaExists(redCekanja.ID))
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
            ViewData["IDKorisnik"] = new SelectList(_context.Korisnik, "ID", "ID", redCekanja.IDKorisnik);
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", redCekanja.IDNarudzbe);
            return View(redCekanja);
        }

        // GET: RedCekanja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redCekanja = await _context.RedCekanja
                .Include(r => r.Korisnik)
                .Include(r => r.Narudzba)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (redCekanja == null)
            {
                return NotFound();
            }

            return View(redCekanja);
        }

        // POST: RedCekanja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var redCekanja = await _context.RedCekanja.FindAsync(id);
            _context.RedCekanja.Remove(redCekanja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RedCekanjaExists(int id)
        {
            return _context.RedCekanja.Any(e => e.ID == id);
        }
    }
}
