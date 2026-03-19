using InspectionTracker.Domain;
using InspectionTracker.MVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InspectionTracker.MVC.Controllers
{
    [Authorize(Roles = "Admin,Inspector,Viewer")]
    public class InspectionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<InspectionsController> _log;

        public InspectionsController(ApplicationDbContext context, ILogger<InspectionsController> log)
        {
            _context = context;
            _log = log;
        }

        // GET: Inspections
        public async Task<IActionResult> Index()
        {
            _log.LogInformation("Inspections list viewed");
            var applicationDbContext = _context.Inspections.Include(i => i.Premises);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Inspections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _log.LogWarning("Inspection Details requested with null id");
                return NotFound();
            }

            var inspection = await _context.Inspections
                .Include(i => i.Premises)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (inspection == null)
            {
                _log.LogWarning("Inspection Details not found. Id={Id}", id);
                return NotFound();
            }

            _log.LogInformation("Inspection Details viewed for Id={Id}", id);
            return View(inspection);
        }

        // GET: Inspections/Create
        [Authorize(Roles = "Admin,Inspector")]
        public IActionResult Create()
        {
            ViewData["PremisesId"] = new SelectList(_context.Premises, "Id", "Name");
            return View();
        }

        // POST: Inspections/Create
        [Authorize(Roles = "Admin,Inspector")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PremisesId,InspectionDate,Score,Outcome,Notes")] Inspection inspection)
        {
            if (!ModelState.IsValid)
            {
                foreach (var kvp in ModelState)
                {
                    foreach (var error in kvp.Value.Errors)
                    {
                        _log.LogWarning("ModelState error in field {Field}: {Error}",
                            kvp.Key, error.ErrorMessage);
                    }
                }

                _log.LogWarning("Inspection Create attempted with invalid model state");
                ViewData["PremisesId"] = new SelectList(_context.Premises, "Id", "Name", inspection.PremisesId);
                return View(inspection);
            }

            try
            {
                _context.Add(inspection);
                await _context.SaveChangesAsync();

                _log.LogInformation("Inspection created {@Inspection}", inspection);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error creating inspection {@Inspection}", inspection);
                throw;
            }
        }

        // GET: Inspections/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _log.LogWarning("Inspection Edit requested with null id");
                return NotFound();
            }

            var inspection = await _context.Inspections.FindAsync(id);
            if (inspection == null)
            {
                _log.LogWarning("Inspection Edit not found. Id={Id}", id);
                return NotFound();
            }

            ViewData["PremisesId"] = new SelectList(_context.Premises, "Id", "Name", inspection.PremisesId);
            return View(inspection);
        }

        // POST: Inspections/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PremisesId,InspectionDate,Score,Outcome,Notes")] Inspection inspection)
        {
            if (id != inspection.Id)
            {
                _log.LogWarning("Inspection Edit id mismatch. RouteId={RouteId}, ModelId={ModelId}", id, inspection.Id);
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                _log.LogWarning("Inspection Edit attempted with invalid model state");
                ViewData["PremisesId"] = new SelectList(_context.Premises, "Id", "Name", inspection.PremisesId);
                return View(inspection);
            }

            try
            {
                _context.Update(inspection);
                await _context.SaveChangesAsync();

                _log.LogInformation("Inspection updated {@Inspection}", inspection);

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!InspectionExists(inspection.Id))
                {
                    _log.LogWarning("Inspection Edit failed because entity not found. Id={Id}", inspection.Id);
                    return NotFound();
                }
                else
                {
                    _log.LogError(ex, "Concurrency error updating inspection Id={Id}", inspection.Id);
                    throw;
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Unexpected error updating inspection {@Inspection}", inspection);
                throw;
            }
        }

        // GET: Inspections/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                _log.LogWarning("Inspection Delete requested with null id");
                return NotFound();
            }

            var inspection = await _context.Inspections
                .Include(i => i.Premises)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (inspection == null)
            {
                _log.LogWarning("Inspection Delete not found. Id={Id}", id);
                return NotFound();
            }

            return View(inspection);
        }

        // POST: Inspections/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inspection = await _context.Inspections.FindAsync(id);

            if (inspection == null)
            {
                _log.LogWarning("Inspection DeleteConfirmed attempted but entity not found. Id={Id}", id);
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Inspections.Remove(inspection);
                await _context.SaveChangesAsync();

                _log.LogWarning("Inspection deleted Id={Id}", id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error deleting inspection Id={Id}", id);
                throw;
            }
        }

        private bool InspectionExists(int id)
        {
            return _context.Inspections.Any(e => e.Id == id);
        }
    }
}
