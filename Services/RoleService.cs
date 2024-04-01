using Assignment2.Data;
using Microsoft.AspNetCore.Identity;

namespace Assignment2.Services
{
    public class RoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AssignRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}