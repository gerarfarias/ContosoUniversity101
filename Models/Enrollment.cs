using ContosoUniversity101.Models;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public enum Grade { A, B, C, D, F }

    public class Enrollment
    {
        public int Id { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [Display(Name = "Grade")]
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
    }
}
