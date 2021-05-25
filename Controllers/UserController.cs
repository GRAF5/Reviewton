using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Controllers
{
    public class UserController : Controller
    {
        Models.AppContext db;
        public UserController(Models.AppContext context)
        {
            db = context;
        }

    }
}
