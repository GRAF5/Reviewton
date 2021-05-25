using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class Country
    {
        public int idCountry { get; set; }
        public string name { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }
    }
}
