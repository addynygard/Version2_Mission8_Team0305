using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Version2_Mission8_Team0305.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }
}