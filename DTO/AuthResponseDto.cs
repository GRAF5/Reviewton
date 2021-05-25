using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.DTO
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public User user;
        
        public class User
        {
            public string ID { get; set; }
            public string Nickname { get; set; }
            public string Email { get; set; }
        }
    }
}
