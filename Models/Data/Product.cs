using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class Product
    {
        public int idProduct { get; set; }
        [ConcurrencyCheck]
        [MaxLength(50)]
        public string name { get; set; }
        public string normalizedName { get; set; }
        public float rating {get; set; }
        public virtual ICollection<AtributeValue> AtributeValues { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual Producer Producer { get; set; }
        public HashSet<string> GetValuesSet()
        {
            HashSet<string> set = new HashSet<string>();
            foreach(var av in AtributeValues)
            {
                set.Add(av.value);
            }
            return set;
        }
    }
}
