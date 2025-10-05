using ContosoUniversity101.Data;
using ContosoUniversity101.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity101.Services
{
    public class StudentService
    {
        private readonly SchoolContext _context;

        public StudentService(SchoolContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }
    }
}
