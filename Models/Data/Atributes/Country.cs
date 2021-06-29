using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class Country
    {
        public int idCountry { get; set; }
        [ConcurrencyCheck]
        [MaxLength(50)]
        public string name { get; set; }
        public string normalizedName { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }
    }
}
