using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsReviewsAngular.Interfaces;
using ProductsReviewsAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("/api/Data")]
    public class GroupTypeController : Controller
    {

        Models.AppContext db;
        public GroupTypeController(Models.AppContext context)
        {
            db = context;
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("GroupType/{id}")]
        public IActionResult DeleteGroupType(int id)
        {
            GroupType group = db.GroupTypes.FirstOrDefault(x => x.idGroupType == id);
            if(group != null)
            {
                db.GroupTypes.Remove(group);
                db.SaveChanges();
            }
            return Ok(group);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("GroupType/{id}")]
        public GroupType GetGroupType(int id)
        {
            GroupType group = db.GroupTypes.FirstOrDefault(x => x.idGroupType == id);
            return group;
        }

        [HttpGet("GroupType")]
        public IEnumerable<GroupType> GetAllGroupType()
        {
            return db.GroupTypes.ToList();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("GroupType")]
        public IActionResult PostGroupType(GroupType data)
        {
            Console.WriteLine(data);
            if (ModelState.IsValid)
            {
                db.GroupTypes.Add(data);
                db.SaveChanges();
                return Ok(data);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("GroupType")]
        public IActionResult PutGroupType(GroupType data)
        {
            if (ModelState.IsValid)
            {
                db.Update(data);
                db.SaveChanges();
                return Ok(data);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Product")]
        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        [HttpGet("Producer")]
        public IEnumerable<Producer> GetProducers()
        {
            return db.Producers.ToList();
        }

        [HttpGet("Country")]
        public IEnumerable<Country> GetCountries()
        {
            return db.Countries.ToList();
        }


        [Authorize(Roles = "User")]
        [HttpPost("Article")]
        public IActionResult PostArticle(Article data)
        {
            Console.WriteLine(data);
            if (ModelState.IsValid)
            {
                db.Articles.Add(data);
                db.SaveChanges();
                return Ok(data);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "User")]
        [HttpPut("Article")]
        public IActionResult PutArticle(Article data)
        {
            if (ModelState.IsValid)
            {
                db.Update(data);
                db.SaveChanges();
                return Ok(data);
            }
            return BadRequest(ModelState);
        }

    }
}
