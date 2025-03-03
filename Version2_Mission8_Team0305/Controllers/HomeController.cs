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



        [HttpGet]
        public IActionResult Form()
        {
            var categories = new List<string> { "Home", "School", "Work", "Church" };
            ViewData["Categories"] = categories;

            return View(new aTask()); // Returns an empty Task form
        }

        //[HttpGet]
        //public IActionResult Form()
        //{
        //    //ViewBag.Categories = _context.Category.ToList();

        //    return View(new aTask()); // Returns an empty Task form
        //}
        //[HttpPost]

        //[HttpPost]
        //public IActionResult Form(aTask response)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _taskRepository.Tasks.Add(response);
        //        _taskRepository.SaveChanges();
        //        return RedirectToAction("Index"); // Redirect to task list after submission
        //    }
        //    var categories = new List<string> { "Home", "School", "Work", "Church" };
        //    ViewData["Categories"] = categories;
        //    return View(response); // If invalid, return form with errors
        //}

        [HttpPost]
        public IActionResult Form(aTask response)
        {
            if (ModelState.IsValid)
            {
                _taskRepository.AddTask(response); // ✅ Use repository method instead of accessing "Tasks"
                _taskRepository.Save(); // ✅ Ensure changes are saved to the database
                return RedirectToAction("Index");
            }

            var categories = _taskRepository.GetCategories(); // ✅ Get categories from repository
            ViewData["Categories"] = categories;
            return View(response);
        }
        //public IActionResult Form(aTask response)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Tasks.Add(response);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index"); // Redirect to task list after submission
        //    }
        //    return View(response); // If invalid, return form with errors
        //}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var recordToEdit = _taskRepository.Tasks.FirstOrDefault(x => x.Id == id);
            var recordToEdit = _taskRepository.GetTaskById(id); // ✅ Use repository method
            if (recordToEdit == null)
            {
                return NotFound(); // Return 404 if task not found
            }
            return View("Form", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(aTask updatedInfo)
        {
            if (ModelState.IsValid)
            {
                //_taskRepository.Update(updatedInfo);
                _taskRepository.UpdateTask(updatedInfo);

                _taskRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Form", updatedInfo); // Return form if validation fails
        }
        [HttpGet]
        public IActionResult Confirmation(int id)
        {
            //var task = _taskRepository.Tasks.Find(id);
            var task = _taskRepository.GetTaskById(id); // Use the GetTaskById method from the repository
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }










        // 📌 Create a new task - Form (GET)
        [HttpGet]
        public IActionResult Create()
        {
            PrepareCategoryDropdown();
            return View("Form", new aTask());
        }

        // 📌 Create a new task - Submit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(aTask task)
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
