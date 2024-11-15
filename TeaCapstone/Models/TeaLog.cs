using Microsoft.AspNetCore.Identity;

namespace TeaCapstone.Models
{
    public class TeaLog
    {
        public int Id { get; set; } 
        public DateTime Time { get; set; }
        
        //foreign key for tea variety
        public int TeaVarietyId { get; set; }
        public TeaVariety TeaVariety { get; set; } = null!;

        //foreign key for user
        public required string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; } = null!;
    }
}
