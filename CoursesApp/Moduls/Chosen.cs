namespace Courses.Domain.Models
{
    public class Chosen
    {
        public List<Course> Items { get; set; } = new List<Course>();

        public virtual void AddItem(Course course)
        {
            if (!Items.Any(c => c.CourseID == course.CourseID))
                Items.Add(course);
        }

        public virtual void RemoveItem(long courseId)
        {
            Items.RemoveAll(c => c.CourseID == courseId);
        }

        public virtual void Clear()
        {
            Items.Clear();
        }
    }
}
