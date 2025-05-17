using System.ComponentModel.DataAnnotations;

namespace CoursesApp.Moduls.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введіть ім’я користувача або email")]
        [Display(Name = "Ім’я користувача або Email")]
        public string UserNameOrEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Запам'ятати мене")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
