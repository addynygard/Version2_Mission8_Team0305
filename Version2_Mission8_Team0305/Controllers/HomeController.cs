using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team03_05.Models;

namespace Mission08_Team03_05.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }




    }
}
