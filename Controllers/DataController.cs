using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsReviewsAngular.DTO;
using ProductsReviewsAngular.Interfaces;
using ProductsReviewsAngular.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Controllers
{
    [ApiController]
    [Route("/api/Data")]
    public class DataController : Controller
    {

        Models.ApplicationContext db;
        public DataController(Models.ApplicationContext context)
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
            GroupType group = db.GroupTypes.Include(x => x.atributesGroups).FirstOrDefault(x => x.idGroupType == id);
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
            return db.AtributesGroups.Include(atr => atr.atributes).AsNoTracking().Where(x=>x.GroupType.idGroupType == id).ToList();
        }

        [HttpGet("Atributes/{id}")]
        public IEnumerable<Atribute> GetAllAtribute(int id)
        {
            return db.Atributes.Include(ag => ag.AtributeValues).AsNoTracking().Where(x=>x.AtributesGroup.idAtrbutesGroup==id).ToList();
        }
        
        [HttpGet("AtributeValues/{id}")]
        public IEnumerable<AtributeValue> GetAtributeValuesFromAtribute(int id)
        {
            return db.AtributeValues.Include(av => av.childrens).AsNoTracking().Where(x=>x.atribute.idAtribute==id).ToList();
        }

        [HttpGet("AtributeValues/{id}/{value}")]
        public IEnumerable<AtributeValue> GetAtributeValuesChildrens(int id, string value)
        {
            return db.AtributeValues.AsNoTracking().FirstOrDefault(x=>x.atribute.idAtribute==id && string.Equals(x.value, value)).childrens.ToList();
        }

        [HttpGet("Product")]
        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products.AsNoTracking().ToList();
        }

        
        [HttpPost("Product/Filter")]
        public IEnumerable<Product> GetFilteredProducts([FromBody]FilterProductDto data)
        {
            List<Product> prods = db.Products.AsNoTracking().ToList();
            foreach(var av in data.selectedAV){
                prods = prods.Where(pr => pr.AtributeValues.Any(a => a.idAtribute == av.idAtribute && string.Equals(a.value,av.value))).ToList();
            }
            return prods;
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

        [HttpGet("Article/{prodID}")]
        public IEnumerable<Article> getArticle(int prodID){
            return db.Articles.Include(art => art.user).AsNoTracking().Where(art => art.product.idProduct == prodID).ToList();
        }

        [Authorize(Roles = "User, Administrator")]
        [HttpPost("Article")]
        public async Task<IActionResult> PostArticle([FromBody]ArticleAddDto data)
        {
            data.article.user = db.Users.Find(data.article.user.Id);

            //проверка продукта на существование
            data.article.product.normalizedName = NormalizeString(data.article.product.name);
            Product product = db.Products.FirstOrDefault(pr => string.Equals(pr.normalizedName, data.article.product.normalizedName));
            if(product == null)
            {
                data.article.product.name = data.article.product.name.Trim();
                data.isNewProduct = true;

                data.article.product.Producer.normalizedName = NormalizeString(data.article.product.Producer.name);
                Producer producer = db.Producers.FirstOrDefault(pr => string.Equals(pr.normalizedName, data.article.product.Producer.normalizedName));
                if (producer == null)
                {
                    data.article.product.Producer.name = data.article.product.Producer.name.Trim();


                    data.article.product.Producer.Country.normalizedName = NormalizeString(data.article.product.Producer.Country.name);
                    Country country = db.Countries.FirstOrDefault(co => string.Equals(co.normalizedName, data.article.product.Producer.Country.normalizedName));
                    if (country == null)
                    {
                        data.article.product.Producer.Country.name = data.article.product.Producer.Country.name.Trim();
                    }
                    else
                    {
                        data.article.product.Producer.Country = country;
                    }
                }
                else
                {
                    data.article.product.Producer = producer;
                }
            }
            else
            {
                data.isNewProduct = false;
                data.article.product = product;
            }

            if (data.isNewProduct)
            {
                var AtrVList = data.article.product.AtributeValues.ToList();

                for(int i =0; i<AtrVList.Count; i++)
                {

                    AtrVList[i].atribute = db.Atributes.FirstOrDefault(atr => atr.idAtribute == AtrVList[i].idAtribute);

                    //проверка значения на существование
                    AtrVList[i].normalizedValue = NormalizeString(AtrVList[i].value);
                    AtributeValue atributeValue = db.AtributeValues.FirstOrDefault(av => av.idAtribute == AtrVList[i].idAtribute && string.Equals(av.normalizedValue, AtrVList[i].normalizedValue));
                    if(atributeValue != null)
                    {
                        AtrVList[i] = atributeValue;
                    }
                    else
                    {
                        AtrVList[i].value = AtrVList[i].value.Trim();
                        if (i > 0)
                        {
                            AtrVList[i].parent = AtrVList[i - 1];
                        }
                        db.AtributeValues.Add(AtrVList[i]);
                    }
                }        
                await db.SaveChangesAsync();

            }
            if (ModelState.IsValid)
            {
                await db.Articles.AddAsync(data.article);
                db.SaveChanges();
                if(!data.isNewProduct){
                    UpdateProduct(data.article.product.idProduct);
                }
                return Ok(data);
            }
            return BadRequest(ModelState);
        }

        public static string NormalizeString(string str)
        {
            string[] stringToReplace = { "*"," ", "'" };
            foreach (string st in stringToReplace)
            {
               str = str.Replace(st, "");
            }
            return str.Normalize().ToUpper();
        }

        private void UpdateProduct(int ProdID){
            float rate = 0;
            int sum = 0;

            foreach(var art in db.Articles){
                sum+=art.rating;
            }
            rate = (float)sum/db.Articles.Count();

            Product prod = db.Products.Find(ProdID);
            prod.rating = rate;
            db.Products.Update(prod);
            db.SaveChanges();
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
