using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class Producer
    {
        public int idProducer { get; set; }
        public string name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Country Country { get; set; }
    }
}
