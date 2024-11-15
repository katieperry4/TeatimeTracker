namespace TeaCapstone.Models
{
    public class TeaType
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<TeaVariety> TeaVarieties { get; set; } = new List<TeaVariety>();
    }
}
