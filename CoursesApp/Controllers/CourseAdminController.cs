using Courses.Domain.Data;
using Courses.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoursesApp.Controllers
{
    public class CourseAdminController : Controller
    {
        private ICourseRepository repository;

        public CourseAdminController(ICourseRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() => View(repository.Courses);

        public IActionResult Details(long id)
        {
            var course = repository.GetCourse(id);
            if (course == null) return NotFound();
            return View(course);
        }

        public IActionResult Create()
        {
            ViewBag.Teachers = new SelectList(repository.Teachers, "TeacherID", "FullName");
            return View(new Course());
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                repository.CreateCourse(course);
                return RedirectToAction("Index");
            }
            ViewBag.Teachers = new SelectList(repository.Teachers, "TeacherID", "FullName");
            return View(course);
        }

        public IActionResult Edit(long id)
        {
            var course = repository.GetCourse(id);
            if (course == null) return NotFound();
            ViewBag.Teachers = new SelectList(repository.Teachers, "TeacherID", "FullName", course.TeacherID);
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCourse(course);
                return RedirectToAction("Index");
            }
            ViewBag.Teachers = new SelectList(repository.Teachers, "TeacherID", "FullName", course.TeacherID);
            return View(course);
        }

        public IActionResult Delete(long id)
        {
            var course = repository.GetCourse(id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var course = repository.GetCourse(id);
            if (course != null) repository.DeleteCourse(course);
            return RedirectToAction("Index");
        }
    }
}
