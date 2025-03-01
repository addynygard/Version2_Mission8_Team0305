using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Version2_Mission8_Team0305.Models;
using Version2_Mission8_Team0305.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Version2_Mission8_Team0305.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public HomeController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // 📌 Display all tasks in their respective quadrants
        public IActionResult Index()
        {
            var tasks = _taskRepository.GetTasks()?.Where(t => !t.Completed).ToList() ?? new List<ToDoTask>();
            return View(tasks);
        }

        // 📌 Create a new task - Form (GET)
        [HttpGet]
        public IActionResult Create()
        {
            PrepareCategoryDropdown();
            return View("Form", new ToDoTask());
        }

        // 📌 Create a new task - Submit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoTask task)
        {
            if (!ModelState.IsValid)
            {
                PrepareCategoryDropdown();
                return View("Form", task);
            }

            _taskRepository.AddTask(task);
            _taskRepository.Save();

            return RedirectToAction("Index");
        }

        // 📌 Edit an existing task (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            PrepareCategoryDropdown();
            return View("Form", task);
        }

        // 📌 Edit an existing task (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDoTask task)
        {
            if (!ModelState.IsValid)
            {
                PrepareCategoryDropdown();
                return View("Form", task);
            }

            var existingTask = _taskRepository.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            // Update the existing task properties
            existingTask.TaskItem = task.TaskItem;
            existingTask.DueDate = task.DueDate;
            existingTask.Category = task.Category;
            existingTask.Quadrant = task.Quadrant;
            existingTask.Completed = task.Completed;

            _taskRepository.UpdateTask(existingTask);
            _taskRepository.Save();

            return RedirectToAction("Index");
        }

        // 📌 Delete a task (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var existingTask = _taskRepository.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            _taskRepository.DeleteTask(id);
            _taskRepository.Save();

            return RedirectToAction("Index");
        }

        // 📌 Prepare the dropdown list for categories
        private void PrepareCategoryDropdown()
        {
            var categories = _taskRepository.GetCategories()?.ToList() ?? new List<Category>();

            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Name,
                Text = c.Name
            }).ToList();
        }
    }
}
