
using System.Collections.Generic;
using Version2_Mission8_Team0305.Models;

namespace Version2_Mission8_Team0305.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<ToDoTask> GetTasks();
        ToDoTask GetTaskById(int id);
        void AddTask(ToDoTask task);
        void UpdateTask(ToDoTask task);
        void DeleteTask(int id);
        IEnumerable<Category> GetCategories();
        void Save();
    }
}
