using Microsoft.AspNetCore.Mvc;
using Courses.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Courses.Domain.Data;
using Microsoft.AspNetCore.Identity;

namespace CoursesApp.Controllers
{
    public class ChosenController : Controller
    {
        private readonly ICourseRepository repository;

        public ChosenController(ICourseRepository repo)
        {
            repository = repo;
        }

        public RedirectToActionResult AddToChosen(long courseId)
        {
            var course = repository.Courses.FirstOrDefault(c => c.CourseID == courseId);
            if (course != null)
            {
                var Chosen = SessionChosen.GetChosen(HttpContext.RequestServices);
                Chosen.AddItem(course);
            }
            return RedirectToAction("ViewChosen", "Chosen");
        }

        public RedirectToActionResult RemoveFromChosen(long courseId)
        {
            var Chosen = SessionChosen.GetChosen(HttpContext.RequestServices);
            Chosen.RemoveItem(courseId);
            return RedirectToAction("ViewChosen");
        }

        public IActionResult ViewChosen()
        {
            var Chosen = SessionChosen.GetChosen(HttpContext.RequestServices);
            return View(Chosen);
        }

        public RedirectToActionResult ClearChosen()
        {
            var Chosen = SessionChosen.GetChosen(HttpContext.RequestServices);
            Chosen.Clear();
            return RedirectToAction("ViewChosen");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ConfirmChosen([FromServices] UserManager<ApplicationUser> userManager, [FromServices] CourseDbContext context)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var chosen = SessionChosen.GetChosen(HttpContext.RequestServices);

            foreach (var course in chosen.Items)
            {
                if (!context.UserCourses.Any(uc => uc.UserId == user.Id && uc.CourseId == course.CourseID))
                {
                    context.UserCourses.Add(new UserCourse
                    {
                        UserId = user.Id,
                        CourseId = (long)course.CourseID
                    });
                }
            }

            await context.SaveChangesAsync();
            chosen.Clear();

            return RedirectToAction("Profile", "Account");
        }

    }
}
