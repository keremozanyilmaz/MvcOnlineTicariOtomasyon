using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c= new Context();
        public ActionResult Index()
        {
            var values = c.Departments.Where(x=>x.DepartmentStatus==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var dep = c.Departments.Find(id);
            dep.DepartmentStatus = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartment(int id)
        {
            var dep = c.Departments.Find(id);
            return View("GetDepartment", dep);
        }

        public ActionResult UpdateDepartment(Department p)
        {
            var dept = c.Departments.Find(p.DepartmentID);
            dept.DepartmentName = p.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetails(int id)
        {
            var values = c.Employees.Where(x => x.Departmentid == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;

            return View(values);
        }
        public ActionResult DepartmantEmployeeSale(int id)
        {
            var values = c.SalesMovements.Where(x => x.EmployeeID == id).ToList();
            var emp = c.Employees.Where(x => x.EmployeeID == id).Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();
            ViewBag.dpers = emp;
            return View(values);
        }
    }
}