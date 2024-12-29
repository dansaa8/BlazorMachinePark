using System.ComponentModel.DataAnnotations;

namespace BlazorMachinePark.Shared.Entities
{
    public class MachineType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        // Navigation property for one-to-many relationship 
        public ICollection<Machine> Machines { get; set; }

    }
}
