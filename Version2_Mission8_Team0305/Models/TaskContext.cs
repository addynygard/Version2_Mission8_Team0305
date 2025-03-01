using Microsoft.EntityFrameworkCore;

namespace Version2_Mission8_Team0305.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<aTask> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; } // ✅ Ensure this line is present
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<aTask>()
                .HasKey(t => t.TaskId); // Ensures TaskId is the primary key
        }
    }
}