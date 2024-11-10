using System.ComponentModel.DataAnnotations;

namespace TeaCapstone.Models
{
    public class AddTeaLogViewModel
    {
        [Required]
        public int TypeId { get; set; }
        [Required]
        public int VarietyId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
