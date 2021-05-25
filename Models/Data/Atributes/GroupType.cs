using ProductsReviewsAngular.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class GroupType: IData
    {
        [Display(Name = "№ Группы")]
        public int idGroupType { get; set; }

        [Required(ErrorMessage = "Введите название группы")]
        [Display(Name = "Название группы")]
        public string name { get; set; }

        [Display(Name = "Созданные категории")]
        public virtual List<AtributesGroup> atributesGroups { get; set; } = new List<AtributesGroup>();
        
        public override string ToString()
        {
            return "id: " + idGroupType + " name: " + name + " AtributeCount: " + atributesGroups.Count();
        }
    }
}
