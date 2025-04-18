using Microsoft.AspNetCore.Mvc;
using CourseManagement.Models;
using CourseManagement.Models.ViewModels;
using System.Linq;

namespace CoursesApp.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly ICourseRepository repository;

        public NavigationMenuViewComponent(ICourseRepository repo) => repository = repo;

        public IViewComponentResult Invoke()
        {
            var categories = repository.Courses
                .Select(c => c.Category)
                .Distinct()
                .OrderBy(c => c);

            string? selectedCategory = RouteData?.Values["category"] as string;

            ViewBag.SelectedCategory = selectedCategory;

            return View(categories);
        }
    }
}
