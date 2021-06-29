using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class Atribute
    {
        public int idAtribute { get; set; }
        [ConcurrencyCheck]
        [MaxLength(50)]
        public string name { get; set; }
        public bool isEnable { get; set; }
        public bool isCanBeMany { get; set; }

        public int idAtrbutesGroup { get; set; }
        public virtual AtributesGroup AtributesGroup { get; set; }

        public virtual IEnumerable<AtributeValue> AtributeValues { get; set; }
    }
}
