using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class AtributeValue: IEqualityComparer<AtributeValue>
    {
        //public int idAtributeValue { get; set; }
        public virtual AtributeValue parent { get; set; }
        public virtual ICollection<AtributeValue> childrens { get; set; }
        public int idAtribute { get; set; }
        public virtual Atribute atribute { get; set; }

        public int idProduct { get; set; }
        public virtual Product product { get; set; }

        public string value { get; set; }
        
        public bool Equals(AtributeValue av1, AtributeValue av2)
        {
            return (av1.idAtribute == av2.idAtribute &&
               av1.idProduct == av2.idProduct);
        }
        public int GetHashCode(AtributeValue av)
        {
            return (idAtribute + "|" + idProduct).GetHashCode();
        }
        //public List<ProductAtribute> ProductAtributes { get; set; } = new List<ProductAtribute>();
        //public List<Product> Products { get; set; } = new List<Product>();

        //public AtributeValue(string v, Atribute atribute)
        //{
        //    value = v;
        //    Atribute = atribute;
        //    idAtribute = atribute.idAtribute;
        //}
    }
}
