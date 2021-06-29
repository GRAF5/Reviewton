using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProductsReviewsAngular.Models
{
    public class User:IdentityUser
    {
        [MaxLength(20)]
        public string Nickname { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
