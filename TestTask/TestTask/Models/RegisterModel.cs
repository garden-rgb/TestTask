using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

    }
}
