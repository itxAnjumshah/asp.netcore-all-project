account controller

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


//////////////------------------/////////////////////
Reister view

@model LoginProject.Models.User

<form method="post">

    <input asp-for="Name" placeholder="Name"/>

    <br />

    <input asp-for="Email" placeholder="Email"/>

    <br />

    <input asp-for="Password"
           type="password"
           placeholder="Password"/>

    <br />

    <button type="submit">
        Register
    </button>

</form>

///////////////------------------/////////////////////
login view



@model LoginProject.Models.User

<form method="post">

<input asp-for="Email"
placeholder="Email"/>

<br/>

<input asp-for="Password"
type="password"
placeholder="Password"/>

<br/>

<button type="submit">

Login

</button>

</form>

<h3>

@ViewBag.Message

</h3>

////////////////------------------/////////////////////
homecontroller.cs


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

/////////////////------------------/////////////////////

dashboard view

<h2>

Welcome

@ViewBag.Name

</h2>

<a asp-controller="Account"
asp-action="Logout">

Logout

</a>

//////////////////------------------/////////////////////