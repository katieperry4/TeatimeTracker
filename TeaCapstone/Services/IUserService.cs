using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TeaCapstone.Services
{
    public interface IUserService
    {
        Task<IdentityUser> GetCurrentUser(ClaimsPrincipal user);
        Task<string> GetUserId(ClaimsPrincipal user);
    }
}
