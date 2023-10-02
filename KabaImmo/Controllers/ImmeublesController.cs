using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KabaImmo.Data;
using Microsoft.AspNetCore.Authorization;

namespace KabaImmo.Controllers
{
    [Authorize]
    public class ImmeublesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImmeublesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Immeubles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Immeuble.ToListAsync());
        }

        // GET: Immeubles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Immeuble == null)
            {
                return NotFound();
            }

            var immeuble = await _context.Immeuble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (immeuble == null)
            {
                return NotFound();
            }

            return View(immeuble);
        }

        // GET: Immeubles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Immeubles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Superficie,Note")] Immeuble immeuble)
        {
            if (ModelState.IsValid)
            {
                immeuble.Id = Guid.NewGuid();
                _context.Add(immeuble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(immeuble);
        }

        // GET: Immeubles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Immeuble == null)
            {
                return NotFound();
            }

            var immeuble = await _context.Immeuble.FindAsync(id);
            if (immeuble == null)
            {
                return NotFound();
            }
            return View(immeuble);
        }

        // POST: Immeubles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Superficie,Note")] Immeuble immeuble)
        {
            if (id != immeuble.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(immeuble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImmeubleExists(immeuble.Id))
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
            return View(immeuble);
        }

        // GET: Immeubles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Immeuble == null)
            {
                return NotFound();
            }

            var immeuble = await _context.Immeuble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (immeuble == null)
            {
                return NotFound();
            }

            return View(immeuble);
        }

        // POST: Immeubles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Immeuble == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Immeuble'  is null.");
            }
            var immeuble = await _context.Immeuble.FindAsync(id);
            if (immeuble != null)
            {
                _context.Immeuble.Remove(immeuble);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImmeubleExists(Guid id)
        {
            return _context.Immeuble.Any(e => e.Id == id);
        }
    }
}
