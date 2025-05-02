using CoursesApp.Models;

namespace CourseManagement.Models
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
        void CreateCourse(Course course);
        void DeleteCourse(Course course);
        void SaveCourse(Course course);
        Course? GetCourse(long id);
        IQueryable<Teacher> Teachers { get; }
        void CreateTeacher(Teacher teacher);
        void DeleteTeacher(Teacher teacher);
        void SaveTeacher(Teacher teacher);
        Teacher? GetTeacher(long id);
    }
}
