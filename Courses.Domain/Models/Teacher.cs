using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Courses.Domain.Models
{
    public class Teacher
    {
        public long TeacherID { get; set; }

        [Required(ErrorMessage = "Введіть ПІБ")]
        public string FullName { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
