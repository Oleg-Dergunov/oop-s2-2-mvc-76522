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
                .ThenInclude(i => i.Premises);

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
                .ThenInclude(i => i.Premises)
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
                .Select(i => new
                {
                    i.Id,
                    Display = i.ToDisplayDto().Display,
                    InspectionDate = i.InspectionDate.ToString("yyyy-MM-dd")
                })
                .ToList();

            ViewData["Inspections"] = inspections;
            ViewData["InspectionId"] = new SelectList(inspections, "Id", "Display");

            return View();
        }


        // POST: FollowUps/Create
        [Authorize(Roles = "Admin,Inspector")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InspectionId,DueDate")] FollowUp followUp)
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
                ModelState.AddModelError("DueDate", "Due date cannot be earlier than inspection date.");

                var inspections = _context.Inspections
                    .Include(i => i.Premises)
                    .ToList()
                    .Select(i => i.ToDisplayDto())
                    .ToList();

                ViewData["InspectionId"] = new SelectList(inspections, "Id", "Display", followUp.InspectionId);
                return View(followUp);
            }

            followUp.ClosedDate = null;

            _context.Add(followUp);
            await _context.SaveChangesAsync();

            _log.LogInformation("FollowUp created {@FollowUp}", followUp);

            return RedirectToAction(nameof(Index));
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

            var inspection = await _context.Inspections.FindAsync(followUp.InspectionId);

            // DueDate cannot be earlier than InspectionDate
            if (inspection != null && followUp.DueDate < inspection.InspectionDate)
                throw new ArgumentException("Due date cannot be earlier than the inspection date.");

            // ClosedDate cannot be earlier than InspectionDate
            if (inspection != null && followUp.ClosedDate < inspection.InspectionDate)
                throw new ArgumentException("Closed date cannot be earlier than the inspection date.");

            // ClosedDate cannot be in the future
            var today = DateOnly.FromDateTime(DateTime.Today);
            if (followUp.ClosedDate > today)
                throw new ArgumentException("Closed date cannot be in the future.");

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
                .ThenInclude(i => i.Premises)
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

            _context.FollowUps.Remove(followUp);
            await _context.SaveChangesAsync();

            _log.LogWarning("FollowUp deleted Id={Id}", id);

            return RedirectToAction(nameof(Index));
        }

        // GET: FollowUps/Close/5
        [Authorize(Roles = "Inspector")]
        public async Task<IActionResult> Close(int id)
        {
            var followUp = await _context.FollowUps
                .Include(f => f.Inspection)
                .ThenInclude(i => i.Premises)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (followUp == null)
                return NotFound();

            if (followUp.ClosedDate != null)
                return RedirectToAction(nameof(Index));

            return View(followUp);
        }

        // POST: FollowUps/Close/5
        [Authorize(Roles = "Inspector")]
        [HttpPost, ActionName("Close")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CloseConfirmed(int id, DateOnly closedDate)
        {
            var followUp = await _context.FollowUps.FindAsync(id);
            if (followUp == null)
                return NotFound();

            if (followUp.ClosedDate != null)
                return RedirectToAction(nameof(Index));

            // ClosedDate cannot be earlier than InspectionDate
            var inspection = await _context.Inspections.FindAsync(followUp.InspectionId);
            if (inspection != null && closedDate < inspection.InspectionDate)
                throw new ArgumentException("Closed date cannot be earlier than the inspection date.");

            // ClosedDate cannot be in the future
            var today = DateOnly.FromDateTime(DateTime.Today);
            if (closedDate > today)
                throw new ArgumentException("Closed date cannot be in the future.");

            followUp.ClosedDate = closedDate;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private bool FollowUpExists(int id)
        {
            return _context.FollowUps.Any(e => e.Id == id);
        }
    }
}
