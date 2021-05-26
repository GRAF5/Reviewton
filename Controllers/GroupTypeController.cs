using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsReviewsAngular.DTO;
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
            return db.GroupTypes.AsNoTracking().ToList();
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

        [HttpGet("AtributesGroup/{id}")]
        public IEnumerable<AtributesGroup> GetAtributesGroupsOf(int id)
        {
            return db.AtributesGroups.AsNoTracking().Where(x=>x.GroupType.idGroupType == id).ToList();
        }

        [HttpGet("Atributes/{id}")]
        public IEnumerable<Atribute> GetAllAtribute(int id)
        {
            return db.Atributes.Include(ag => ag.AtributeValues).AsNoTracking().Where(x=>x.AtributesGroup.idAtrbutesGroup==id).ToList();
        }

        [HttpGet("Product")]
        public IEnumerable<Product> GetProducts()
        {
            return db.Products.AsNoTracking().ToList();
        }

        [Authorize(Roles = "User, Administrator")]
        [HttpPost("Product")]
        public async Task<IActionResult> PostProduct(Product data)
        {
            Console.WriteLine(data);
            if (ModelState.IsValid)
            {
                await db.Products.AddAsync(data);
                db.SaveChanges();
                return Ok(data);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Producer")]
        public IEnumerable<Producer> GetProducers()
        {
            return db.Producers.AsNoTracking().ToList();
        }

        
        [Authorize(Roles = "User, Administrator")]
        [HttpPost("Producer")]
        public async Task<IActionResult> PostProducer(Producer data)
        {
            Console.WriteLine(data);
            if (ModelState.IsValid)
            {
                await db.Producers.AddAsync(data);
                db.SaveChanges();
                return Ok(data);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Country")]
        public IEnumerable<Country> GetCountries()
        {
            return db.Countries.AsNoTracking().ToList();
        }

        [Authorize(Roles = "User, Administrator")]
        [HttpPost("Country")]
        public async Task<IActionResult> PostCountry(Country data)
        {
            Console.WriteLine(data);
            if (ModelState.IsValid)
            {
                await db.Countries.AddAsync(data);
                db.SaveChanges();
                return Ok(data);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "User, Administrator")]
        [HttpPost("Article")]
        public async Task<IActionResult> PostArticle([FromBody]ArticleAddDto data)
        {
            Console.WriteLine("Add Av");
            data.article.User = db.Users.Find(data.article.User.Id);
            var AtrVList = data.article.Product.AtributeValues.ToList();
            for(int i =0; i<AtrVList.Count; i++){
                 Console.WriteLine(AtrVList[i].idAtribute +" " + AtrVList[i].value);
                AtrVList[i].Atribute = db.Atributes.FirstOrDefault(atr=>atr.idAtribute == AtrVList[i].idAtribute);
                if(i<AtrVList.Count-1){
                    AtrVList[i].Childrens.Add(AtrVList[i + 1]);
                }
            }            
            db.AtributeValues.Add(data.article.Product.AtributeValues.ToList()[0]);
            await db.SaveChangesAsync();
            Console.WriteLine("Add Article");
            if (ModelState.IsValid)
            {
                await db.Articles.AddAsync(data.article);
                db.SaveChanges();
                return Ok(data);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "User, Administrator")]
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
