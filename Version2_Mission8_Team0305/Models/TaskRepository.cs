using System.Collections.Generic;
using System.Linq;
using Version2_Mission8_Team0305.Models;

namespace Version2_Mission8_Team0305.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDoTask> GetTasks() => _context.Tasks.ToList();

        public ToDoTask GetTaskById(int id) => _context.Tasks.FirstOrDefault(t => t.TaskId == id);

        public void AddTask(ToDoTask task) => _context.Tasks.Add(task);

        public void UpdateTask(ToDoTask task) => _context.Tasks.Update(task);

        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null) _context.Tasks.Remove(task);
        }

        public IEnumerable<Category> GetCategories() => _context.Categories.ToList();

        public void Save() => _context.SaveChanges();
    }
}