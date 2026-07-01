using Microsoft.AspNetCore.Mvc;

namespace LoginProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Name = HttpContext.Session.GetString("UserName");

            return View();
        }
    }
}