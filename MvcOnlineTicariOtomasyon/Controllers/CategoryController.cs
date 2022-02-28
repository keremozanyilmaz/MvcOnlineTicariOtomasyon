using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var ctg = c.Categories.Find(id);
            c.Categories.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {
            var ctg = c.Categories.Find(id);
            return View("GetCategory", ctg);
        }

        public ActionResult UpdateCategory(Category k)
        {
            var ctg = c.Categories.Find(k.CategoryID);
            ctg.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}