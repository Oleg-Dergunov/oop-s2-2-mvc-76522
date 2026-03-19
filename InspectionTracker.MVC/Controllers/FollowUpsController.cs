using InspectionTracker.Domain;
using InspectionTracker.MVC.Data;
using InspectionTracker.MVC.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InspectionTracker.MVC.Controllers
{
    [Authorize(Roles = "Admin,Inspector,Viewer")]
    public class FollowUpsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FollowUpsController> _log;

        public FollowUpsController(ApplicationDbContext context, ILogger<FollowUpsController> log)
        {
            _context = context;
            _log = log;
        }

        // GET: FollowUps
        public async Task<IActionResult> Index()
        {
            _log.LogInformation("FollowUps list viewed");

            var followUps = _context.FollowUps
                .Include(f => f.Inspection)
                .ThenInclude(i => i.Premises);   // ← FIX

            return View(await followUps.ToListAsync());
        }

        // GET: FollowUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _log.LogWarning("FollowUp Details requested with null id");
                return NotFound();
            }

            var followUp = await _context.FollowUps
                .Include(f => f.Inspection)
                .ThenInclude(i => i.Premises)   // ← FIX
                .FirstOrDefaultAsync(m => m.Id == id);

            if (followUp == null)
            {
                _log.LogWarning("FollowUp Details not found. Id={Id}", id);
                return NotFound();
            }

            _log.LogInformation("FollowUp Details viewed for Id={Id}", id);
            return View(followUp);
        }

        // GET: FollowUps/Create
        [Authorize(Roles = "Admin,Inspector")]
        public IActionResult Create()
        {
            var inspections = _context.Inspections
                .Include(i => i.Premises)
                .ToList()
                .Select(i => i.ToDisplayDto())
                .ToList();

            ViewData["InspectionId"] = new SelectList(inspections, "Id", "Display");
            return View();
        }

        // POST: FollowUps/Create
        [Authorize(Roles = "Admin,Inspector")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InspectionId,DueDate,ClosedDate")] FollowUp followUp)
        {
            if (!ModelState.IsValid)
            {
                _log.LogWarning("FollowUp Create attempted with invalid model state");

                var inspections = _context.Inspections
                    .Include(i => i.Premises)
                    .ToList()
                    .Select(i => i.ToDisplayDto())
                    .ToList();

                ViewData["InspectionId"] = new SelectList(inspections, "Id", "Display", followUp.InspectionId);
                return View(followUp);
            }

            // Business rule: DueDate cannot be earlier than InspectionDate
            var inspection = await _context.Inspections.FindAsync(followUp.InspectionId);
            if (inspection != null && followUp.DueDate < inspection.InspectionDate)
            {
                _log.LogWarning(
                    "FollowUp due date earlier than inspection date. FollowUpId={FollowUpId}, InspectionId={InspectionId}",
                    followUp.Id,
                    followUp.InspectionId
                );
            }

            try
            {
                _context.Add(followUp);
                await _context.SaveChangesAsync();

                _log.LogInformation("FollowUp created {@FollowUp}", followUp);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error creating FollowUp {@FollowUp}", followUp);
                throw;
            }
        }

        // GET: FollowUps/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _log.LogWarning("FollowUp Edit requested with null id");
                return NotFound();
            }

            var followUp = await _context.FollowUps.FindAsync(id);
            if (followUp == null)
            {
                _log.LogWarning("FollowUp Edit not found. Id={Id}", id);
                return NotFound();
            }

            var inspections = _context.Inspections
                .Include(i => i.Premises)
                .ToList()
                .Select(i => i.ToDisplayDto())
                .ToList();

            ViewData["InspectionId"] = new SelectList(inspections, "Id", "Display", followUp.InspectionId);
            return View(followUp);
        }

        // POST: FollowUps/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InspectionId,DueDate,ClosedDate")] FollowUp followUp)
        {
            if (id != followUp.Id)
            {
                _log.LogWarning("FollowUp Edit id mismatch. RouteId={RouteId}, ModelId={ModelId}", id, followUp.Id);
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                _log.LogWarning("FollowUp Edit attempted with invalid model state");

                var inspections = _context.Inspections
                    .Include(i => i.Premises)
                    .ToList()
                    .Select(i => i.ToDisplayDto())
                    .ToList();

                ViewData["InspectionId"] = new SelectList(inspections, "Id", "Display", followUp.InspectionId);
                return View(followUp);
            }

            try
            {
                _context.Update(followUp);
                await _context.SaveChangesAsync();

                _log.LogInformation("FollowUp updated {@FollowUp}", followUp);

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!FollowUpExists(followUp.Id))
                {
                    _log.LogWarning("FollowUp Edit failed because entity not found. Id={Id}", followUp.Id);
                    return NotFound();
                }
                else
                {
                    _log.LogError(ex, "Concurrency error updating FollowUp Id={Id}", followUp.Id);
                    throw;
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Unexpected error updating FollowUp {@FollowUp}", followUp);
                throw;
            }
        }

        // GET: FollowUps/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                _log.LogWarning("FollowUp Delete requested with null id");
                return NotFound();
            }

            var followUp = await _context.FollowUps
                .Include(f => f.Inspection)
                .ThenInclude(i => i.Premises)   // ← FIX
                .FirstOrDefaultAsync(m => m.Id == id);

            if (followUp == null)
            {
                _log.LogWarning("FollowUp Delete not found. Id={Id}", id);
                return NotFound();
            }

            return View(followUp);
        }

        // POST: FollowUps/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var followUp = await _context.FollowUps.FindAsync(id);

            if (followUp == null)
            {
                _log.LogWarning("FollowUp DeleteConfirmed attempted but entity not found. Id={Id}", id);
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.FollowUps.Remove(followUp);
                await _context.SaveChangesAsync();

                _log.LogWarning("FollowUp deleted Id={Id}", id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error deleting FollowUp Id={Id}", id);
                throw;
            }
        }

        private bool FollowUpExists(int id)
        {
            return _context.FollowUps.Any(e => e.Id == id);
        }
    }
}
