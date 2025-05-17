namespace Courses.Domain.Models
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
