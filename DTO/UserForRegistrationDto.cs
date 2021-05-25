using System.ComponentModel.DataAnnotations;

namespace ProductsReviewsAngular.DTO
{
    public class UserForRegistrationDto
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Укажите пароль!")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Пароль и проверочный пароль не совпадают!")]
        public string ConfirmPassword { get; set; }
    }
}