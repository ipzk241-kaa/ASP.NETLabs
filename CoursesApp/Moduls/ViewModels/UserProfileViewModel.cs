using Courses.Domain.Models;

namespace CoursesApp.Moduls.ViewModels
{
    public class UserProfileViewModel
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
