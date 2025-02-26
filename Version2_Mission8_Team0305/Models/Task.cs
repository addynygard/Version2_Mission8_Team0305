using System.ComponentModel.DataAnnotations;

namespace Mission08_Team03_05.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

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