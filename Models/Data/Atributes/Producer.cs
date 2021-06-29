using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class Producer
    {
        public int idProducer { get; set; }
        [MaxLength(50)]
        [ConcurrencyCheck]
        public string name { get; set; }
        public string normalizedName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Country Country { get; set; }
    }
}
