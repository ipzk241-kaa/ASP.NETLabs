using Microsoft.AspNetCore.Identity;

namespace CourseManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime? BirthDate { get; set; }

        // public string Role { get; set; }
    }
}
