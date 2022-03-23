using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee e)
        {
            c.Employees.Add(e);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
       
            var e = c.Employees.Find(id);
            return View("GetEmployee",e);
        }
        public ActionResult UpdateEmployee(Employee p)
        {
            var emp = c.Employees.Find(p.EmployeeID);
            emp.EmployeeName = p.EmployeeName;
            emp.EmployeeSurname = p.EmployeeSurname;
            emp.EmployeeImage = p.EmployeeImage;
            emp.Departmentid = p.Departmentid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}