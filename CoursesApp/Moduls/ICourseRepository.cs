using CoursesApp.Models;

namespace CourseManagement.Models
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
    }
}
