using codefirstapproch.Models;
using Microsoft.AspNetCore.Mvc;
namespace codefirstapproch.Controllers
{
    public class StudentController : Controller
    {
        // DB context object
        private readonly StudentinfoDbContext context;
        // Constructor (DB inject)
        public StudentController(StudentinfoDbContext context)
        {
            this.context = context;
        }
        // ======================================================
        // 🔹 1. CREATE (GET)
        // ======================================================
        public IActionResult Create()
        {
            return View();
        }

        // ======================================================
        // 🔹 2. CREATE (POST)
        // ======================================================
        [HttpPost]
        public IActionResult Create(Student student)
        {
            // check form valid hai ya nahi
            if (ModelState.IsValid)
            {
                context.Students.Add(student);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // ======================================================
        // 🔹 3. READ - ALL STUDENTS
        // ======================================================
        public IActionResult Index()
        {
            var students = context.Students.ToList();
            return View(students);
        }

        // ======================================================
        // 🔹 4. DETAILS (Single record)
        // ======================================================
        public IActionResult Details(int id)
        {
            var student = context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // ======================================================
        // 🔹 5. EDIT (GET)
        // ======================================================
        public IActionResult Edit(int id)
        {
            var student = context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // ======================================================
        // 🔹 6. EDIT (POST)
        // ======================================================
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(student);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // ======================================================
        // 🔹 7. DELETE (NO PAGE, DIRECT DELETE FROM SAME VIEW)
        // ======================================================
        public IActionResult Delete(int id)
        {
            var student = context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            // direct delete (no separate page)
            context.Students.Remove(student);
            context.SaveChanges();

            // same page (Index) par wapas
            return RedirectToAction("Index");
        }
    }
}