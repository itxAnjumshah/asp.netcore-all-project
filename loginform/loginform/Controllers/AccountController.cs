using LoginProject.Data;
using LoginProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LoginProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext db;

        public AccountController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var check = db.Users.FirstOrDefault(x =>
            x.Email == user.Email &&
            x.Password == user.Password);

            if (check != null)
            {
                HttpContext.Session.SetString("UserName", check.Name);

                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.Message = "Invalid Login";

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}