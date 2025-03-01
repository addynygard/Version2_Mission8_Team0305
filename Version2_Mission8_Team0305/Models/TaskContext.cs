using Microsoft.EntityFrameworkCore;
using Version2_Mission8_Team0305.Models;  // Make sure to import the namespace for Task

namespace Version2_Mission8_Team0305.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasKey(t => t.TaskId); // Ensures TaskId is the primary key
        }
    }
}
