using System.ComponentModel.DataAnnotations;

namespace Version2_Mission8_Team0305.Models
{
    public class aTask
    {
        internal int Id;

        [Key]
        public int TaskId { get; set; }  // Primary key

        [Required]
        public string TaskItem { get; set; }

        public DateOnly? DueDate { get; set; }

        [Required]
        public string Quadrant { get; set; }

        [Required]
        public string Category { get; set; }

        public bool Completed { get; set; }
    }
}
