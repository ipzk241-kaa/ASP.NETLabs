using CourseManagement.Models;
using CoursesApp.Models;

namespace CoursesApp.Moduls
{
    public class UserCourse
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        public long CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
