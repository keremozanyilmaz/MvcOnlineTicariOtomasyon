using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SalesMovements.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSales()
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value= x.ProductID.ToString()
                                           }).ToList();

           ;
            List<SelectListItem> value2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();

           

            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName +" " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.vl1 = value1;
            ViewBag.vl2 = value2;
            ViewBag.vl3 = value3; 
            return View();
        }
        [HttpPost]
        public ActionResult AddSales(SalesMovement s)
        {
            s.SalesMovementDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetSale(int id)
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            ;
            List<SelectListItem> value2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();



            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.vl1 = value1;
            ViewBag.vl2 = value2;
            ViewBag.vl3 = value3;
            var value = c.SalesMovements.Find(id);
            return View("GetSale", value);
        }

        public ActionResult UpdateSale(SalesMovement p)
        {
            var value = c.SalesMovements.Find(p.SalesMovementsID);
            value.CurrentID = p.CurrentID;
            value.SalesMovementQuantity = p.SalesMovementQuantity;
            value.SalesMovementPrice = p.SalesMovementPrice;
            value.EmployeeID =p.EmployeeID;
            value.SalesMovementDate = p.SalesMovementDate;
            value.SalesMovementTotalAmount = p.SalesMovementTotalAmount;
            value.ProductID = p.ProductID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaleDetail(int id)
        {
            var values = c.SalesMovements.Where(x => x.SalesMovementsID == id).ToList();
            return View(values);
        }
    }
} 