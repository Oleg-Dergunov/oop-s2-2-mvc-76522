using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using InspectionTracker.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace InspectionTracker.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UsersController> _log;

        public UsersController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<UsersController> log)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _log = log;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            _log.LogInformation("Users list viewed");

            var users = _userManager.Users.ToList();
            var model = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                model.Add(new UserRoleViewModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    CurrentRole = roles.FirstOrDefault(),
                    AllRoles = _roleManager.Roles.Select(r => r.Name).ToList()
                });
            }

            return View(model);
        }

        // POST: Users/UpdateRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRole(string userId, string role)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                _log.LogWarning("UpdateRole attempted with null userId");
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                _log.LogWarning("UpdateRole user not found. UserId={UserId}", userId);
                return NotFound();
            }

            // Protection: Admin cannot change their own role at all
            if (User.Identity?.Name == user.Email)
            {
                _log.LogWarning("Admin attempted to change their own role");
                TempData["Error"] = "You cannot change your own role.";
                return RedirectToAction(nameof(Index));
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            try
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);

                if (!string.IsNullOrWhiteSpace(role))
                {
                    await _userManager.AddToRoleAsync(user, role);
                    _log.LogInformation("Role updated for UserId={UserId}. NewRole={Role}", userId, role);
                }
                else
                {
                    _log.LogInformation("Role removed for UserId={UserId}", userId);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error updating role for UserId={UserId}", userId);
                throw;
            }
        }
    }
}

