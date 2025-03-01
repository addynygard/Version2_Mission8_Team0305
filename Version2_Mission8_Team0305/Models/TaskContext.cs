using Microsoft.EntityFrameworkCore;

namespace Version2_Mission8_Team0305.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; } // ✅ Ensure this line is present
    }
}