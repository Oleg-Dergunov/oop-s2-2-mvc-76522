using Microsoft.AspNetCore.Identity;

namespace InspectionTracker.MVC.Data
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            // --- Seed Roles ---
            string[] roles = { "Admin", "Inspector", "Viewer" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // --- Seed Users ---
            await CreateUserAsync(userManager, "admin@test.com", "Admin123!", "Admin");
            await CreateUserAsync(userManager, "inspector@test.com", "Inspector123!", "Inspector");
            await CreateUserAsync(userManager, "viewer@test.com", "Viewer123!", "Viewer");
        }

        private static async Task CreateUserAsync(
            UserManager<IdentityUser> userManager,
            string email,
            string password,
            string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
