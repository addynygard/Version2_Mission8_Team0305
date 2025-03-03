
using System.Collections.Generic;
using Version2_Mission8_Team0305.Models;

namespace Version2_Mission8_Team0305.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<aTask> GetTasks();
        aTask GetTaskById(int id);
        void AddTask(aTask task);
        void UpdateTask(aTask task);
        void DeleteTask(int id);
        IEnumerable<Category> GetCategories();
        void Save();
    }
}
