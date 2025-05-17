using System.ComponentModel.DataAnnotations;

namespace CoursesApp.Moduls.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле 'Ім’я користувача' є обов’язковим")]
        [Display(Name = "Ім’я користувача")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле 'Email' є обов’язковим")]
        [EmailAddress(ErrorMessage = "Невірний формат Email")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле 'Пароль' є обов’язковим")]
        [StringLength(100, ErrorMessage = "Пароль має бути не менше {2} символів", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Пароль має містити великі, малі літери та цифри")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження паролю")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
