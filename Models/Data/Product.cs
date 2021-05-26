using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class Product
    {
        public int idProduct { get; set; }
        public string name { get; set; }

        //public int idGroupType { get; set; }
        //public GroupType GroupType { get; set; }
        //public virtual ICollection<Atribute> Atributes { get; set; }
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
        //public List<ProductAtribute> ProductAtributes { get; set; } = new List<ProductAtribute>();
        //public Product(string n, GroupType groupType)
        //{
        //    name = n;
        //    GroupType = groupType;
        //    idGroupType = groupType.idGroupType;
        //}
    }
}
