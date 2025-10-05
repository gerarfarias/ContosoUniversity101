using ContosoUniversity101.Data;
using ContosoUniversity101.Models;
using ContosoUniversity101.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity101.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentService _studentService;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(StudentService studentService, ILogger<StudentsController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Fetching all students at {Time}", DateTime.UtcNow);
            var students = await _studentService.GetAllStudentsAsync();
            _logger.LogInformation("Retrieved {Count} students", students.Count);
            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Details called with null id at {Time}", DateTime.UtcNow);
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null)
            {
                _logger.LogWarning("Student with ID {StudentId} not found", id);
                return NotFound();
            }

            _logger.LogInformation("Displaying details for student {StudentId}", id);
            return View(student);
        }
    }
}
