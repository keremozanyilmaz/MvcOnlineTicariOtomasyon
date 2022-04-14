using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();

        public ActionResult Index()
        {
            var products = c.Products.Where(x => x.ProductStatus == true).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var value = c.Products.Find(id);
            value.ProductStatus = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;

            var value = c.Products.Find(id);
            return View("GetProduct", value);
        }

        public ActionResult UpdateProduct(Product p)
        {
            var pr = c.Products.Find(p.ProductID);
            pr.ProductPurchasePrice = p.ProductPurchasePrice;
            pr.ProductStatus = p.ProductStatus;
            pr.CategoryID = p.CategoryID;
            pr.ProductBrand = p.ProductBrand;
            pr.ProductSalePrice = p.ProductSalePrice;
            pr.ProductStock = p.ProductStock;
            pr.ProductName = p.ProductName;
            pr.ProductImage = p.ProductImage;
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult ProductList()
        {
            var values = c.Products.ToList();
            return View(values);
        }
    }
}