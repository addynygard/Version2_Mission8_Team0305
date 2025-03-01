using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Version2_Mission8_Team0305.Models;


namespace Version2_Mission8_Team0305.Controllers
{
    public class HomeController : Controller
    {

        private TaskContext _context;
        // Constructor that takes in a EnterMoviesContext object and assigns it to the private instance
        public HomeController(TaskContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public IActionResult Form(aTask response)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(response);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to task list after submission
            }
            var categories = new List<string> { "Home", "School", "Work", "Church" };
            ViewData["Categories"] = categories;
            return View(response); // If invalid, return form with errors
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
            var recordToEdit = _context.Tasks.FirstOrDefault(x => x.Id == id);
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
                _context.Update(updatedInfo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Form", updatedInfo); // Return form if validation fails
        }
        [HttpGet]
        public IActionResult Confirmation(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }












    }
}
