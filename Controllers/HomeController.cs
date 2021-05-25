using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductsReviewsAngular.Controllers
{
    public class HomeController : Controller
    {
        Models.AppContext db;
        public HomeController(Models.AppContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Products.Include(a=>a.AtributeValues).ToList());
        }
        public IActionResult Alcohol()
        {
            return View();
        }
    }
}
