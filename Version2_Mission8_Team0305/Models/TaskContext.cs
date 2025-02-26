using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team03_05.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }
}