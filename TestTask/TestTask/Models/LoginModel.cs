using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
