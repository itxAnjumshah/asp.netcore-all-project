// Required Namespaces
using Microsoft.AspNetCore.Mvc;
using webapitopic2final.Models;

namespace StudentApi.Controllers
{
    // API Controller
    [ApiController]

    // URL => api/Student
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        // Database Context Variable
        private readonly AppDbContext _context;

        // Constructor
        // Iske through database context automatically milta hai.
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // GET ALL STUDENTS
        // URL => GET: api/Student
        // =====================================================
        [HttpGet]
        public IActionResult GetStudents()
        {
            // Database se tamam students lao
            var students = _context.Students.ToList();

            // Data client ko return karo
            return Ok(students);
        }

        // =====================================================
        // GET STUDENT BY ID
        // URL => GET: api/Student/1
        // =====================================================
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            // ID ke through student search karo
            var student = _context.Students.Find(id);

            // Agar student nahi mila
            if (student == null)
            {
                return NotFound("Student Not Found");
            }

            // Student mil gaya
            return Ok(student);
        }

        // =====================================================
        // ADD NEW STUDENT
        // URL => POST: api/Student
        // =====================================================
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            // Student database me add karo
            _context.Students.Add(student);

            // Database me save karo
            _context.SaveChanges();

            // Added student return karo
            return Ok(student);
        }

        // =====================================================
        // UPDATE STUDENT
        // URL => PUT: api/Student/1
        // =====================================================
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            // Purana student dhoondo
            var oldStudent = _context.Students.Find(id);

            // Agar student nahi mila
            if (oldStudent == null)
            {
                return NotFound("Student Not Found");
            }

            // Naye values update karo
            oldStudent.Name = student.Name;
            oldStudent.Age = student.Age;
            oldStudent.City = student.City;

            // Changes save karo
            _context.SaveChanges();

            // Updated student return karo
            return Ok(oldStudent);
        }

        // =====================================================
        // DELETE STUDENT
        // URL => DELETE: api/Student/1
        // =====================================================
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            // Student search karo
            var student = _context.Students.Find(id);

            // Agar student nahi mila
            if (student == null)
            {
                return NotFound("Student Not Found");
            }

            // Student delete karo
            _context.Students.Remove(student);

            // Database me changes save karo
            _context.SaveChanges();

            // Success message
            return Ok("Student Deleted Successfully");
        }
    }
}