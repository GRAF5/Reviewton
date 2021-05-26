using ProductsReviewsAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.DTO
{
    public class ArticleAddDto
    {
        public bool IsAddingSuccessful { get; set; }
        //public Product product { get; set; }
        public Article article { get; set; }
    }
}
