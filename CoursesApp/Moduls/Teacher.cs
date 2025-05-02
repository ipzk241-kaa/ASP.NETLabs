using CoursesApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoursesApp.Models
{
    public class Teacher
    {
        public long TeacherID { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
