using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TeaCapstone.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager) {
            _userManager = userManager;
        }

        public async Task<IdentityUser> GetCurrentUser(ClaimsPrincipal user)
        {
             return await _userManager.GetUserAsync(user);
        }

        public async Task<string> GetUserId(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);
            return currentUser?.Id;
        }
    }
}
