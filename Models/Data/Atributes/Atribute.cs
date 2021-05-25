using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class Atribute
    {
        public int idAtribute { get; set; }
        public string name { get; set; }
        public bool isEnable { get; set; }
        public bool isCanBeMany { get; set; }
        //public int? atributeNum { get => AtributesGroup?.atributes.ToList().IndexOf(this); }

        public int idAtrbutesGroup { get; set; }
        public virtual AtributesGroup AtributesGroup { get; set; }

        //public virtual IEnumerable<Product> Products { get; set; }
        public virtual IEnumerable<AtributeValue> AtributeValues { get; set; }

        //public Atribute(string n, AtributesGroup atributesGroup)
        //{
        //    name = n;
        //    AtributesGroup = atributesGroup;
        //    idAtrbutesGroup = atributesGroup.idAtrbutesGroup;
        //}
    }
}
