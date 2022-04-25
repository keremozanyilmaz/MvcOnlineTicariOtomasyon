using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Currents.Count().ToString();
            ViewBag.v1 = value1;

            var value2 = c.Products.Count().ToString();
            ViewBag.v2 = value2;

            var value3 = c.Employees.Count().ToString();
            ViewBag.v3 = value3;

            var value4 = c.Categories.Count().ToString();
            ViewBag.v4 = value4;

            var value5 = c.Products.Sum(x=>x.ProductStock).ToString();
            ViewBag.v5 = value5;

            var value6 = (from x in c.Products select x.ProductBrand).Distinct().Count().ToString();
            ViewBag.v6 = value6;

            var value7 = c.Products.Count(x => x.ProductStock <= 20).ToString();
            ViewBag.v7 = value7;

            var value8 = (from x in c.Products orderby x.ProductSalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.v8 = value8;

            var value9 = (from x in c.Products orderby x.ProductSalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.v9 = value9;

            var value10 = c.Products.Count(x => x.ProductName=="Buzdolabı").ToString();
            ViewBag.v10 = value10;

            var value11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.v11 = value11;

            var value12 = c.Products.GroupBy(x => x.ProductBrand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.v12 = value12;

            var value13 = c.Products.Where(p=>p.ProductID==( c.SalesMovements.GroupBy(x=> x.ProductID).OrderByDescending(z=> z.Count()).Select(y=>y.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.v13 = value13;


            var value14 = c.SalesMovements.Sum(x => x.SalesMovementTotalAmount).ToString();
            ViewBag.v14 = value14;

            DateTime today = DateTime.Today;
            var value15 = c.SalesMovements.Count(x => x.SalesMovementDate == today).ToString();
            ViewBag.v15 = value15;

            var value16 = c.SalesMovements.Where(x => x.SalesMovementDate == today).Sum(y => y.SalesMovementTotalAmount).ToString();
            ViewBag.v16 = value16;

            return View();
        }
    }
}