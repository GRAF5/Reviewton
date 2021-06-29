using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Models
{
    public class Article
    {
        public int idArticle { get; set; }
        public int rating { get; set; }
        public string text { get; set; }
        public virtual Product product { get; set; }
        public virtual User user { get; set; }
        public DateTime time {get;set;}
        public virtual ICollection<Comment> comments { get; set; }

        public override string ToString()
        {
            return "id: " + idArticle + " rating: " + rating + " text: " + text + " Product: " + product + " User: " + user + " time: " + time;
        }
    }
}
