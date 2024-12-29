using System.ComponentModel.DataAnnotations;

namespace BlazorMachinePark.Shared.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        public string EmojiFlag { get; set; } = string.Empty;
    }
}
