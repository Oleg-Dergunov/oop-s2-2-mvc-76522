using InspectionTracker.MVC.Data;
using InspectionTracker.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspectionTracker.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? town, string? riskRating)
        {
            var today = DateTime.Today;
            var firstDay = new DateTime(today.Year, today.Month, 1);

            // Base inspections query with filters
            var inspections = _context.Inspections
                .Include(i => i.Premises)
                .AsQueryable();

            if (!string.IsNullOrEmpty(town))
                inspections = inspections.Where(i => i.Premises.Town == town);

            if (!string.IsNullOrEmpty(riskRating))
                inspections = inspections.Where(i => i.Premises.RiskRating == riskRating);

            // Dashboard model
            var model = new DashboardViewModel
            {
                Town = town,
                RiskRating = riskRating,

                Towns = _context.Premises
                    .Select(p => p.Town)
                    .Distinct()
                    .OrderBy(t => t)
                    .ToList(),

                RiskRatings = _context.Premises
                    .Select(p => p.RiskRating)
                    .Distinct()
                    .OrderBy(r => r)
                    .ToList(),

                TotalInspectionsThisMonth = inspections
                    .Count(i => i.InspectionDate >= firstDay && i.InspectionDate <= today),

                FailedInspectionsThisMonth = inspections
                    .Count(i => i.InspectionDate >= firstDay &&
                                i.InspectionDate <= today &&
                                i.Outcome == "Fail"),

                OverdueOpenFollowUps = _context.FollowUps
                    .Include(f => f.Inspection)
                    .ThenInclude(i => i.Premises)
                    .Where(f => f.ClosedDate == null)          // OPEN
                    .Where(f => f.DueDate < today)             // OVERDUE
                    .Where(f => string.IsNullOrEmpty(town) ||
                                f.Inspection.Premises.Town == town)
                    .Where(f => string.IsNullOrEmpty(riskRating) ||
                                f.Inspection.Premises.RiskRating == riskRating)
                    .Count()
            };

            return View(model);
        }
    }
}
