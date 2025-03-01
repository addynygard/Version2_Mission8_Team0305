using System.ComponentModel.DataAnnotations;

namespace Version2_Mission8_Team0305.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } // Primary Key

        [Required]
        public string Name { get; set; } // Name to display in dropdowns
    }
}