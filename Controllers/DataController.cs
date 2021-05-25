using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsReviewsAngular.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ProductsReviewsAngular.Interfaces;
//using ProductsReviewsAngular.ViewModels;

namespace ProductsReviewsAngular.Controllers
{
    [ApiController]
    public class DataController : Controller
    {
        Models.AppContext db;
        public DataController(Models.AppContext context)
        {
            db = context;
        }

        ////[Route("Serch")]
        //public async Task<IActionResult> GroupTypes()
        //{
        //    return View(await db.GroupTypes.ToListAsync());
        //}

        ////[Route("/{gtID?}")]
        ////[Authorize(Roles = "user")]
        //public async Task<IActionResult> AtributeGroups(int? gtID)
        //{
        //    if (gtID == null)
        //    {
        //        return NotFound();
        //    }

        //    GroupType groupType = await db.GroupTypes
        //        .FindAsync(gtID);
        //    var atributeGroups = groupType.atributesGroups;
        //    if (atributeGroups == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(atributeGroups.ToList());
        //}
        ////[FromRoute("Data/AtributeGroups/{gtID}")]
        //public async Task<IActionResult> Atributes(int? id, int? avID)
        //{
        //    if (id == null && avID == null)
        //    {
        //        return NotFound();
        //    }
        //    else if(avID == null)
        //    {
        //        AtributesGroup atributesGroups = await db.AtributesGroups
        //        .FindAsync(id);
        //        var atributeValues = atributesGroups.atributes.ElementAt(0).AtributeValues;
        //        if (atributeValues == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(atributeValues.ToList());
        //    }
        //    else
        //    {
        //        return View(db.AtributeValues.Find(avID).Childrens.ToList());
        //    }
            
        //}
        ////[Route("Serch/{gt}/{ag}/~/{value?}")]
        //public async Task<IActionResult> Products(int? agID, int? avID)
        //{
        //    //if(atributeValue != null)
        //    //{
        //    //    FilterParametrs.isEnable = true;               
        //    //    FilterParametrs.atributeValues.Add(atributeValue);
        //    //}
        //    //if (FilterParametrs.isEnable)
        //    //{
        //    //    //if (db.Products.ToList().Where(p => p.AtributeValues.SequenceEqual(FilterParametrs.atributeValues)).Count()>0)                   
        //    //    //    return null;
        //    //    return View(db.Products
        //    //        .ToList()
        //    //        .Where(p => p
        //    //        .GetValuesSet().Except(FilterParametrs.atributeValues).Count() == 0
        //    //        //.AtributeValues.ToHashSet(). //ElementAt(0)==atributeValue//SequenceEqual(FilterParametrs.atributeValues, new AtributeValue())
        //    //        //.AtributeValues.Contains(atributeValue)
        //    //        ));
        //    //}
        //    List<AtributeValue> values = new List<AtributeValue>();
        //    AtributeValue value = db.AtributeValues.Find(avID);
        //    while (value != null)
        //    {
        //        values.Add(value);
        //        value = value.Parent;
        //    }
        //    return View(await Products(db.AtributesGroups.Find(agID).atributes, values));
        //}
        //private async Task<ICollection<Product>> Products(ICollection<Atribute>? atributes, ICollection<AtributeValue>? values)
        //{
        //    ICollection<Product> products = await db.Products.ToListAsync();
        //    if (atributes is null || values is null)
        //    {
        //        return products;
        //    }
        //    foreach(Atribute a in atributes)
        //    {
        //        products = GetProducts(a, values.Where(v => v.Atribute == a).ToList(), products);
        //    }
        //    return products;
        //}
        //private ICollection<Product> GetProducts(Atribute atribute, ICollection<AtributeValue>? values, ICollection<Product> products)
        //{
        //    return products.Where(p => values.Contains(p.AtributeValues.Single(av => av.Atribute == atribute))).ToList();
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddORUpdateGroupType(GroupType model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (!db.GroupTypes.Contains(model))
        //        {
        //            if (!db.GroupTypes.Any(gt => gt.name == model.name))
        //            {
        //                db.GroupTypes.Add(model);
        //                db.SaveChanges();
        //                return RedirectToAction("GroupTypes", "Data");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, "Группа с таким именем уже существует");
        //            }
        //        }
        //        else
        //        {
        //            if (db.GroupTypes.Count(gt=>gt.idGroupType!=model.idGroupType && gt.name == model.name) == 0)
        //            {
        //                db.GroupTypes.Update(model);
        //                db.SaveChanges();
        //                return RedirectToAction("GroupTypes", "Data");
        //            }
        //            else
        //            {
        //                model = db.GroupTypes.Find(model.idGroupType);
        //                ModelState.AddModelError(string.Empty, "Группа с таким именем уже существует");
        //            }
        //        }
        //    }
        //    return View(model);
        //}
        //[HttpGet]
        //public async Task<IActionResult> AddORUpdateGroupType(int? gtID)
        //{
        //    GroupType groupType = await db.GroupTypes.FindAsync(gtID);
        //    if(groupType == null)
        //    {
        //        groupType = new GroupType{ atributesGroups = new List<AtributesGroup>()};
        //        return View(groupType);
        //    }
        //    else
        //    {
        //        return View(groupType);
        //    }
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddOrUpdateAtributeGroup(AtributesGroup model)
        //{
        //    Console.WriteLine(model);
        //    if (ModelState.IsValid)
        //    {
        //        if (!db.AtributesGroups.Contains(model))
        //        {
        //            if (!db.AtributesGroups.Any(ag => ag.name == model.name))
        //            {
        //                db.AtributesGroups.Add(model);
        //                db.SaveChanges();
        //                return RedirectToAction("GroupTypes", "Data");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, "Категория с таким именем уже существует");
        //            }
        //        }
        //        else
        //        {
        //            if (db.AtributesGroups.Count(ag => ag.idAtrbutesGroup != model.idAtrbutesGroup && ag.name == ag.name) == 0)
        //            {
        //                db.AtributesGroups.Update(model);
        //                db.SaveChanges();
        //                return RedirectToAction("GroupTypes", "Data");
        //            }
        //            else
        //            {                       
        //                ModelState.AddModelError(string.Empty, "Категория с таким именем уже существует");
        //            }
        //        }
        //    }
        //    AtributesGroup tmp = db.AtributesGroups.Find(model.idAtrbutesGroup);
        //    tmp.atributes = model.atributes;
        //    tmp.GroupType = db.GroupTypes.Find(model.idGroupType);
        //    Console.WriteLine(tmp);
        //    model = tmp;
        //    Console.WriteLine(model);
        //    return View(model);
        //}
        //[HttpGet]
        //public async Task<ActionResult> AddOrUpdateAtributeGroup(int? gtID, int? agID)
        //{
        //    AtributesGroup atributesGroup = await db.AtributesGroups.FindAsync(agID);
        //    if(atributesGroup == null)
        //    {
        //        atributesGroup = new AtributesGroup { GroupType = db.GroupTypes.Find(gtID),
        //         atributes = new List<Atribute>() };
        //        atributesGroup.idGroupType = atributesGroup.GroupType.idGroupType;
        //    }
        //    return View(atributesGroup);
        //}
    }
}
