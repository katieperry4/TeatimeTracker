using Microsoft.EntityFrameworkCore;

namespace TeaCapstone.Models
{
    public class TeaVariety
    {
        
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CaffeineContent { get; set; }

        public int TeaTypeId { get; set; }
        public TeaType TeaType { get; set; } = null!;
    }
}
