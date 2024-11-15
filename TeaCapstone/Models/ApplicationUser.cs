using Microsoft.AspNetCore.Identity;

namespace TeaCapstone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<TeaLog> TeaLogs { get; set; } = new List<TeaLog>();
    }
}
