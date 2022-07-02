using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenda.Data;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class RiesgoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RiesgoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Riesgoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.riesgos.ToListAsync());
        }

        // GET: Riesgoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.riesgos == null)
            {
                return NotFound();
            }

            var riesgo = await _context.riesgos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (riesgo == null)
            {
                return NotFound();
            }

            return View(riesgo);
        }

        // GET: Riesgoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Riesgoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Riesgo riesgo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(riesgo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(riesgo);
        }

        // GET: Riesgoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.riesgos == null)
            {
                return NotFound();
            }

            var riesgo = await _context.riesgos.FindAsync(id);
            if (riesgo == null)
            {
                return NotFound();
            }
            return View(riesgo);
        }

        // POST: Riesgoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Riesgo riesgo)
        {
            if (id != riesgo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(riesgo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiesgoExists(riesgo.Id))
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
            return View(riesgo);
        }

        // GET: Riesgoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.riesgos == null)
            {
                return NotFound();
            }

            var riesgo = await _context.riesgos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (riesgo == null)
            {
                return NotFound();
            }

            return View(riesgo);
        }

        // POST: Riesgoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.riesgos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.riesgos'  is null.");
            }
            var riesgo = await _context.riesgos.FindAsync(id);
            if (riesgo != null)
            {
                _context.riesgos.Remove(riesgo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RiesgoExists(int id)
        {
          return _context.riesgos.Any(e => e.Id == id);
        }
    }
}
