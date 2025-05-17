using System.ComponentModel.DataAnnotations;
namespace Courses.Domain.Models
{
    public class Course
    {
        public long? CourseID { get; set; }
        [Required(ErrorMessage = "Введіть назву курсу")]
        [StringLength(100, ErrorMessage = "Назва курсу не повинна перевищувати 100 символів")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Введіть опис курсу")]
        [StringLength(500, ErrorMessage = "Опис не повинен перевищувати 500 символів")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Вкажіть категорію")]
        public string Category { get; set; } = string.Empty;
        [Required(ErrorMessage = "Оберіть викладача")]
        public long? TeacherID { get; set; }
        public Teacher? Tea { get; set; }
    }
}
