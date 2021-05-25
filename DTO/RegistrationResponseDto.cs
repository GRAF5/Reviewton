using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.DTO
{
    public class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistrtion { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
