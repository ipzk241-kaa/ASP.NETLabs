using Microsoft.AspNetCore.Identity;

namespace Courses.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        // public string Role { get; set; }
    }
}
