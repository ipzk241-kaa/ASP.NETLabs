using Microsoft.AspNetCore.Mvc;
using CoursesApp.Models;
using CourseManagement.Models;

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
    }
}
