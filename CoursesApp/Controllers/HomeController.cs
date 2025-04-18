using CourseManagement.Models;
using CourseManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private ICourseRepository repository;
    public int PageSize = 4;

    public HomeController(ICourseRepository repo) => repository = repo;

    public IActionResult Index(int page = 1)
    {
        var courses = repository.Courses
            .OrderBy(c => c.CourseID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize);

        var model = new CourseListViewModel
        {
            Courses = courses,
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repository.Courses.Count()
            }
        };

        return View(model);
    }
}
