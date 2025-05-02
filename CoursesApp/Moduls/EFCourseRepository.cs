using CoursesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Models
{
    public class EFCourseRepository : ICourseRepository
    {
        private CourseDbContext context;

        public EFCourseRepository(CourseDbContext ctx) => context = ctx;

        public IQueryable<Course> Courses => context.Courses.Include(c => c.Tea);
    }
}
