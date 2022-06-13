﻿using System;
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
    public class PlacanjeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlacanjeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Placanje
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Placanje.Include(p => p.Korisnik).Include(p => p.Narudzba);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Placanje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placanje = await _context.Placanje
                .Include(p => p.Korisnik)
                .Include(p => p.Narudzba)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (placanje == null)
            {
                return NotFound();
            }

            return View(placanje);
        }

        // GET: Placanje/Create
        public IActionResult Create()
        {
            ViewData["IDKorisnika"] = new SelectList(_context.Korisnik, "ID", "ID");
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID");
            return View();
        }

        // POST: Placanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VrstaPlacanja,IDKorisnika,Popust,IDNarudzbe,EvidencijaUplate")] Placanje placanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDKorisnika"] = new SelectList(_context.Korisnik, "ID", "ID", placanje.IDKorisnika);
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", placanje.IDNarudzbe);
            return View(placanje);
        }

        // GET: Placanje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placanje = await _context.Placanje.FindAsync(id);
            if (placanje == null)
            {
                return NotFound();
            }
            ViewData["IDKorisnika"] = new SelectList(_context.Korisnik, "ID", "ID", placanje.IDKorisnika);
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", placanje.IDNarudzbe);
            return View(placanje);
        }

        // POST: Placanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VrstaPlacanja,IDKorisnika,Popust,IDNarudzbe,EvidencijaUplate")] Placanje placanje)
        {
            if (id != placanje.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacanjeExists(placanje.ID))
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
            ViewData["IDKorisnika"] = new SelectList(_context.Korisnik, "ID", "ID", placanje.IDKorisnika);
            ViewData["IDNarudzbe"] = new SelectList(_context.Narudzba, "ID", "ID", placanje.IDNarudzbe);
            return View(placanje);
        }

        // GET: Placanje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placanje = await _context.Placanje
                .Include(p => p.Korisnik)
                .Include(p => p.Narudzba)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (placanje == null)
            {
                return NotFound();
            }

            return View(placanje);
        }

        // POST: Placanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placanje = await _context.Placanje.FindAsync(id);
            _context.Placanje.Remove(placanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacanjeExists(int id)
        {
            return _context.Placanje.Any(e => e.ID == id);
        }
    }
}
