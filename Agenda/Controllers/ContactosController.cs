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
    public class ContactosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contactos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.contacto.Include(c => c.Riesgo).Include(c => c.categorias);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contactos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.contacto == null)
            {
                return NotFound();
            }

            var contactos = await _context.contacto
                .Include(c => c.Riesgo)
                .Include(c => c.categorias)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactos == null)
            {
                return NotFound();
            }

            return View(contactos);
        }

        // GET: Contactos/Create
        public IActionResult Create()
        {
            ViewData["riesgoId"] = new SelectList(_context.riesgos, "Id", "Name");
            ViewData["categoriaId"] = new SelectList(_context.categoria, "Id", "Nombre");
            return View();
        }

        // POST: Contactos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,Telefono,FechaCreacion,categoriaId,riesgoId")] Contactos contactos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["riesgoId"] = new SelectList(_context.riesgos, "Id", "Name", contactos.riesgoId);
            ViewData["categoriaId"] = new SelectList(_context.categoria, "Id", "Nombre", contactos.categoriaId);
            return View(contactos);
        }

        // GET: Contactos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.contacto == null)
            {
                return NotFound();
            }

            var contactos = await _context.contacto.FindAsync(id);
            if (contactos == null)
            {
                return NotFound();
            }
            ViewData["riesgoId"] = new SelectList(_context.riesgos, "Id", "Name", contactos.riesgoId);
            ViewData["categoriaId"] = new SelectList(_context.categoria, "Id", "Nombre", contactos.categoriaId);
            return View(contactos);
        }

        // POST: Contactos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,Telefono,FechaCreacion,categoriaId,riesgoId")] Contactos contactos)
        {
            if (id != contactos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactosExists(contactos.Id))
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
            ViewData["riesgoId"] = new SelectList(_context.riesgos, "Id", "Name", contactos.riesgoId);
            ViewData["categoriaId"] = new SelectList(_context.categoria, "Id", "Nombre", contactos.categoriaId);
            return View(contactos);
        }

        // GET: Contactos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.contacto == null)
            {
                return NotFound();
            }

            var contactos = await _context.contacto
                .Include(c => c.Riesgo)
                .Include(c => c.categorias)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactos == null)
            {
                return NotFound();
            }

            return View(contactos);
        }

        // POST: Contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.contacto == null)
            {
                return Problem("Entity set 'ApplicationDbContext.contacto'  is null.");
            }
            var contactos = await _context.contacto.FindAsync(id);
            if (contactos != null)
            {
                _context.contacto.Remove(contactos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactosExists(int id)
        {
          return _context.contacto.Any(e => e.Id == id);
        }
    }
}
