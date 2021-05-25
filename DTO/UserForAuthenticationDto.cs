using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.DTO
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Укажите email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Укажите пароль!")]
        public string Password { get; set; }
    }
}
