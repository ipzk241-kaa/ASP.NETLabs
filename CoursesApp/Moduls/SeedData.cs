using CoursesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CourseDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<CourseDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course { Title = "C# для початківців", Description = "Основи C#", Category = "Програмування"/*, Price = 1000*/ },
                    new Course { Title = "Бази даних", Description = "Основи SQL", Category = "ІТ"/*, Price = 1200*/ },
                    new Course { Title = "Алгоритми", Description = "Базові структури даних та алгоритми", Category = "ІТ"/*, Price = 1500*/ },
                    new Course { Title = "Веб-розробка", Description = "HTML, CSS, JavaScript", Category = "ІТ"/*, Price = 1300*/ },
                    new Course { Title = "Англійська мова", Description = "Розмовна англійська для початківців", Category = "Мови"/*, Price = 900*/ },
                    new Course { Title = "Психологія", Description = "Вступ до психології", Category = "Гуманітарні науки"/*, Price = 950*/ },
                    new Course { Title = "Кібербезпека", Description = "Захист даних та інформаційних систем", Category = "ІТ"/*, Price = 1600*/ },
                    new Course { Title = "Менеджмент", Description = "Основи управління проектами", Category = "Бізнес"/*, Price = 1400*/ },
                    new Course { Title = "Маркетинг", Description = "Цифровий маркетинг і SEO", Category = "Бізнес"/*, Price = 1250*/ },
                    new Course { Title = "Графічний дизайн", Description = "Основи Adobe Photoshop та Illustrator", Category = "Мистецтво"/*, Price = 1350*/ }
                    );
                context.SaveChanges();
            }
        }
    }
}
