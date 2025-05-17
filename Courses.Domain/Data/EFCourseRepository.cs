using Courses.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses.Domain.Data
{
    public class EFCourseRepository : ICourseRepository
    {
        private CourseDbContext context;

        public EFCourseRepository(CourseDbContext ctx) => context = ctx;

        public IQueryable<Course> Courses => context.Courses.Include(c => c.Tea);
        public void CreateCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            context.Courses.Remove(course);
            context.SaveChanges();
        }

        public void SaveCourse(Course course)
        {
            context.Courses.Update(course);
            context.SaveChanges();
        }

        public Course? GetCourse(long id)
        {
            return context.Courses.Include(c => c.Tea).FirstOrDefault(c => c.CourseID == id);
        }

        public IQueryable<Teacher> Teachers => context.Teachers;
        public void CreateTeacher(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        public void DeleteTeacher(Teacher teacher)
        {
            context.Teachers.Remove(teacher);
            context.SaveChanges();
        }

        public void SaveTeacher(Teacher teacher)
        {
            context.Teachers.Update(teacher);
            context.SaveChanges();
        }

        public Teacher? GetTeacher(long id)
        {
            return context.Teachers.Include(t => t.Courses).FirstOrDefault(t => t.TeacherID == id);
        }

    }
}
