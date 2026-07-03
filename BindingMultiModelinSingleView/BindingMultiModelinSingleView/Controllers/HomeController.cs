using BindingMultiModelinSingleView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BindingMultiModelinSingleView.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>
            {
                new Student { id = "1", name = "John", Gender = "Male", standard = 10 },
                new Student { id = "2", name = "Jane", Gender = "Female", standard = 11 },
                new Student { id = "3", name = "Bob", Gender = "Male", standard = 12 }
            };

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "harry", Qualification = "MSc", salary = 50000 },
                new Teacher { Id = 2, Name = "porter", Qualification = "PhD", salary = 60000 },
                new Teacher { Id = 3, Name = "diana", Qualification = "MA", salary = 45000 }
            };

            SchoolViewModels svm = new SchoolViewModels()
            {
                MYStudents = students,
                MYTeachers = teachers
            };


            return View(svm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
