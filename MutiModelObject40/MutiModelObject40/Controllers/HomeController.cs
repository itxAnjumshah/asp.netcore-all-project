using Microsoft.AspNetCore.Mvc;
using MutiModelObject40.Models;
using MutiModelObject40.ViewModels;
using System.Diagnostics;

namespace MutiModelObject40.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentInfoDbContext context;

        public HomeController(ILogger<HomeController> logger, StudentInfoDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Search(int? id)
        {
            if (id != null)
            {
                CourseWiseStudent cws = new CourseWiseStudent();
                cws.CrsDetails = context.Courses.FirstOrDefault(item => item.CourseId == id);
                cws.StudentList = context.Students.Where(item => item.CourseId == id).ToList();
            }

            TempData["error"] = "Please enter a valid course ID.";
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}