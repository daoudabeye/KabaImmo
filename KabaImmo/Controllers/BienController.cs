using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KabaImmo.Data;
using Microsoft.AspNetCore.Authorization;

namespace KabaImmo.Controllers
{
    [Authorize]
    [Route("Bien/Lots")]
    public partial class BienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bien
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lot.Include(a => a.Immeuble);
            return View("Lots/Index",await applicationDbContext.ToListAsync());
        }

        // GET: Bien/Details/5
        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Lot == null)
            {
                return NotFound();
            }

            var lot = await _context.Lot
                .Include(a => a.Immeuble)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lot == null)
            {
                return NotFound();
            }

            return View("Lots/Details", lot);
        }

        // GET: Bien/Create
        [Route("Create")]
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Immeuble, "Id", "Id");
            ViewData["TypeLot"] = new SelectList(Enum.GetValues(typeof(TypeLot)));
            return View("Lots/Create");
        }

        // POST: Bien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Description,Type,Couleur,TypeLocation,LoyerHorsCharges,Charges,Superficie,Pieces,SaleDeBain,DateContruction,note,Meubler,Fumeur,Animaux,Parking,Dependances")] Lot lot)
        {
            if (ModelState.IsValid)
            {
                lot.Id = Guid.NewGuid();
                _context.Add(lot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Immeuble, "Id", "Id", lot.Id);
            return View("Lots/Create", lot);
        }

        // GET: Bien/Edit/5
        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Lot == null)
            {
                return NotFound();
            }

            var lot = await _context.Lot.FindAsync(id);
            if (lot == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Immeuble, "Id", "Id", lot.Id);
            return View("Lots/Edit", lot);
        }

        // POST: Bien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nom,Description,Type,Couleur,TypeLocation,LoyerHorsCharges,Charges,Superficie,Pieces,SaleDeBain,DateContruction,note,Meubler,Fumeur,Animaux,Parking,Dependances")] Lot lot)
        {
            if (id != lot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LotExists(lot.Id))
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
            ViewData["Id"] = new SelectList(_context.Immeuble, "Id", "Id", lot.Id);
            return View("Lots/Edit", lot);
        }

        // GET: Bien/Delete/5
        [Route("Edit")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Lot == null)
            {
                return NotFound();
            }

            var lot = await _context.Lot
                .Include(a => a.Immeuble)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lot == null)
            {
                return NotFound();
            }

            return View("Lots/Delete", lot);
        }

        // POST: Bien/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Lot == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lot'  is null.");
            }
            var lot = await _context.Lot.FindAsync(id);
            if (lot != null)
            {
                _context.Lot.Remove(lot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LotExists(Guid id)
        {
          return _context.Lot.Any(e => e.Id == id);
        }

    }
}
