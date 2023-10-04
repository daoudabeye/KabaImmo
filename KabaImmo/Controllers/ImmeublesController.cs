using KabaImmo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KabaImmo.Controllers
{
    [Authorize]
    [Route("Bien/Immeubles")]
    public class ImmeublesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImmeublesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Immeubles
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Bien/Immeuble/Index.cshtml",await _context.Immeuble.ToListAsync());
        }

        // GET: Immeubles/Details/5
        [Route("Details")]
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

            return View("~/Views/Bien/Immeuble/Details.cshtml", immeuble);
        }

        // GET: Immeubles/Create
        [Route("Create")]
        public IActionResult Create()
        {
            return View("~/Views/Bien/Immeuble/Create.cshtml");
        }

        // POST: Immeubles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
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
            return View("~/Views/Bien/Immeuble/Create.cshtml", immeuble);
        }

        // GET: Immeubles/Edit/5
        [Route("Edit")]
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
            return View("~/Views/Bien/Immeuble/Edit.cshtml", immeuble);
        }

        // POST: Immeubles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
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
            return View("~/Views/Bien/Immeuble/Edit.cshtml", immeuble);
        }

        // GET: Immeubles/Delete/5
        [Route("Delete")]
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

            return View("~/Views/Bien/Immeuble/Delete.cshtml", immeuble);
        }

        // POST: Immeubles/Delete/5
        [Route("Delete")]
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
