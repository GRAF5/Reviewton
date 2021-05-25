using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class Comment
    {
        public int idComment { get; set; }
        public virtual int idArticle { get; set; }
        public virtual Article Article { get; set; }
        public virtual int idUser { get; set; }
        public virtual User User { get; set; }
        public string text { get; set; }
    }
}
