using ContosoUniversity.Models;
using ContosoUniversity101.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity101.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Range(0, 10)]
        public int Credits { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
