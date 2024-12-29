using System.ComponentModel.DataAnnotations;

namespace BlazorMachinePark.Shared.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public Country Country { get; set; }
        public int CountryId { get; set; }

        // Navigation property for one-to-many relationship 
        public ICollection<Machine> Machines { get; set; } = new List<Machine>();
    }
}
