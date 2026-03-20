using InspectionTracker.Domain;
using InspectionTracker.MVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspectionTracker.MVC.Controllers
{
    [Authorize(Roles = "Admin,Inspector,Viewer")]
    public class PremisesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PremisesController> _log;

        public PremisesController(ApplicationDbContext context, ILogger<PremisesController> log)
        {
            _context = context;
            _log = log;
        }
       
        // GET: Premises
        public async Task<IActionResult> Index()
        {
            _log.LogInformation("Premises list viewed");
            return View(await _context.Premises.ToListAsync());
        }

        // GET: Premises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _log.LogWarning("Premises Details requested with null id");
                return NotFound();
            }

            var premises = await _context.Premises.FirstOrDefaultAsync(m => m.Id == id);

            if (premises == null)
            {
                _log.LogWarning("Premises Details not found. Id={Id}", id);
                return NotFound();
            }

            _log.LogInformation("Premises Details viewed for Id={Id}", id);
            return View(premises);
        }

        // GET: Premises/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Premises/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Town,RiskRating")] Premises premises)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(premises);
                    await _context.SaveChangesAsync();

                    _log.LogInformation("Premises created {@Premises}", premises);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, "Error creating premises {@Premises}", premises);
                    throw;
                }
            }

            _log.LogWarning("Premises Create attempted with invalid model state");
            return View(premises);
        }

        // GET: Premises/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _log.LogWarning("Premises Edit requested with null id");
                return NotFound();
            }

            var premises = await _context.Premises.FindAsync(id);
            if (premises == null)
            {
                _log.LogWarning("Premises Edit not found. Id={Id}", id);
                return NotFound();
            }

            return View(premises);
        }

        // POST: Premises/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Town,RiskRating")] Premises premises)
        {
            if (id != premises.Id)
            {
                _log.LogWarning("Premises Edit id mismatch. RouteId={RouteId}, ModelId={ModelId}", id, premises.Id);
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(premises);
                    await _context.SaveChangesAsync();

                    _log.LogInformation("Premises updated {@Premises}", premises);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!PremisesExists(premises.Id))
                    {
                        _log.LogWarning("Premises Edit failed because entity not found. Id={Id}", premises.Id);
                        return NotFound();
                    }
                    else
                    {
                        _log.LogError(ex, "Concurrency error updating premises Id={Id}", premises.Id);
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, "Unexpected error updating premises {@Premises}", premises);
                    throw;
                }
            }

            _log.LogWarning("Premises Edit attempted with invalid model state");
            return View(premises);
        }

        // GET: Premises/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                _log.LogWarning("Premises Delete requested with null id");
                return NotFound();
            }

            var premises = await _context.Premises.FirstOrDefaultAsync(m => m.Id == id);
            if (premises == null)
            {
                _log.LogWarning("Premises Delete not found. Id={Id}", id);
                return NotFound();
            }

            return View(premises);
        }

        // POST: Premises/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var premises = await _context.Premises.FindAsync(id);

            if (premises == null)
            {
                _log.LogWarning("Premises DeleteConfirmed attempted but entity not found. Id={Id}", id);
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Premises.Remove(premises);
                await _context.SaveChangesAsync();

                _log.LogWarning("Premises deleted Id={Id}", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error deleting premises Id={Id}", id);
                throw;
            }
        }

        private bool PremisesExists(int id)
        {
            return _context.Premises.Any(e => e.Id == id);
        }
    }
}