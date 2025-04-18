using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CourseDbContext>(opts => {
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:CourseManagementConnection"]);
});
builder.Services.AddScoped<ICourseRepository, EFCourseRepository>();


var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
SeedData.EnsurePopulated(app);
app.Run();
