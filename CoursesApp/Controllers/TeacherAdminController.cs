using Courses.Domain.Models;
using Courses.Domain.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApp.Controllers
{
    public class TeacherAdminController : Controller
    {
        private ICourseRepository repository;

        public TeacherAdminController(ICourseRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() => View(repository.Teachers);

        public IActionResult Details(long id)
        {
            var teacher = repository.GetTeacher(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        public IActionResult Create() => View(new Teacher());

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                repository.CreateTeacher(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public IActionResult Edit(long id)
        {
            var teacher = repository.GetTeacher(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                repository.SaveTeacher(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public IActionResult Delete(long id)
        {
            var teacher = repository.GetTeacher(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var teacher = repository.GetTeacher(id);
            if (teacher != null) repository.DeleteTeacher(teacher);
            return RedirectToAction("Index");
        }
    }
}
