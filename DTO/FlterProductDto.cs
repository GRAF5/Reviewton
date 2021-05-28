using ProductsReviewsAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.DTO
{
    public class FilterProductDto
    {
        public List<AtributeValue> selectedAV { get; set; }
    }
}
