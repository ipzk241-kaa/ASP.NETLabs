using Courses.Domain.Models;
using Courses.Domain.Data;
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

            if (!context.Courses.Any() && !context.Teachers.Any())
            {
                var t1 = new Teacher { FullName = "Михайло Мельник" };
                var t2 = new Teacher { FullName = "Роман Іванов" };
                var t3 = new Teacher { FullName = "Василь Довгалюк" };
                context.Teachers.AddRange(t1, t2, t3);
                context.Courses.AddRange(
                    new Course { Title = "C# для початківців", Description = "Основи C#", Category = "Програмування", Tea = t1 },
                    new Course { Title = "Бази даних", Description = "Основи SQL", Category = "ІТ", Tea = t2 },
                    new Course { Title = "Алгоритми", Description = "Базові структури даних та алгоритми", Category = "ІТ", Tea = t2 },
                    new Course { Title = "Веб-розробка", Description = "HTML, CSS, JavaScript", Category = "ІТ", Tea = t1 },
                    new Course { Title = "Англійська мова", Description = "Розмовна англійська для початківців", Category = "Мови", Tea = t3 },
                    new Course { Title = "Психологія", Description = "Вступ до психології", Category = "Гуманітарні науки", Tea = t3 },
                    new Course { Title = "Кібербезпека", Description = "Захист даних та інформаційних систем", Category = "ІТ", Tea = t1 },
                    new Course { Title = "Менеджмент", Description = "Основи управління проектами", Category = "Бізнес", Tea = t2 },
                    new Course { Title = "Маркетинг", Description = "Цифровий маркетинг і SEO", Category = "Бізнес", Tea = t2 },
                    new Course { Title = "Графічний дизайн", Description = "Основи Adobe Photoshop та Illustrator", Category = "Мистецтво", Tea = t3 }
                    );
                context.SaveChanges();
            }
        }
    }
}
