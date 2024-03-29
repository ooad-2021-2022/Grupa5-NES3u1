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
    public class PopustController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PopustController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Popust
        public async Task<IActionResult> Index()
        {
            return View(await _context.Popust.ToListAsync());
        }

        // GET: Popust/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popust = await _context.Popust
                .FirstOrDefaultAsync(m => m.ID == id);
            if (popust == null)
            {
                return NotFound();
            }

            return View(popust);
        }

        // GET: Popust/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Popust/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VrstaProizvoda,Postotak")] Popust popust)
        {
            if (ModelState.IsValid)
            {
                _context.Add(popust);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(popust);
        }

        // GET: Popust/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popust = await _context.Popust.FindAsync(id);
            if (popust == null)
            {
                return NotFound();
            }
            return View(popust);
        }

        // POST: Popust/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VrstaProizvoda,Postotak")] Popust popust)
        {
            if (id != popust.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(popust);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PopustExists(popust.ID))
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
            return View(popust);
        }

        // GET: Popust/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popust = await _context.Popust
                .FirstOrDefaultAsync(m => m.ID == id);
            if (popust == null)
            {
                return NotFound();
            }

            return View(popust);
        }

        // POST: Popust/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var popust = await _context.Popust.FindAsync(id);
            _context.Popust.Remove(popust);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PopustExists(int id)
        {
            return _context.Popust.Any(e => e.ID == id);
        }
    }
}
