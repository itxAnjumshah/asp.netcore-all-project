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

        // ya ma na code  lekha  ha
        public IActionResult Search(int? id)
        {
            if (id != null)
            {
                CourseWiseStudent cws = new CourseWiseStudent();

                // Course find karo
                cws.CrsDetails = context.Courses
                                        .FirstOrDefault(item => item.CourseId == id);

                // Agar course mil gaya
                if (cws.CrsDetails != null)
                {
                    // Us course ke students lao
                    cws.StudentList = context.Students
                                             .Where(item => item.CourseId == id)
                                             .ToList();

                    return View(cws);
                }
                else
                {
                    TempData["error"] = "Please provide a valid Course ID.";
                    return RedirectToAction("Index");
                }
            }

            TempData["error"] = "Please enter a valid Course ID.";
            return RedirectToAction("Index");
        }

        //public IActionResult ShowDetails(CourseWiseStudent cws)
        //{
        //    if (cws.CrsDetails == null)
        //    {
        //        TempData["error"] = "No course found with the provided ID.";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(cws);
        //    }
        //}

        // end of my code

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