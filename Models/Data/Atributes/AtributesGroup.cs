using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class AtributesGroup
    {
        [Display(Name = "№ Категории")]
        public int idAtrbutesGroup { get; set; }

        [Required(ErrorMessage = "Введите название категории")]
        [Display(Name = "Название категории")]
        [ConcurrencyCheck]
        [MaxLength(50)]
        public string name { get; set; }
        public virtual int idGroupType { get; set; }
        public virtual GroupType GroupType { get; set; }

        [Display(Name = "Созданные атрибуты")]
        public virtual List<Atribute> atributes { get; set; } = new List<Atribute>();

        public override string ToString()
        {
            if (GroupType != null)
            {
                return "id: " + idAtrbutesGroup + " name: " + name + " AtributeCount: " + atributes.Count() + " GroupTypeID:" + idGroupType + " GroupType:" + GroupType.ToString();
            }
            else
            {
                return "id: " + idAtrbutesGroup + " name: " + name + " AtributeCount: " + atributes.Count() + " GroupTypeID:" +idGroupType;
            }
        }
    }
}
